using Microsoft.AspNetCore.Mvc;
using SubredditActivityVisualizer.Application.Services;
using SubredditActivityVisualizer.Website.Models;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Website.Controllers
{
   public class SubscribersController : Controller
   {
      public async Task<IActionResult> Index(string subreddit)
      {
         var service = new GetSubscribersService();
         var subscribers = await service.GetAsync(subreddit);

         var viewModel = new SubscribersViewModel
         {
            Subreddit = subreddit,
            Subscribers = subscribers
         };

         return View(viewModel);
      }
   }
}
