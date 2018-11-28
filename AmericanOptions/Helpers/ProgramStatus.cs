using System.Collections.Generic;

namespace AmericanOptions.Helpers
{
   public class ProgramStatus
   {
      private static readonly IDictionary<int, string> _statuses = new Dictionary<int, string>
      {
         {0,"Ready"},
         {1,"Running"},
         {2,"Canceling"},
         {3,"Cleaning"},
         {4,"Completed"},
         {5,"Canceled"},
         {6,"Cleaned"},
         {7,"Error"},
         {8,"Validating"},
         {9,"Validated"}
      };

      public static string GetStatus(Status status)
      {
         return _statuses[(int)status];
      }
   }
   
   public enum Status
   {
      Ready,
      Running,
      Canceling,
      Cleaning,
      Completed,
      Canceled,
      Cleaned,
      Error,
      Validating,
      Validated
   }
}
