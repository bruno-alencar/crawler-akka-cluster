using Example.Crawler.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Example.Tests
{
    public class RequestTests
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task PreRequestAsync_WhenUriIsNullOrEmpty_ReturnsError(string uri)
        {
            // Arrange
            var request = new Request();

            // Act
            var result = await request.PreRequestAsync(uri);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("uri is null or empty", result);

        }

        [Fact]
        public async Task PostScrap_WhenDataIsValid_ReturnsOK()
        {
            // Arrange
            var httpClient = new HttpClient();
            var uri = "http://www.tudogostoso.com.br/";
            var request = new Request(httpClient: httpClient);

            // Act
            var result = await request.PreRequestAsync(uri);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("OK", result);
            Assert.Equal(uri, httpClient.BaseAddress.ToString());
            //Assert.Equal("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/22.0.1207.1 Safari/537.1", httpClient.DefaultRequestHeaders.GetValues("User-Agent").First());
        }

        [Fact]
        public async Task PostScrap_WhenDataIsValid_ReturnsOK()
        {
            // Arrange
            var httpClient = new HttpClient();
            var uri = "http://www.tudogostoso.com.br/";
            var request = new Request(httpClient: httpClient);

            var a = request.PreRequestAsync(uri);

            // Act
            var result = await request.ScrapAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("OK", result);
            Assert.Equal(uri, httpClient.BaseAddress.ToString());
            Assert.Equal("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/22.0.1207.1 Safari/537.1", httpClient.DefaultRequestHeaders.GetValues("User-Agent").First());
        }
    }
}
