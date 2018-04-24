using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmericanOptions.Calculations;

namespace AmericanOptions.Bt
{
    internal class BtCalculator
    {
        internal async Task<List<BtResult>> Calculate(double riskFreeRate, double volatilitySigma, double tau, double strikePrice, double stockPrice, double numberOfIterration, double numberOfNodes, double timeToMaturity)
        {
            BtCalculator bt = new BtCalculator();
            List<BtResult> btResults = new List<BtResult>();
            StandardNormalDistribution standardNormalDistribution = new StandardNormalDistribution();
            IntegralPoints integralPoints = new IntegralPoints();
            double integralPointD1;
            double integralPointD2;
            double distribution;

            // Results
            double BtK_1 = 0;
            double BtK;

            for (int i = 0; i <= numberOfIterration; i++)
            {
                if (i == 0)
                {
                    btResults.Add(new BtResult { ResultNumber = i, Value = strikePrice });
                }
                else if (i == 1)
                {
                    integralPointD1 = integralPoints.CalculateIntegralPointD1(strikePrice, strikePrice, riskFreeRate, volatilitySigma, tau);
                    integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, volatilitySigma, tau);
                    distribution = standardNormalDistribution.CalculatePDF(integralPointD1);
                    BtK_1 = bt.CalculateBtK_1(volatilitySigma, strikePrice, distribution, integralPointD1, riskFreeRate, tau, integralPointD2);
                    
                    btResults.Add(new BtResult { ResultNumber = i, Value = BtK_1 });
                }
                else
                {
                    integralPointD1 = integralPoints.CalculateIntegralPointD1(BtK_1, strikePrice, riskFreeRate, volatilitySigma, tau);
                    integralPointD2 = integralPoints.CalculateIntegralPointD2(integralPointD1, volatilitySigma, tau);
                    distribution = standardNormalDistribution.CalculatePDF(integralPointD1);
                    BtK = bt.CalculateBt(volatilitySigma, strikePrice, distribution, integralPointD1, riskFreeRate, tau, integralPointD2, numberOfNodes, timeToMaturity);
                    
                    if (double.IsNaN(BtK))
                    {
                        break;
                    }

                    BtK_1 = BtK;

                    btResults.Add(new BtResult { ResultNumber = i, Value = BtK });
                }
            }

            return btResults;
        }

        private double CalculateBtK_1(double sigma, double K, double dist, double d1, double r, double tau, double d2)
        {
            double a = (1 / sigma * Math.Sqrt(2 * Math.PI * tau));

            return (K * (1 / (dist + a) * Math.Exp(-0.5 * Math.Pow(d1, 2)))) *
                (a * Math.Exp(-((r * tau) + (0.5 * Math.Pow(d2, 2))))) +
                (((2 * sigma * r) / ((2 * r) + (Math.Pow(sigma, 2))) * (2 * dist) - 1));
        }

        private double CalculateBt(double sigma, double K, double dist, double d1, double r, double t, double d2, double n, double T)
        {
            double a = (1 / sigma * Math.Sqrt(2 * Math.PI * t));
            double integralFunction = new IntegralFunction().Calculate(n, T, r, sigma, t, d2);

            return (1 / (dist + a * Math.Exp(-0.5 * Math.Pow(d1, 2)))) *
                (a * K * Math.Exp(-((r * t) + (0.5 * Math.Pow(d2, 2))))) +
                (r * K * integralFunction);
        }
    }
}
