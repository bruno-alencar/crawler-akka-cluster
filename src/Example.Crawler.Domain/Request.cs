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
    public class Request
    {
        private HttpClient _httpClient;
        private HttpWebRequest _request;
        private const string DefaultUrl = "http://www.tudogostoso.com.br/";
        private static readonly Encoding DefaultEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        public Request(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri(DefaultUrl);
        }

        public async Task<string> PreRequestAsync(string uri = null)
        {
            if (string.IsNullOrWhiteSpace(uri))
                return "error";

            var baseAddress = new Uri("http://example.com");
            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "/test");
                message.Headers.Add("Cookie", "cookie1=value1; cookie2=value2");
                var result = await client.SendAsync(message);
                result.EnsureSuccessStatusCode();
            }


            return null;
        }

        public void Scrap()
        {

        }

        public async Task<string> PostScrap()
        {

            try
            {

                var baseAddress = new Uri(DefaultUrl);
                using (var handler = new HttpClientHandler { UseCookies = true })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/22.0.1207.1 Safari/537.1");
                    var result = await client.SendAsync(message);
                    return await result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public struct ScrapContext
        {
            public string EventTarget;
            public string EventArgument;
            public string ViewState;
            public string ViewStateGenerator;
            public string EventValidation;
            public string KeyWord;
            public string AccessKey;
            public string Captcha;
            public string ButtonName;
            public string Token;
            public string CaptchaAudio;
            public string ImageCaptchaBase64;

            public bool Initialized { get; internal set; }
        }
    }
}
