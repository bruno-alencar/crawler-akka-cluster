using Akka.Actor;
using Example.Crawler.Domain.Common;
using System;

namespace Example.Crawler.Akka
{
    public class WorkerActor : ReceiveActor
    {
        public WorkerActor()
        {
            // Configure Request

            // Send Request

            // Get Data

            // Save on Database

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
