using System;

namespace ExpressiveExtensions.Core.NumberExtensions
{
    public static class NumberValidations
    {
        /// <summary>
        /// Determines if the number is prime.
        /// </summary>
        /// <param name="i">Integer to inspect.</param>
        /// <returns>Results of the determination.</returns>
        public static bool IsPrime(this int i)
        {
            if ((i % 2) == 0)
            {
                return i == 2;
            }

            int sqrt = (int)Math.Sqrt(i);

            for (int t = 3; t <= sqrt; t = t + 2)
            {
                if (i % t == 0)
                {
                    return false;
                }
            }

            return i != 1;
        }

        /// <summary>
        /// Determines if a number lies between two numbers.  Non-inclusive of the low- and high-bound numbers.
        /// </summary>
        /// <param name="i">Integer to use in comparison.</param>
        /// <param name="lowerBound">The low-bound number.</param>
        /// <param name="upperBound">The high-bound number.</param>
        /// <returns>Results of the comparison.</returns>
        public static bool IsExclusiveBetween(this int i, int lowerBound, int upperBound)
        {
            return i > lowerBound && i < upperBound;
        }

        /// <summary>
        /// Determines if a number lies between two numbers.  Inclusive of the low- and high-bound numbers.
        /// </summary>
        /// <param name="i">Integer to use in comparison.</param>
        /// <param name="lowerBound">The low-bound number.</param>
        /// <param name="upperBound">The high-bound number.</param>
        /// <returns>Results of the comparison.</returns>
        public static bool IsInclusiveBetween(this int i, int lowerBound, int upperBound)
        {
            return i >= lowerBound && i <= upperBound;
        }

        /// <summary>
        /// Determines if a number lies between two numbers.
        /// </summary>
        /// <param name="i">Integer to use in comparison.</param>
        /// <param name="lowerBound">The low-bound number.</param>
        /// <param name="upperBound">The high-bound number.</param>
        /// <param name="includeBounds">If true, includes low- and high-bound numbers in the comparison.</param>
        /// <returns>Results of the comparison.</returns>
        public static bool IsBetween(this int i, int lowerBound, int upperBound, bool includeBounds)
        {
            if (includeBounds)
            {
                return i.IsInclusiveBetween(lowerBound, upperBound);
            }
            else
            {
                return i.IsExclusiveBetween(lowerBound, upperBound);
            }
        }

        public static bool IsGreaterThan(this int i, int number)
        {
            return i > number;
        }

        public static bool IsGreaterThanOrEqualTo(this int i, int number)
        {
            return i >= number;
        }

        public static bool IsLessThanThan(this int i, int number)
        {
            return i < number;
        }

        public static bool IsLessThanThanOrEqualTo(this int i, int number)
        {
            return i <= number;
        }

        public static bool IsEqualTo(this int i, int number)
        {
            return i == number;
        }
    }
}
