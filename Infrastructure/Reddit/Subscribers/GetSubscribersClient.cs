using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers
{
   public class GetSubscribersClient
   {
      public async Task<SubredditAboutResponse> GetAsync(string subreddit)
      {
         using (var httpClient = new HttpClient())
         {
            var httpResponseMessage = await httpClient.GetAsync($"https://www.reddit.com/r/{subreddit}/about.json");
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<SubredditAboutResponse>(responseContent);
         }
      }
   }
}
