using Microsoft.AspNetCore.Mvc;
using SubredditActivityVisualizer.Application.Services;
using SubredditActivityVisualizer.Website.Models;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Website.Controllers
{
   public class SubscribersController : Controller
   {
      private readonly IGetSubscribersService _getSubscribersService;

      public SubscribersController(IGetSubscribersService getSubscribersService)
      {
         _getSubscribersService = getSubscribersService;
      }

      public async Task<IActionResult> Index(string subreddit)
      {
         var subscribers = await _getSubscribersService.GetAsync(subreddit);

         var viewModel = new SubscribersViewModel
         {
            Subreddit = subreddit,
            Subscribers = subscribers
         };

         return View(viewModel);
      }
   }
}
