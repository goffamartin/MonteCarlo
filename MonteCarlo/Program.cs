using System;

namespace MonteCarlo
{
    class Program
    {
        static Random RNG = new Random();
        delegate double MathFunction(double x);
        static void SetInterval(double from, double to)
        {
            From = from;
            To = to;
        }

        static double From { get; set; }
        static double To { get; set; }
        static double RangeS { get; set; }
        static MathFunction MF { get; set; }
        static int Max { get; set; }

        static void Main(string[] args)
        {
            MF = function2; 
            SetInterval(1.0d, 3.0d);
            GetMaxValue(MF);
            RangeSurface();
            Console.WriteLine(GetSurface(MF));
            Console.ReadLine();
        }
        static void RangeSurface()
        {
            RangeS = (To - From) * Max;
        }
        static double GetMaxValue(MathFunction mathFunction)
        {
            Max = (int)Math.Round(mathFunction(To),0) + 1;
            return function(To);
        }
        static double function(double x)
        {
            double y = Math.Pow(2, x);
            return y;
        }

        static double function2(double x)
        {
            double y = Math.Pow(2, x) + Math.Pow(x,2);
            return y;
        }
        static double GetSurface(MathFunction mathFunction)
        {
            double isUnder = 0;
            double isntUnder = 0;
            double attempts = 1000000;
            for (int i = 0; i < attempts; i++)
            {
                double x = ((To - From) * RNG.NextDouble()) + From;
                double y = RNG.Next(Max) + RNG.NextDouble();
                if (y <= mathFunction(x))
                    isUnder++;
                else
                    isntUnder++;
            }
            double result = RangeS * (isUnder / attempts);
            return result;
        }
    }
}
