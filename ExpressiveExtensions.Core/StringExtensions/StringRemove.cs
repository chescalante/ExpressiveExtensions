using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressiveExtensions.Core
{
    public static class StringRemove
    {
        /// <summary>
        /// Removes all the words passed in the filter words parameters. The replace is NOT case sensitive.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to search.</param>
        /// <param name="filterWords">The words to repace in the input <see cref="string">string</see>.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "This is a test sentence.";
        ///         string[] filterWords = new string[] { " is a", " sentence" };
        ///         string results = s.FilterWords(filterWords); -> results in "This test."
        ///     </code>
        /// </example>
        public static string RemoveWords(this string s, params string[] filterWords)
        {
            return s.RemoveWords(char.MinValue, filterWords);
        }

        /// <summary>
        /// Removes all the words passed in the filter words parameters using the specified mask. 
        /// The replace is NOT case sensitive.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to search.</param>
        /// <param name="mask">A character that is inserted for each letter of the replaced word.</param>
        /// <param name="filterWords">The words to repace in the input <see cref="string">string</see>.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "This is a test sentence.";
        ///         char mask = '*';
        ///         string[] filterWords = new string[] { "test" };
        ///         actual = s.FilterWords(mask, filterWords); -> results in "This is a **** sentence."
        ///     </code>
        /// </example>
        public static string RemoveWords(this string s, char mask, params string[] filterWords)
        {
            string stringMask = mask == char.MinValue ? string.Empty : mask.ToString();
            string totalMask = stringMask;

            foreach (string word in filterWords)
            {
                Regex regEx = new Regex(word, RegexOptions.IgnoreCase | RegexOptions.Multiline);

                if (stringMask.Length > 0)
                {
                    for (int i = 1; i < word.Length; i++)
                    {
                        totalMask += stringMask;
                    }
                }

                s = regEx.Replace(s, totalMask);

                totalMask = stringMask;
            }

            return s;
        }

        /// <summary>
        /// Removes duplicate words from a string.
        /// </summary>
        /// <param name="s">String to evaluate.</param>
        /// <returns>A string with duplicates removed.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string expected = "To be or not - that is the question.";
        ///         string results = s.RemoveDuplicateWords();
        ///     </code>
        /// </example>
        public static string RemoveDuplicateWords(this string s)
        {
            var d = new Dictionary<string, bool>();

            StringBuilder sb = new StringBuilder();

            string[] a = s.Split(new char[] { ' ', ',', ';', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string current in a)
            {
                string lower = current.ToLower();

                if (!d.ContainsKey(lower))
                {
                    sb.Append(current).Append(' ');
                    d.Add(lower, true);
                }
            }

            string results = sb.ToString().Trim();

            if (s.EndsWith("."))
            {
                results += ".";
            }

            if (s.EndsWith(";"))
            {
                results += ";";
            }

            if (s.EndsWith(":"))
            {
                results += ":";
            }

            if (s.EndsWith(","))
            {
                results += ",";
            }

            return results;
        }

        /// <summary>
        /// Removes the new line (\n) and carriage return (\r) symbols.
        /// </summary>
        /// <param name="s">The string to search.</param>
        /// <returns>The resulting string.</returns>
        /// <remarks>By default, does not replace the new line with a space.</remarks>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, \r\nWorld!";
        ///         string results = s.RemoveNewLines();
        ///     </code>
        /// </example>
        public static string RemoveNewLines(this string s)
        {
            return s.RemoveNewLines(false);
        }

        /// <summary>
        /// Removes the new line (\n) and carriage return (\r) symbols.  
        /// Optionally adds a space for each newline and carriage return.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to search.</param>
        /// <param name="addSpace">If true, adds a space (" ") for each newline and carriage return found.</param>
        /// <returns>The resulting string.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, \r\nWorld!";
        ///         string results = s.RemoveNewLines(true);
        ///     </code>
        /// </example>
        public static string RemoveNewLines(this string s, bool addSpace)
        {
            string replace = string.Empty;

            if (addSpace)
            {
                replace = " ";
            }

            return s.Replace(Environment.NewLine, replace);
        }

        /// <summary>
        /// Removes a prefix from a <see cref="string">string</see> if it exists.
        /// </summary>
        /// <param name="s">Input <see cref="string">string</see> to remove the prefix from.</param>
        /// <param name="prefix"><see cref="string">String</see> that defines the prefix to remove.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.RemovePrefix("Hello, ");
        ///     </code>
        /// </example>
        public static string RemovePrefix(this string s, string prefix)
        {
            return Regex.Replace(s, "^" + prefix, System.String.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Remove whitespace from within a <see cref="string">string</see>.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to remove the spaces from.</param>
        /// <returns><see cref="string">String</see> without spaces.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string phoneNumber = "555 555 5555";
        ///         string trimmed = phoneNumber.RemoveSpaces();
        ///     </code>
        /// </example>
        public static string RemoveSpaces(this string s)
        {
            return s.Replace(" ", string.Empty);
        }

        /// <summary>
        /// Removes a suffix from a <see cref="string">string</see> if it exists.
        /// </summary>
        /// <param name="s">Input <see cref="string">string</see> to remove the suffix from.</param>
        /// <param name="suffix"><see cref="string">String</see> that defines the suffix to remove.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.RemoveSuffix(", World!");
        ///     </code>
        /// </example>
        public static string RemoveSuffix(this string s, string suffix)
        {
            return Regex.Replace(s, suffix + "$", System.String.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Removes all HTML tags from the passed <see cref="string">string</see>.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> whose values should be replaced.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "&lt;body&gt;Hello, World!&lt;/body&gt;";
        ///         string results = s.StripTags();
        ///     </code>
        /// </example>
        public static string StripTags(this string s)
        {
            Regex stripTags = new Regex("<(.|\n)+?>");

            return stripTags.Replace(s, string.Empty);
        }

        /// <summary>
        /// Removes multiple spaces between words.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to trim.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello,   World!";
        ///         string trimmed = s.TrimIntraWords();
        ///     </code>
        /// </example>
        public static string TrimIntraWords(this string s)
        {
            Regex regEx = new Regex(@"[\s]+");

            return regEx.Replace(s, " ");
        }

        /// <summary>
        /// Truncates the <see cref="string">string</see> to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="s"><see cref="string">String</see> that will be truncated.</param>
        /// <param name="maxLength">Total length of characters to maintain before the truncate happens.</param>
        /// <returns>Truncated <see cref="string">string</see>.</returns>
        /// <remarks>maxLength is inclusive of the three characters in the ellipsis.</remarks>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.Truncate(5);
        ///     </code>
        /// </example>
        public static string Truncate(this string s, int maxLength)
        {
            // replaces the truncated string to a ...
            string suffix = "...";

            string truncatedString = s;

            if (maxLength <= 0)
            {
                return truncatedString;
            }

            int strLength = maxLength - suffix.Length;

            if (strLength <= 0)
            {
                return truncatedString;
            }

            if (s == null || s.Length <= maxLength)
            {
                return truncatedString;
            }

            truncatedString = s.Substring(0, strLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;

            return truncatedString;
        }
    }
}
