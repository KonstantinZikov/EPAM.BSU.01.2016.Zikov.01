using System;

namespace Task1
{
    public static class MathFunctions
    {
        public static double RootAccuracy { get; } = 0.000001;

        public static double Root(this double number, double power)
        {
            if (Math.Abs(power) < RootAccuracy)
            {
                throw new ArgumentException($"power can't be 0");
            }
            if (number < RootAccuracy)
            {
                throw new ArgumentException($"number can't be less or equal {RootAccuracy}");
            }
            // Newton method doesn't work with negative powers.
            // Such powers will be transform to positive, and the result
            // should be presented in the -1 power.
            bool powerLessThenNull = false;
            if (power < 0.0)
            {
                power = Math.Abs(power);
                powerLessThenNull = true;
            }
            double assumption = number;
            while (Math.Abs(Math.Pow(assumption,power) - number) > RootAccuracy)
            {
                assumption = 
                (
                    (power - 1) * assumption + 
                    number / Math.Pow(assumption, power - 1)
                )/power;
            }
            if (powerLessThenNull)
            {
                return 1.0 / assumption;
            }
            return assumption;
        }
    }
}
