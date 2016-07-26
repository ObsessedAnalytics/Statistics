using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloApplication
{
    class MonteCarlo
    {
        static double[] MonteCarloPossesion(double fgMin, double fgMax, double toMin, double toMax, double ftaMin, double ftaMax, double currReb, double newReb, double iterations)
        {
            double pointsAllow = 102.63;
            double offEff = 106.4;
            double winsCurr = 0;
            double winsNew = 0;
            for (int i = 0; i < iterations; i++)
            {
                double fg = GetRandomNumber(fgMin, fgMax);
                double to = GetRandomNumber(toMin, toMax);
                double fta = GetRandomNumber(ftaMin, ftaMax);
                double currWorking = 0.96 * (fg + to + .44 * fta - currReb);
                double newWorking = 0.96 * (fg + to + .44 * fta - newReb);
                currWorking = Points(currWorking, offEff);
                newWorking = Points(newWorking, offEff);
                currWorking = PythagoreanWins(currWorking, pointsAllow);
                newWorking = PythagoreanWins(newWorking, pointsAllow);
                winsCurr = winsCurr + currWorking;
                winsNew = winsNew + newWorking;
            }

            return new double[2] { winsCurr/iterations, winsNew/iterations };
        }

        // Simple points method to get points from possession and offensive efficiency
        static double Points(double possesion, double offensiveEfficiency)
        {
            return possesion * offensiveEfficiency / 100;
        }

        // Simple pythagorean wins method to calculate the % of wins given points scored and points allowed.
        static double PythagoreanWins(double pointsScored, double pointsAllowed)
        {
            return 82*(Math.Pow(pointsScored, 16.5) / (Math.Pow(pointsScored, 16.5) + Math.Pow(pointsAllowed, 16.5)));
        }

        static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;

        }

        public static double[] GetInput(string fgMin, string fgMax, string toMin, string toMax, string ftaMin, string ftaMax, string totalReb, string currReb, string newReb, string iterations)
        {
            double fgLow = Double.Parse(fgMin);
            double fgHigh = Double.Parse(fgMax);
            double toLow = Double.Parse(toMin);
            double toHigh = Double.Parse(toMax);
            double ftaLow = Double.Parse(ftaMin);
            double ftaHigh = Double.Parse(ftaMax);
            double rebs = Double.Parse(totalReb);
            double rebCurr = Double.Parse(currReb);
            rebCurr = rebs - rebCurr * rebs;
            double rebNew = Double.Parse(newReb);
            rebNew = rebs - rebNew * rebs;
            double i = Double.Parse(iterations);
            

            return MonteCarloPossesion(fgLow, fgHigh, toLow, toHigh, ftaLow, ftaHigh, rebCurr, rebNew, i);
        }


    }
}
