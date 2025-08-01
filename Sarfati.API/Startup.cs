using System;
using System.Data;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Azureblue.ApplicationInsights.RequestLogging;
using Dapper;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Sarfati.Core.Exception_handler;
using Sarfati.Core.Filters;
using Sarfati.Core.middlewares;


namespace Sarfati
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.Culture = new CultureInfo("en-US");

                });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            FirebaseApp.Create(new AppOptions()
            {
            });
            services.AddApplicationInsightsTelemetry(options =>
            {
                options.EnableDebugLogger = false;
                options.EnableRequestTrackingTelemetryModule = true;
                options.EnableDiagnosticsTelemetryModule = true;
                options.ConnectionString = Configuration.GetConnectionString("ApplicationInsights");
            });
            services.AddApplicationInsightsTelemetryProcessor<IgnoreHangfireTelemetry>();


            services.AddAppInsightsHttpBodyLogging(o =>
            {
                o.HttpCodes.Add(StatusCodes.Status200OK);
                o.HttpVerbs.Add(HttpMethods.Get);
                o.MaxBytes = 10000;
                o.DisableIpMasking = true;
                o.EnableBodyLoggingOnExceptions = true;
            });
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });
            

            services.AddScoped<IDbConnection>(x =>
                new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));

            
            RegisterStorageModule(services);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.FromSeconds(15),
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer(serverOptions => serverOptions.WorkerCount = 2);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                // Any additional development-specific middleware can go here
            }

            app.UseAppInsightsHttpBodyLogging();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sarfati.API v1");
                c.RoutePrefix = "swagger";

                c.OAuthUsePkce();
                c.OAuthClientId(Configuration["Jwt:ClientId"]);
                c.OAuthClientSecret(Configuration["Jwt:ClientSecret"]);
                c.OAuthRealm(Configuration["Jwt:Realm"]);
                c.OAuthAppName("Your API Name");
                c.OAuthScopeSeparator(" ");
                c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature?.Error is BusinessException businessException)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        context.Response.ContentType = "application/json";

                        var response = new
                        {
                            EnglishMessage = businessException.Message,
                            ArabicMessage = businessException.ArabicMessage
                        };

                        await context.Response.WriteAsJsonAsync(response);
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        var response = new
                        {
                            Error = "An unexpected error occurred."
                        };

                        await context.Response.WriteAsJsonAsync(response);
                    }
                });
            });


            // Log requests and responses
            ///.UseRequestLogging();

            // Redirect HTTP to HTTPS
            app.UseHttpsRedirection();

            // Configure Hangfire dashboard
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AllowAllDashboardAuthorizationFilter() }
            });

            // Enable routing
            app.UseRouting();

            // Configure JWT claim mappings and authentication
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            app.UseAuthentication();

            // Enable authorization
            app.UseAuthorization();

            // Map endpoints
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

           
        }

        private void RegisterStorageModule(IServiceCollection services)
        {

            services.AddAzureClients(builder =>
            {
                var azureBlobsStorageConnectionString =
                    Configuration.GetConnectionString("AzureBlobStorage");

                builder.AddBlobServiceClient(azureBlobsStorageConnectionString);
            });

            

        }
    }
}