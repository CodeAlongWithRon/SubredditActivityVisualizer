using Moq;
using SubredditActivityVisualizer.Application.Services;
using SubredditActivityVisualizer.Infrastructure.Reddit;
using SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.Services
{
   public class GetSubscribersServiceTests
   {
      [Theory]
      [InlineData(null)]
      [InlineData("")]
      public async Task Get_SubredditNullOrWhitespace_ThrowsArgumentNullException(string subreddit)
      {
         // Arrange
         var getSubscribersClient = new Mock<IGetSubscribersClient>(MockBehavior.Strict);
         var subredditAboutResponse = new SubredditAboutResponse();

         getSubscribersClient
            .Setup(client => client.GetAsync(subreddit))
            .ReturnsAsync(subredditAboutResponse);

         var getSubscribersService = new GetSubscribersService(getSubscribersClient.Object);

         // Act / Assert
         await Assert.ThrowsAsync<ArgumentNullException>(nameof(subreddit), () => getSubscribersService.GetAsync(subreddit));
      }

      [Fact]
      public async Task Get_HappyFlow_ReturnsSubscribers()
      {
         // Arrange
         const string Subreddit = "csharp";
         const int AmountOfSubscribers = 123;
         var getSubscribersClient = new Mock<IGetSubscribersClient>(MockBehavior.Strict);
         
         var subredditAboutResponse = new SubredditAboutResponse
         {
            Data = new SubredditAboutResponseData
            {
               Subscribers = AmountOfSubscribers
            }
         };

         getSubscribersClient
            .Setup(client => client.GetAsync(Subreddit))
            .ReturnsAsync(subredditAboutResponse);

         var getSubscribersService = new GetSubscribersService(getSubscribersClient.Object);

         // Act
         var result = await getSubscribersService.GetAsync(Subreddit);

         // Assert
         Assert.Equal(AmountOfSubscribers, result);
      }
   }
}
