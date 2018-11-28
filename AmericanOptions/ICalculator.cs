using AmericanOptions.Model;
using System.Threading.Tasks;

namespace AmericanOptions
{
   public interface ICalculator
   {
      Task<CalculatorResult[]> CalculateAsync(double r, double sigma, double t, double K, double S, int k, int n, double T);
      Task<CalculatorResult> CalculateK0Async(double K, double S, double r, double t, double sigma, int n, double T);
      Task<CalculatorResult> CalculateBtK1Async(double K, double S, double r, double t, double sigma, int n, double T);
      Task<CalculatorResult> CalculateBtKiAsync(double K, double S, double r, double t, double sigma, int n, double T, int i, double BtK_1);
   }
}