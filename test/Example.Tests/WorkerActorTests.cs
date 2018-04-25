using Akka.Actor;
using Akka.TestKit.Xunit2;
using Example.Crawler.Akka;
using Example.Crawler.Domain;
using Moq;
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

            var mockApplicationService = new Mock<ICrawlerApplicationService>();

            var coordinator = Sys.ActorOf(Props.Create(() => new WorkerActor(mockApplicationService.Object)));

            //var result = default(CoordinatorActor.MaxFailedDefineNumber);

            //// Act            
            //Within(TimeSpan.FromSeconds(10), () =>
            //{
            //    coordinator.Tell(new CoordinatorActor.BeginJob(messageInvoice));
            //    result = ExpectMsg<CoordinatorActor.MaxFailedDefineNumber>();
            //});

            //// Assert
            //Assert.NotNull(result);
            //Assert.Equal(settings.Retry.TryDefineNumber, result.DefineNumber.Retry);

            //Assert.NotNull(result.DefineNumber.Reasons);
            //Assert.Empty(result.DefineNumber.Reasons);
        }
    }
}
