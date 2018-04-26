using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Example.Crawler.Domain
{
    public class Request : ICrawlerApplicationService
    {
        private HttpClient _httpClient;
        private HttpWebRequest _request;
        private ScrapContext _scrapContext;
        private const string DefaultUrl = "http://www.tudogostoso.com.br/";
        private static readonly Encoding DefaultEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        public Request(HttpClient httpClient = null)
        {
            //_httpClient = httpClient ?? new HttpClient();
            //_httpClient.BaseAddress = new Uri(DefaultUrl);
        }

        public async Task<string> PreRequestAsync(string uri = null)
        {
            if (string.IsNullOrWhiteSpace(uri))
                return "uri is null or empty";

            try
            {
                var baseAddress = new Uri(uri ?? DefaultUrl);
                var handler = new HttpClientHandler
                {
                    UseCookies = true
                };

                _httpClient = _httpClient ?? new HttpClient(handler)
                {
                    BaseAddress = baseAddress
                };

                var message = new HttpRequestMessage(HttpMethod.Get, "/");
                message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/22.0.1207.1 Safari/537.1");

                _scrapContext = new ScrapContext
                {
                    Message = message
                };

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Scrap()
        {
            try
            {
                var result = await _httpClient.SendAsync(_scrapContext.Message);
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> PostScrap()
        {
            return "";
        }

        public Task<string> PreScrap()
        {
            throw new NotImplementedException();
        }

        public struct ScrapContext
        {
            public HttpRequestMessage Message;
            public bool Initialized { get; internal set; }
        }
    }
}
