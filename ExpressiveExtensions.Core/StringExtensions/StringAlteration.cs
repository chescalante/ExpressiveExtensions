using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressiveExtensions.Core
{
    public static class StringAlteration
    {
        /// <summary>
        /// Retrieves the left x characters of a <see cref="string">string</see>.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to examine.</param>
        /// <param name="count">The number of characters to retrieve.</param>
        /// <returns>The resulting substring.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         int charCount = 5;
        ///         string result = s.Left(charCount); // results in "Hello"
        ///     </code>
        /// </example>
        public static string Left(this string s, int count)
        {
            return s.Substring(0, count);
        }

        /// <summary>
        /// Retrieves a section of a string.
        /// </summary>
        /// <param name="s">The string to examine.</param>
        /// <param name="index">The start index of the substring.</param>
        /// <param name="count">The number of characters to retrieve.</param>
        /// <returns>The resulting substring.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.Mid(2, 4);
        ///     </code>
        /// </example>
        public static string Mid(this string s, int index, int count)
        {
            return s.Substring(index, count);
        }

        /// <summary>
        /// A case insenstive replace function.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to examine.</param>
        /// <param name="oldString">The new value to be inserted.</param>
        /// <param name="newString">The value to replace.</param>
        /// <param name="caseSensitive">Determines whether or not to ignore case.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.Replace("world", "Dude", false);
        ///     </code>
        /// </example>
        public static string Replace(this string s, string oldString, string newString, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return s.Replace(oldString, newString);
            }
            else
            {
                Regex regEx = new Regex(oldString, RegexOptions.IgnoreCase | RegexOptions.Multiline);

                return regEx.Replace(s, newString);
            }
        }

        /// <summary>
        /// Reverses a <see cref="string">string</see>.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to reverse.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.Reverse();
        ///     </code>
        /// </example>
        public static string Reverse(this string s)
        {
            if (s.Length <= 1)
            {
                return s;
            }

            char[] c = s.ToCharArray();

            StringBuilder sb = new StringBuilder(c.Length);

            for (int i = c.Length - 1; i > -1; i--)
            {
                sb.Append(c[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Retrieves the right x characters of a <see cref="string">string</see>.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to examine.</param>
        /// <param name="count">The number of characters to retrieve.</param>
        /// <returns>The resulting substring.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.Right(6);
        ///     </code>
        /// </example>
        public static string Right(this string s, int count)
        {
            return s.Substring(s.Length - count, count);
        }

        /// <summary>
        /// Retrieves a section of a string by using start and end indexes.
        /// </summary>
        /// <param name="s">The string to examine.</param>
        /// <param name="startIndex">The start index of the substring.</param>
        /// <param name="endIndex">The end index of the substring.</param>
        /// <returns>The resulting substring.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.Slice(0, 5);
        ///     </code>
        /// </example>
        public static string Slice(this string s, int startIndex, int endIndex)
        {
            return s.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Splits a <see cref="string">string</see> into an array by delimiter.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to split.</param>
        /// <param name="delimiter">Delimiter <see cref="string">string</see>.</param>
        /// <returns>Array of strings.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "one, two, three";
        ///         string[] results = s.Split(",");
        ///     </code>
        /// </example>
        public static string[] Split(this string s, string delimiter)
        {
            return s.Split(delimiter.ToCharArray());
        }

        /// <summary>
        /// Splits a <see cref="string">string</see> into an array by delimiter.
        /// Optionally allows for the trimming of each token during the split.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to split.</param>
        /// <param name="delimiter">Delimiter <see cref="string">string</see>.</param>
        /// <param name="trimTokens">Specifies whether to trim each item in the array during the split.</param>
        /// <returns>Array of strings.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "one, two, three";
        ///         string[] results = s.Split(",", true);
        ///     </code>
        /// </example>
        public static string[] Split(this string s, string delimiter, bool trimTokens)
        {
            if (trimTokens)
            {
                string[] results = s.Split(delimiter.ToCharArray());

                for (int i = 0; i < results.Length; i++)
                {
                    results[i] = results[i].Trim();
                }

                return results;
            }
            else
            {
                return s.Split(delimiter.ToCharArray());
            }
        }

        /// <summary>
        /// Wraps the passed <see cref="string">string</see> up the total number of characters until the next whitespace on or after 
        /// the total character count has been reached for that line.  
        /// Uses the environment new line symbol for the break text.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to wrap.</param>
        /// <param name="charCount">The number of characters per line.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World! How are you doing today?";
        ///         string results = s.WordWrap(9);
        ///     </code>
        /// </example>
        public static string WordWrap(this string s, int charCount)
        {
            return WordWrap(s, charCount, false, Environment.NewLine);
        }

        /// <summary>
        /// Wraps the passed <see cref="string">string</see> up the total number of characters (if cutOff is true)
        /// or until the next whitespace (if cutOff is false).  Uses the environment new line
        /// symbol for the break text.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to wrap.</param>
        /// <param name="charCount">The number of characters per line.</param>
        /// <param name="cutOff">If true, will break in the middle of a word.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World! How are you doing today?";
        ///         string results = s.WordWrap(9, false);
        ///     </code>
        /// </example>
        public static string WordWrap(this string s, int charCount, bool cutOff)
        {
            return WordWrap(s, charCount, cutOff, Environment.NewLine);
        }

        /// <summary>
        /// Wraps the passed <see cref="string">string</see> up the total number of characters (if cutOff is true)
        /// or until the next whitespace (if cutOff is false).  Uses the supplied breakText
        /// for line breaks.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to wrap.</param>
        /// <param name="charCount">The number of characters per line.</param>
        /// <param name="cutOff">If true, will break in the middle of a word.</param>
        /// <param name="breakText">The line break text to use.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World! How are you doing today?";
        ///         string results = s.WordWrap(9, false, Environment.NewLine);
        ///     </code>
        /// </example>
        public static string WordWrap(this string s, int charCount, bool cutOff, string breakText)
        {
            StringBuilder sb = new StringBuilder(s.Length + 100);
            int counter = 0;

            if (cutOff)
            {
                while (counter < s.Length)
                {
                    if (s.Length > counter + charCount)
                    {
                        sb.Append(s.Substring(counter, charCount));
                        sb.Append(breakText);
                    }
                    else
                    {
                        sb.Append(s.Substring(counter));
                    }

                    counter += charCount;
                }
            }
            else
            {
                string[] strings = s.Split(' ');

                for (int i = 0; i < strings.Length; i++)
                {
                    counter += strings[i].Length + 1;

                    if (i != 0 && counter > charCount)
                    {
                        sb.Append(breakText);
                        counter = 0;
                    }

                    sb.Append(strings[i] + ' ');
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
