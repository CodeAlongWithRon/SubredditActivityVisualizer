using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.ConsoleApp
{
   class Program
   {
      static async Task Main(string[] args)
      {
         using (var httpClient = new HttpClient())
         {
            var subreddit = Console.ReadLine();
            var httpResponseMessage = await httpClient.GetAsync($"https://www.reddit.com/r/{subreddit}/about.json");
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var subredditAboutResponse = JsonConvert.DeserializeObject<SubredditAboutResponse>(responseContent);

            Console.WriteLine(subredditAboutResponse.Data.Subscribers);
         }
      }
   }
}
