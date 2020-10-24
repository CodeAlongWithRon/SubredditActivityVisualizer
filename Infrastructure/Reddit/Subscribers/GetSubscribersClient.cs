using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers
{
   public class GetSubscribersClient : IGetSubscribersClient
   {
      private readonly IHttpClientFactory _httpClientFactory;

      public GetSubscribersClient(IHttpClientFactory httpClientFactory)
      {
         _httpClientFactory = httpClientFactory;
      }

      public async Task<SubredditAboutResponse> GetAsync(string subreddit)
      {
         if (string.IsNullOrWhiteSpace(subreddit))
         {
            throw new ArgumentNullException(nameof(subreddit));
         }

         var httpClient = _httpClientFactory.CreateClient();
         var httpResponseMessage = await httpClient.GetAsync($"https://www.reddit.com/r/{subreddit}/about.json");

         if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
         {
            throw new SubredditDoesNotExistException();
         }

         var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
         return JsonConvert.DeserializeObject<SubredditAboutResponse>(responseContent);
      }
   }
}
