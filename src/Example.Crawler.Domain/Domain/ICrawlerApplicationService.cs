using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Crawler.Domain
{
    public interface ICrawlerApplicationService
    {
        Task<string> PreScrap();
        Task<string> Scrap();
        Task<string> PostScrap();
    }
}
