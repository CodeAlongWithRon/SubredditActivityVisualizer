using Microsoft.AspNetCore.Mvc;
using Moq;
using SubredditActivityVisualizer.Application.Services;
using SubredditActivityVisualizer.Website.Controllers;
using SubredditActivityVisualizer.Website.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Website.Tests.Controllers
{
   public class SubscribersControllerTests
   {
      [Theory]
      [InlineData(null)]
      [InlineData("")]
      public async Task Index_SubredditNullOrWhitespace_ThrowsArgumentNullException(string subreddit)
      {
         // Arrange
         var getSubscribersService = new Mock<IGetSubscribersService>(MockBehavior.Strict);

         getSubscribersService
            .Setup(service => service.GetAsync(subreddit))
            .ReturnsAsync(1);

         var subscribersController = new SubscribersController(getSubscribersService.Object);

         // Act / Assert
         await Assert.ThrowsAsync<ArgumentNullException>(nameof(subreddit), () => subscribersController.Index(subreddit));
      }

      [Fact]
      public async Task Index_HappyFlow_ReturnsView()
      {
         // Arrange
         const string Subreddit = "csharp";
         const int Subscribers = 1;
         var getSubscribersService = new Mock<IGetSubscribersService>(MockBehavior.Strict);

         getSubscribersService
            .Setup(service => service.GetAsync(Subreddit))
            .ReturnsAsync(Subscribers);

         var subscribersController = new SubscribersController(getSubscribersService.Object);

         // Act
         var result = await subscribersController.Index(Subreddit);

         // Assert
         var viewResult = Assert.IsType<ViewResult>(result);
         var viewModel = Assert.IsType<SubscribersViewModel>(viewResult.Model);
         Assert.Equal(Subreddit, viewModel.Subreddit);
         Assert.Equal(Subscribers, viewModel.Subscribers);
      }
   }
}
