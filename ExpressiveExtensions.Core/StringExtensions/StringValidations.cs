using System;
using System.Text.RegularExpressions;

namespace ExpressiveExtensions.Core
{
    public static class StringValidations
    {
        /// <summary>
        /// Detects if a <see cref="string">string</see> can be parsed to a valid date.
        /// </summary>
        /// <param name="value">Value to inspect.</param>
        /// <returns>Whether or not the <see cref="string">string</see> is formatted as a date.</returns>
        /// <example>
        ///     <code language="c#">
        ///         bool isDate = "12/31/1971".IsDate();
        ///     </code>
        /// </example>
        public static bool IsDate(this string value)
        {
            return DateTime.TryParse(value, out DateTime temp);
        }

        /// <summary>
        /// Determines whether the specified <see cref="string">string</see> is null or empty.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> value to check.</param>
        /// <returns>Boolean indicating whether the <see cref="string">string</see> is null or empty.</returns>
        /// <example>
        ///     <code language="c#">
        ///         if (!myString.IsEmpty())
        ///         {
        ///             doStuff(myString);
        ///         }
        ///     </code>
        /// </example>
        public static bool IsEmpty(this string s)
        {
            return (s == null) || (s.Length == 0);
        }

        /// <summary>
        /// Indicates whether the specified System.String object is
        /// null or an System.String.Empty string.
        /// </summary>
        /// <param name="s">String to evaluate.</param>
        /// <returns>Indicator of whether the string is null or empty.</returns>
        /// <example>
        ///     <code language="c#">
        ///         if (!myString.IsNullOrEmpty())
        ///         {
        ///             doStuff(myString);
        ///         }
        ///     </code>
        /// </example>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Determines if a <see cref="string">string</see> can be converted to an integer.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to examine.</param>
        /// <returns>True if the <see cref="string">string</see> is numeric.</returns>
        /// <example>
        ///     <code language="c#">
        ///         if (myString.IsNumeric())
        ///         {
        ///             int myInt = myString.ToInt32();
        ///         }
        ///     </code>
        /// </example>
        public static bool IsNumeric(this string s)
        {
            Regex regEx = new Regex("^-[0-9]+$|^[0-9]+$");

            return regEx.IsMatch(s);
        }

        /// <summary>
        /// Detects whether this instance is a valid email address.
        /// </summary>
        /// <param name="s">Email address to test.</param>
        /// <returns>True if instance is valid email address.</returns>
        /// <example>
        ///     <code language="c#">
        ///         if (TextEmail.Text.IsValidEmailAddress())
        ///         {
        ///             ProcessRegistration();
        ///         }
        ///     </code>
        /// </example>
        public static bool IsEmailAddress(this string s)
        {
            return new Regex(Configuration.EmailPattern).IsMatch(s);
        }

        /// <summary>
        /// Detects whether the supplied <see cref="string">string</see> is a valid IP address.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to inspect.</param>
        /// <returns>Results of the check.</returns>
        /// <example>
        ///     <code language="c#">
        ///         bool isValid = ipAddress.IsValidIPAddress();
        ///     </code>
        /// </example>
        public static bool IsIPAddress(this string s)
        {
            return Regex.IsMatch(s, Configuration.IPPattern);
        }

        /// <summary>
        /// Checks if url is valid.
        /// </summary>
        /// <param name="url">Url to use in the check.</param>
        /// <returns>True if the url is valid.</returns>
        /// <example>
        ///     <code language="c#">
        ///         bool isValid = TextBoxUrl.Text.IsValidUrl();
        ///     </code>
        /// </example>
        public static bool IsUrl(this string url)
        {
            return new Regex(Configuration.UrlPattern).IsMatch(url);
        }
    }
}
