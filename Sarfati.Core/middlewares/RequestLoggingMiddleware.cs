using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sarfati.Core.middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;


        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
            var stopwatch = Stopwatch.StartNew();

            // Capture the request body with validation
            var requestBody = await FormatRequest(context.Request);

            _logger.LogInformation("TraceId: {TraceId}, Request: {Method} {Path} - Body: {Body}",
                traceId, context.Request.Method, context.Request.Path, requestBody);

            var originalBodyStream = context.Response.Body;
            try
            {
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;
                    await _next(context);

                    responseBody.Seek(0, SeekOrigin.Begin);
                    var responseContent = await new StreamReader(responseBody).ReadToEndAsync();
                    responseBody.Seek(0, SeekOrigin.Begin);

                    stopwatch.Stop();
                    _logger.LogInformation(
                        "TraceId: {TraceId}, Response for {Method} {Path} - Status: {StatusCode} - Time: {ElapsedTime}s - Body: {Body}",
                        traceId, context.Request.Method, context.Request.Path, context.Response.StatusCode,
                        stopwatch.Elapsed.TotalSeconds, responseContent);

                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TraceId: {TraceId}, Unhandled exception.", traceId);
                throw;
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }


        private async Task<string> FormatRequest(HttpRequest request)
        {
            // Check if Content-Length is provided and valid
            if (request.ContentLength == null || request.ContentLength == 0)
            {
                return string.Empty; // No request body to process
            }

            // Set a limit for the request body size (e.g., 10 MB)
            const long maxRequestBodySize = 10 * 1024 * 1024; // 10 MB
            if (request.ContentLength > maxRequestBodySize)
            {
                return "Request body too large to log."; // Skip logging large request bodies
            }

            // Enable buffering to allow reading the body multiple times
            request.EnableBuffering();

            // Read and return the body content
            request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                var bodyContent = await reader.ReadToEndAsync();
                request.Body.Seek(0, SeekOrigin.Begin); // Reset stream position for downstream middleware
                return bodyContent;
            }
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}