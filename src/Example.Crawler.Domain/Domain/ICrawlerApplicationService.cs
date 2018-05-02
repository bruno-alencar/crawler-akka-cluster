using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Crawler.Domain
{
    public interface ICrawlerApplicationService
    {
        Task<string> PreScrapAsync(string uri = null);
        Task<string> ScrapAsync();
        Task<string> PostScrapAsync();
    }
}
