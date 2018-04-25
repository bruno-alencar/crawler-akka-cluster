using Akka.Actor;
using Example.Crawler.Domain;
using Example.Crawler.Domain.Common;
using System;

namespace Example.Crawler.Akka
{
    public class WorkerActor : ReceiveActor
    {
        private ICrawlerApplicationService _applicationService;

        public WorkerActor(ICrawlerApplicationService applicationService)
        {
            Working();
            _applicationService = applicationService;
        }

        public void Working()
        {
            Receive<PreScrap>(job =>
            {

            });

            Receive<Scrap>(job =>
            {

            });

            Receive<PostScrap>(job =>
            {

            });
        }
    }
}
