using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Crawler.Domain
{
    public interface ICrawlerApplicationService
    {
        Task<string> PreScrapAsync();
        Task<string> ScrapAsync();
        Task<string> PostScrapAsync();
    }
}
