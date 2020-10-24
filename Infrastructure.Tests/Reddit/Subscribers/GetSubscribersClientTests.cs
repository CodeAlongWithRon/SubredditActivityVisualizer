using MockHttpClient;
using Moq;
using SubredditActivityVisualizer.Infrastructure;
using SubredditActivityVisualizer.Infrastructure.Reddit;
using SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tests.Reddit.Subscribers
{
   public class GetSubscribersClientTests
   {
      [Theory]
      [InlineData(null)]
      [InlineData("")]
      public async Task Get_SubredditNullOrWhitespace_ThrowsArgumentNullException(string subreddit)
      {
         // Arrange
         var httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);

         httpClientFactory
            .Setup(factory => factory.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient());

         var getSubscribersClient = new GetSubscribersClient(httpClientFactory.Object);

         // Act / Assert
         await Assert.ThrowsAsync<ArgumentNullException>(nameof(subreddit), () => getSubscribersClient.GetAsync(subreddit));
      }

      [Fact]
      public async Task Get_SubredditDoesNotExist_ThrowsSubredditDoesNotExistException()
      {
         // Arrange
         var httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
         var httpClient = MockHttpClientFactory.Create(HttpStatusCode.NotFound);

         httpClientFactory
            .Setup(factory => factory.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

         var getSubscribersClient = new GetSubscribersClient(httpClientFactory.Object);

         // Act / Assert
         await Assert.ThrowsAsync<SubredditDoesNotExistException>(() => getSubscribersClient.GetAsync("csharp"));
      }

      [Fact]
      public async Task Get_HappyFlow_ReturnsSubredditAboutResponse()
      {
         // Arrange
         var httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
         var subredditAboutResponse = new SubredditAboutResponse();
         var httpClient = MockHttpClientFactory.Create(HttpStatusCode.OK, subredditAboutResponse);

         httpClientFactory
            .Setup(factory => factory.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

         var getSubscribersClient = new GetSubscribersClient(httpClientFactory.Object);

         // Act
         var result = await getSubscribersClient.GetAsync("csharp");

         // Assert
         Assert.NotNull(result);
      }
   }
}
