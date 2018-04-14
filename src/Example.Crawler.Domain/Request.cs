using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Example.Crawler.Domain
{
    public class Request
    {
        private HttpClient _httpClient;
        private const string DefaultUrl = "http://www.tudogostoso.com.br/";

        public Request(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri(DefaultUrl);
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

        public async Task<string> PostScrap()
        {
            try
            {
                var result = await _httpClient.GetAsync(DefaultUrl);

                return await result.Content.ReadAsStringAsync();
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
