using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressiveExtensions.Core
{
    public static class StringFormatting
    {
        /// <summary>
        /// Attempts to format a phone number to a (xxx) xxx-xxxx format.
        /// </summary>
        /// <param name="value">The phone number to format.</param>
        /// <returns>The formatted phone number.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string formatted = "4065557485".FormatPhoneNumber();
        ///     </code>
        /// </example>
        public static string FormatPhoneNumber(this string value)
        {
            string strReturnValue = string.Empty;

            if (value.Contains("(") == false && value.Contains(")") == false && value.Contains("-") == false)
            {
                if (value.Length == 7)
                {
                    strReturnValue = value.Substring(0, 3) + "-" + value.Substring(3, 4);
                }
                else if (value.Length == 10)
                {
                    strReturnValue = "(" + value.Substring(0, 3) + ") " + value.Substring(3, 3) + "-" + value.Substring(6, 4);
                }
                else if (value.Length > 10)
                {
                    string strExtensionFormat = string.Empty.PadLeft(value.Length - 10, Convert.ToChar("#"));

                    strReturnValue = "(" + value.Substring(0, 3) + ") " + value.Substring(3, 3) + "-" + value.Substring(6, 4) + " x" + value.Substring(10);
                }
            }
            else
            {
                strReturnValue = value;
            }

            return strReturnValue;
        }

        /// <summary>
        /// Use the passed <see cref="string">string</see> as format for the supplied <see cref="string">values</see>
        /// </summary>
        /// <param name="s">The format.</param>
        /// <param name="values"><see cref="string">Values</see> to apply on format.</param>
        /// <returns>The formatted text.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string formatted = "Hi!, my name is {0}.".Format("John Doe"); -> results in "Hi!, my name is John Doe."
        ///     </code>
        /// </example>
        public static string Format(this string s, params string[] values)
        {
            return string.Format(s, values);
        }

        /// <summary>
        /// Converts a <see cref="string">string</see> to sentence case.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to convert.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "This Is Just a Test.";
        ///         string results = s.SentenceCase();
        ///     </code>
        /// </example>
        public static string SentenceCase(this string s)
        {
            if (s.Length < 1)
            {
                return s;
            }

            string sentence = s.ToLower();

            return sentence[0].ToString().ToUpper() + sentence.Substring(1);
        }

        /// <summary>
        /// Converts a <see cref="string">string</see> to title case.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to convert.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "On the waterfront";
        ///         string title = s.TitleCase();
        ///     </code>
        /// </example>
        public static string TitleCase(this string s)
        {
            return TitleCase(s, true);
        }

        /// <summary>
        /// Converts a <see cref="string">string</see> to title case.
        /// Optionally allows short words to be ignored.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to convert.</param>
        /// <param name="ignoreShortWords">If true, does not capitalize words like
        /// "a", "is", "the", etc.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "On the waterfront";
        ///         string title = s.TitleCase(false);
        ///     </code>
        /// </example>
        public static string TitleCase(this string s, bool ignoreShortWords)
        {
            List<string> ignoreWords = null;

            if (ignoreShortWords)
            {
                ignoreWords = new List<string>();
                ignoreWords.Add("a");
                ignoreWords.Add("is");
                ignoreWords.Add("was");
                ignoreWords.Add("the");
            }

            string[] tokens = s.Split(' ');

            StringBuilder sb = new StringBuilder(s.Length);

            foreach (string token in tokens)
            {
                if (ignoreShortWords == true
                    && token != tokens[0]
                    && ignoreWords.Contains(token.ToLower()))
                {
                    sb.Append(token + " ");
                }
                else
                {
                    sb.Append(token[0].ToString().ToUpper());
                    sb.Append(token.Substring(1).ToLower());
                    sb.Append(" ");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
