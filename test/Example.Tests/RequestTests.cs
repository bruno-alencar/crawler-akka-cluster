using Example.Crawler.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Example.Tests
{
    public class RequestTests
    {
        [Fact]
        public async Task PostScrap_WhenDataIsValid_ReturnsOK()
        {
            // Arrange
            var request = new Request();

            // Act
            //request.PreRequestAsync();
            var result = await request.Scrap();

            // Assert
            Assert.NotNull(result);
            //Assert.Equal();
        }
    }
}
