using Akka.Actor;
using Akka.TestKit.Xunit2;
using Example.Crawler.Akka;
using Example.Crawler.Domain;
using Example.Crawler.Domain.Common;
using Moq;
using System;
using Xunit;

namespace Example.Tests
{
    [Trait("Unit tests", "Actor WorkerActor")]
    public class WorkerActorTests : TestKit
    {
        public WorkerActorTests()
        {

        }

        [Fact(DisplayName = "Send PreScrap")]
        public void Working_WhenConfigureIsSend_ReturnsOK()
        {
            // Arrange

            var html = "OK";
            var mockApplicationService = new Mock<ICrawlerApplicationService>();
            mockApplicationService
                .Setup(e => e.PreScrapAsync(It.IsAny<string>()))
                .ReturnsAsync(html)
                .Verifiable();

            var coordinator = Sys.ActorOf(Props.Create(() => new WorkerActor(mockApplicationService.Object)));

            var result = default(WorkerActor.PreScrapSuccessfully);

            // Act            
            Within(TimeSpan.FromSeconds(10), () =>
            {
                coordinator.Tell(new PreScrap { Uri = "http://teste.com"});
                result = ExpectMsg<WorkerActor.PreScrapSuccessfully>();
            });

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(1, result.Retry);
        }
    }
}
