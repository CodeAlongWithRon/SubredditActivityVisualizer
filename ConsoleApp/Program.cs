using Microsoft.Extensions.DependencyInjection;
using SubredditActivityVisualizer.Application;
using SubredditActivityVisualizer.Application.Services;
using System;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.ConsoleApp
{
   class Program
   {
      static async Task Main(string[] args)
      {
         var serviceCollection = new ServiceCollection();
         DependencyRegistration.RegisterDependencies(serviceCollection);

         using (var serviceProvider = serviceCollection.BuildServiceProvider())
         {
            var subreddit = Console.ReadLine();
            var service = serviceProvider.GetService<IGetSubscribersService>();
            var subscribers = await service.GetAsync(subreddit);

            Console.WriteLine(subscribers);
         }
      }
   }
}
