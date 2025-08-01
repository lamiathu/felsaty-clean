using MediatR;
using Sarfati;
using Sarfati.Core.Handlers;

namespace SarfatiTesting;

public class UnitTest1 : IClassFixture<SingletonWebApplicationFactory<Startup>>
{
    private readonly SingletonWebApplicationFactory<Startup> _factory;

    public UnitTest1(SingletonWebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    private T GetService<T>()
    {
        return (T)_factory.Services.GetService(typeof(T))!;
    }


    [Fact]
    public async void TestHandler()
    {
        var _mediator = GetService<IMediator>();
        var boolean = await _mediator.Send(new AddRewardRequest
        {
            Name = null,
            Description = null,
            Points = 0,
            FK_ChildId = null,
            Avatar = null,
            Duration = null,
            ImageId = null
        });
        Assert.True(boolean);
    }
}