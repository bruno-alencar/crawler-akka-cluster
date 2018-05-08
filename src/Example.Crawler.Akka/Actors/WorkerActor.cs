using Akka.Actor;
using Example.Crawler.Domain;
using Example.Crawler.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Example.Crawler.Akka
{
    public class WorkerActor : ReceiveActor
    {
        #region Messages
        public class BaseMessage
        {
            public int Retry { get; set; }
            public List<string> Reasons { get; set; }
        }

        public class UrlToSend
        {
            public Uri Uri { get; set; }
        }

        public class PreScrapSuccessfully : BaseMessage
        {
            public PreScrapSuccessfully()
            {

            }
        }

        public class PreScrapFailed : BaseMessage
        {
            public PreScrapFailed()
            {

            }
        }

        public class PreScrapTerminated : BaseMessage
        {
            public PreScrapTerminated()
            {

            }
        }
        #endregion

        private ICrawlerApplicationService _applicationService;

        public WorkerActor(ICrawlerApplicationService applicationService)
        {
            Working();
            _applicationService = applicationService;
        }

        public void Working()
        {
            ReceiveAsync<PreScrap>(async job =>
            {
                var result = await _applicationService.PreScrapAsync(job.Uri);

                if (result == "OK")
                    Sender.Tell(new PreScrapSuccessfully());
                else if (string.IsNullOrEmpty(result))
                    Sender.Tell(new PreScrapFailed());
                else if (result == "error")
                    Sender.Tell(new PreScrapTerminated());
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
