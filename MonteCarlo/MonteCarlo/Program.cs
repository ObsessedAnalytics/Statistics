using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static double MonteCarloPossesion()
        {

        }

        // Simple points method to get points from possession and offensive efficiency
        static double Points(double possesion, double offensiveEfficiency)
        {
            return possesion * offensiveEfficiency / 100;
        }

        // Simple pythagorean wins method to calculate the % of wins given points scored and points allowed.
        static double PythagoreanWins(double pointsScored, double pointsAllowed)
        {
            return Math.Pow(pointsScored, 16.5) / (Math.Pow(pointsScored, 16.5) + Math.Pow(pointsAllowed, 16.5));
        }

        static double 
    }


}
