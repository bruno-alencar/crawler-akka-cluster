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

            //_httpClient.BaseAddress = new Uri(uri);

            //_httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            //_httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { MaxAge = TimeSpan.FromSeconds(0) };

            //_httpClient.CookieContainer

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

    //            var baseAddress = new Uri("http://example.com");
    //            var cookieContainer = new CookieContainer();
    //            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
    //            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
    //            {
    //                var content = new FormUrlEncodedContent(new[]
    //                {
    //    new KeyValuePair<string, string>("foo", "bar"),
    //    new KeyValuePair<string, string>("baz", "bazinga"),
    //});
    //                cookieContainer.Add(baseAddress, new Cookie("CookieName", "cookie_value"));
    //                var result = client.PostAsync("/test", content).Result;
    //                result.EnsureSuccessStatusCode();
    //            }

                var baseAddress = new Uri(DefaultUrl);
                using (var handler = new HttpClientHandler { UseCookies = true })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/");
                    message.Headers.Add("Cookie", "datadome=AHrlqAAAAAMAhbp-LxIg9ywAs79lIg==; nav22518=7bdaa1d61ce4a98495977500609|2_234; _ga=GA1.3.1193982996.1503320096; tt.u=840A000ADE476E59D65E8E69029C9846; trc_cookie_storage=taboola%2520global%253Auser-id%3D2f9a2e0d-b2c6-47cc-9620-6edd8f7ec8d7-tuct67cd4d; _gid=GA1.3.358097844.1523842463; __gads=ID=432bb6e3ee1f0abb:T=1523842446:S=ALNI_MYcVKv4fb23AwCkDNYKD_W1Zd-YfA; tt.nprf=; tt_c_vmt=1523896790; tt_c_c=direct; tt_c_s=direct; tt_c_m=direct; _ttuu.s=1523896790706 If-None-Match:W/\"907f0058e317e22e9eb65ae7269f10b0\"");
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
