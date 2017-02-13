using System;

namespace ExpressiveExtensions.Core.NumberExtensions
{
    public static class NumberRounding
    {
        /// <summary>
        /// Rounds a double value.
        /// </summary>
        /// <param name="value">Value to round.</param>
        /// <returns>The results of the rounding operation.</returns>
        public static long Round(this double value)
        {
            if (value >= 0)
            {
                return (long)Math.Floor(value);
            }

            return (long)Math.Ceiling(value);
        }

        /// <summary>
        /// Rounds the supplied decimal to the specified amount of decimal points.
        /// </summary>
        /// <param name="val">The decimal to round.</param>
        /// <param name="decimalPoints">The number of decimal points to round the output value to.</param>
        /// <returns>A rounded decimal.</returns>
        public static decimal RoundDecimalPoints(this decimal val, int decimalPoints)
        {
            return Math.Round(val, decimalPoints);
        }

        /// <summary>
        /// Rounds the supplied decimal value to two decimal points.
        /// </summary>
        /// <param name="val">The decimal to round.</param>
        /// <returns>A decimal value rounded to two decimal points.</returns>
        public static decimal RoundToTwoDecimalPoints(this decimal val)
        {
            return Math.Round(val, 2);
        }
    }
}
