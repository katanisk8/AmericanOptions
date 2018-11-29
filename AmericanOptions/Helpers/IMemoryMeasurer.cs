using System.Threading.Tasks;

namespace AmericanOptions.Helpers
{
   public interface IMemoryMeasurer
   {
      Task<string> GetTotalMemoryWithSuffixAsync();
      Task<string> GetObjectSizeWithSuffixAsync(object obj);
   }
}