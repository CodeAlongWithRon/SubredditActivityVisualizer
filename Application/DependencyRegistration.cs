using Microsoft.Extensions.DependencyInjection;
using SubredditActivityVisualizer.Application.Services;

namespace SubredditActivityVisualizer.Application
{
   public static class DependencyRegistration
   {
      public static void RegisterDependencies(IServiceCollection services)
      {
         services.AddSingleton<IGetSubscribersService, GetSubscribersService>();

         Infrastructure.DependencyRegistration.RegisterDependencies(services);
      }
   }
}
