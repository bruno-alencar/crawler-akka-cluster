using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Example.Crawler.Domain
{
    public class Request
    {
        private HttpClient _httpClient;

        public Request(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public string PreRequest(string uri = null)
        {
            if (string.IsNullOrWhiteSpace(uri))
                return "error";

            _httpClient.BaseAddress = new Uri(uri);
            //_httpClient.DefaultRequestHeaders;

            return null;
        }

        public void Scrap()
        {

        }

        public void PostScrap()
        {

        }
    }
}
