using System;

namespace SubredditActivityVisualizer.Infrastructure
{
   public class SubredditDoesNotExistException : Exception
   {
      public SubredditDoesNotExistException()
      {
      }

      public SubredditDoesNotExistException(string message) : base(message)
      {
      }

      public SubredditDoesNotExistException(string message, Exception innerException) : base(message, innerException)
      {
      }
   }
}
