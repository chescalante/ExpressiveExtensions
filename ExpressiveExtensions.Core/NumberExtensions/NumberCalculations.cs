using System;

namespace ExpressiveExtensions.Core.NumberExtensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Calculates a value's percentage of another value.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <param name="totalValue">Total value to compare original to.</param>
        /// <returns>Integer percentage value.</returns>
        public static int PercentageOf(this double value, double totalValue)
        {
            return Convert.ToInt32(value * 100 / totalValue);
        }

        /// <summary>
        /// Calculates a value's percentage of another value.
        /// </summary>
        /// <param name="value">Value to compare.</param>
        /// <param name="totalValue">Total value to compare original to.</param>
        /// <returns>Integer percentage value.</returns>
        public static int PercentageOf(this long value, long totalValue)
        {
            return Convert.ToInt32(value * 100 / totalValue);
        }

        /// <summary>
        /// Returns the specified number squared.
        /// </summary>
        /// <param name="i">Number to square.</param>
        /// <returns>The number squared.</returns>
        public static int Squared(this int i)
        {
            return i * i;
        }

        /// <summary>
        /// Returns the specified number squared.
        /// </summary>
        /// <param name="i">Number to square.</param>
        /// <returns>The number squared.</returns>
        public static double Squared(this double i)
        {
            return i * i;
        }

        /// <summary>
        /// Calculates a value's power of another value.
        /// </summary>
        /// <param name="i">Value to power.</param>
        /// <param name="n">Power.</param>
        /// <returns>The number powered.</returns>
        public static double Pow(this double i, double n)
        {
            return Math.Pow(i, n);
        }

        /// <summary>
        /// Calculates a value's square root.
        /// </summary>
        /// <param name="i">Value.</param>
        /// <returns>The square root of number.</returns>
        public static double Sqrt(this double i)
        {
            return Math.Sqrt(i);
        }

        /// <summary>
        /// Calculates a value's Nth root.
        /// </summary>
        /// <param name="i">Value.</param>
        /// <param name="n">Nth root.</param>
        /// <returns>The Nth root of number.</returns>
        public static double NthRoot(this double i, int n)
        {
            if (!n.IsGreaterThan(0))
                throw new ArgumentException("Cannot calculate the roots of less than zero. Please supply a different Nth root.");

            return Math.Pow(i, 1.0 / n);
        }
    }
}
