using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExpressiveExtensions.Core
{
    public static class StringLocating
    {
        /// <summary>
        /// An overload of the built-in .NET String.Contains() method, this method determines whether a substring exists 
        /// within a <see cref="string">string</see> in an optionally case-insensitive way.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to search.</param>
        /// <param name="subString">Substring to match when searching.</param>
        /// <param name="caseSensitive">Determines whether or not to ignore case.</param>
        /// <returns>Indicator of substring presence within the <see cref="string">string</see>.</returns>
        /// <example>
        ///   <code language="c#">
        ///     string s = "Hello, World!";
        ///     bool valid = s.Contains("hello", true); -> returns false
        ///   </code>
        /// </example>
        public static bool Contains(this string s, string subString, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return s.Contains(subString);
            }
            else
            {
                return s.IndexOf(subString, 0, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        /// <summary>
        /// Checks the passed <see cref="string">string</see> to see if has any of the passed words. Not case-sensitive.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to check.</param>
        /// <param name="wordArray">The words to check for.</param>
        /// <returns>A collection of the matched words.</returns>
        /// <example>
        ///   <code language="c#">
        ///   string s = "This is a test sentence.";
        ///   string[] wordArray = new string[] { "test", "sentence" };
        ///   MatchCollection actual = s.ContainsWords(wordArray);
        ///   foreach (Match match in actual)
        ///   {
        ///     GroupCollection groups = match.Groups;
        ///     if (groups[0].Success == true)
        ///     {
        ///         Console.WriteLine("Found a match at index: " + groups[0].Index);
        ///     }
        ///   }
        ///   </code>
        /// </example>
        public static MatchCollection ContainsWords(this string s, params string[] wordArray)
        {
            var pattern = string.Join("({0})|", wordArray);

            Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            return regEx.Matches(s);
        }

        /// <summary>
        /// Finds strings that exist between the indicated start and end <see cref="string">string</see> patterns.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to evaluate.</param>
        /// <param name="startString"><see cref="string">String</see> that should precede the match.</param>
        /// <param name="endString"><see cref="string">String</see> that should follow the match.</param>
        /// <returns>Match collection of found strings.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, <span>World</span>!";
        ///         string startString = "<span>";
        ///         string endString = "</span>";
        ///         MatchCollection matches = s.FindBetween(startString, endString);
        ///         string firstMatch;
        ///         if (matches.Count > 0)
        ///         {
        ///             firstMatch = matches[0].ToString();
        ///         }
        ///     </code>
        /// </example>
        public static MatchCollection FindBetween(this string s, string startString, string endString)
        {
            return s.FindBetween(startString, endString, true);
        }

        /// <summary>
        /// Finds strings that exist between the indicated start and end <see cref="string">string</see> patterns.  Optionally recursive - if true,
        /// finds the last instance of the start <see cref="string">string</see> before the end <see cref="string">string</see> prior to retrieving the results.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to evaluate.</param>
        /// <param name="startString"><see cref="string">String</see> that should precede the match.</param>
        /// <param name="endString"><see cref="string">String</see> that should follow the match.</param>
        /// <param name="recursive">If true, finds the last instance of the start <see cref="string">string</see>.  Otherwise it uses the first instance.</param>
        /// <returns>Match collection of found strings.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, <span>World</span>!";
        ///         string startString = "<span>";
        ///         string endString = "</span>";
        ///         MatchCollection matches = s.FindBetween(startString, endString, true);
        ///         string firstMatch;
        ///         if (matches.Count > 0)
        ///         {
        ///             firstMatch = matches[0].ToString();
        ///         }
        ///     </code>
        /// </example>
        public static MatchCollection FindBetween(this string s, string startString, string endString, bool recursive)
        {
            MatchCollection matches;

            startString = Regex.Escape(startString);
            endString = Regex.Escape(endString);

            Regex regex = new Regex("(?<=" + startString + ").*(?=" + endString + ")");

            matches = regex.Matches(s);

            if (!recursive)
            {
                return matches;
            }

            if (matches.Count > 0)
            {
                if (matches[0].ToString().IndexOf(Regex.Unescape(startString)) > -1)
                {
                    s = matches[0].ToString() + Regex.Unescape(endString);

                    return s.FindBetween(Regex.Unescape(startString), Regex.Unescape(endString));
                }
                else
                {
                    return matches;
                }
            }
            else
            {
                return matches;
            }
        }

        /// <summary>
        /// Determines whether the beginning of this instance matches any of the specified strings.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to inspect.</param>
        /// <param name="values">The strings to compare.</param>
        /// <returns>Indicator of presence of any of the supplied values at the beginning of the <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         List&lt;string&gt; values = new List&lt;string&gt;();
        ///         values.Add("Goodbye");
        ///         values.Add("Hello");
        ///         bool results = s.StartsWithAny(values);
        ///     </code>
        /// </example>
        public static bool StartsWithAny(this string s, List<string> values)
        {
            return s.StartsWithAny(values, true);
        }

        /// <summary>
        /// Determines whether the beginning of this instance matches any of the specified strings.  
        /// Optionally allows for case ignorance.
        /// </summary>
        /// <param name="s"><see cref="string">string</see> to inspect.</param>
        /// <param name="values">The strings to compare.</param>
        /// <param name="ignoreCase">True to ignore case when comparing this <see cref="string">string</see> and value.  Otherwise false.</param>
        /// <returns>Indicator of presence of any of the supplied values at the beginning of the <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         List&lt;string&gt; values = new List&lt;string&gt;();
        ///         values.Add("Goodbye");
        ///         values.Add("Hello");
        ///         bool results = s.StartsWithAny(values, true);
        ///     </code>
        /// </example>
        public static bool StartsWithAny(this string s, List<string> values, bool ignoreCase)
        {
            return s.StartsWithAny(values, ignoreCase, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Determines whether the beginning of this instance matches any of the specified strings.
        /// Optionally allows the culture to be specified.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to inspect.</param>
        /// <param name="values">The strings to compare.</param>
        /// <param name="ignoreCase">True to ignore case when comparing this <see cref="string">string</see> and value.  Otherwise false.</param>
        /// <param name="culture">Culteral information that determines how this <see cref="string">string</see> and value are compared.</param>
        /// <returns>Indicator of presence of any of the supplied values at the beginning of the <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         List&lt;string&gt; values = new List&lt;string&gt;();
        ///         values.Add("Goodbye");
        ///         values.Add("Hello");
        ///         bool results = s.StartsWithAny(values, true, CultureInfo.CurrentCulture);
        ///     </code>
        /// </example>
        public static bool StartsWithAny(this string s, List<string> values, bool ignoreCase, CultureInfo culture)
        {
            if (values == null || values.Count == 0)
            {
                throw new ArgumentException("An empty values cannot be located.");
            }

            var pattern = "^" + string.Join("|^", values);

            var options = RegexOptions.Multiline;
            if (ignoreCase)
                options |= RegexOptions.IgnoreCase;

            Regex regEx = new Regex(pattern, options);

            return regEx.IsMatch(s);
        }

        /// <summary>
        /// Determines whether the ending of this instance matches any of the specified strings.  Case sensitive.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to inspect.</param>
        /// <param name="values">The <see cref="string">string</see> instances to compare.</param>
        /// <returns>Indicator of presence of any of the supplied values at the end of the <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         List&lt;string&gt; values = new List&lt;string&gt;();
        ///         values.AddRange("hello", "!", "World");
        ///         bool result = s.EndsWithAny(values);
        ///     </code>
        /// </example>
        public static bool EndsWithAny(this string s, List<string> values)
        {
            return s.EndsWithAny(values, true);
        }

        /// <summary>
        /// Determines whether the ending of this <see cref="string">string</see> instance matches any of the specified strings.  
        /// Optionally allows case sensitivity to be specified.
        /// </summary>
        /// <param name="s">String to inspect.</param>
        /// <param name="values">The System.Strings to compare.</param>
        /// <param name="ignoreCase">True to ignore case when comparing this string and value.  Otherwise false.</param>
        /// <returns>Indicator of presence of any of the supplied values at the end of the string.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         List&lt;string&gt; values = new List&lt;string&gt;();
        ///         values.AddRange("hello", "!", "World");
        ///         bool result = s.EndsWithAny(values, false);
        ///     </code>
        /// </example>
        public static bool EndsWithAny(this string s, List<string> values, bool ignoreCase)
        {
            return s.EndsWithAny(values, ignoreCase, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Determines whether the ending of this <see cref="string">string</see> instance matches any of the specified strings. 
        /// Optionally allows case sensitivity to be specified. 
        /// Optionally allows the culture to be specified.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to inspect.</param>
        /// <param name="values">The System.Strings to compare.</param>
        /// <param name="ignoreCase">True to ignore case when comparing this string and value.  Otherwise false.</param>
        /// <param name="culture">Culteral information that determines how this string and value are compared.</param>
        /// <returns>Indicator of presence of any of the supplied values at the end of the string.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         List&lt;string&gt; values = new List&lt;string&gt;();
        ///         values.AddRange("hello", "!", "World");
        ///         bool result = s.EndsWithAny(values, true, CultureInfo.CurrentCulture);
        ///     </code>
        /// </example>
        public static bool EndsWithAny(this string s, List<string> values, bool ignoreCase, CultureInfo culture)
        {
            if (values == null || values.Count == 0)
            {
                throw new ArgumentException("An empty values cannot be located.");
            }

            var pattern = string.Join("$|", values) + "$";

            var options = RegexOptions.Multiline;
            if (ignoreCase)
                options |= RegexOptions.IgnoreCase;

            Regex regEx = new Regex(pattern, options);

            return regEx.IsMatch(s);
        }
    }
}
