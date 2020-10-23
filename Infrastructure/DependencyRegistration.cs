using Microsoft.Extensions.DependencyInjection;
using SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers;

namespace SubredditActivityVisualizer.Infrastructure
{
   public static class DependencyRegistration
   {
      public static void RegisterDependencies(IServiceCollection services)
      {
         services.AddHttpClient();
         services.AddSingleton<IGetSubscribersClient, GetSubscribersClient>();
      }
   }
}
