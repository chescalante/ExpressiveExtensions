namespace ExpressiveExtensions.Core
{
    public static class StringAdd
    {
        /// <summary>
        /// Prepends a prefix to a <see cref="string">string</see> if it doesn't already exist.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to alter.</param>
        /// <param name="prefix">The prefix to prepend.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = " World!";
        ///         string prefix = "Hello,";
        ///         string results = s.AddPrefix(prefix); -> results in "Hello, World!"
        ///     </code>
        /// </example>
        public static string AddPrefix(this string s, string prefix)
        {
            string result = s;

            if (!result.StartsWith(prefix))
            {
                result = prefix + result;
            }

            return result;
        }

        /// <summary>
        /// Appends a suffix to a <see cref="string">string</see> if it doesn't already exist.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to alter.</param>
        /// <param name="suffix">The suffix to append.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, ";
        ///         string suffix = "World!";
        ///         string results = s.ForceSuffix(suffix); -> results in "Hello, World!"
        ///     </code>
        /// </example>
        public static string AddSuffix(this string s, string suffix)
        {
            string result = s;

            if (!result.EndsWith(suffix))
            {
                result += suffix;
            }

            return result;
        }

        /// <summary>
        /// Left pads a <see cref="string">string</see> using the supplied pad <see cref="string">string</see> for the total number of spaces.  
        /// It will not cut-off the pad even if it causes the <see cref="string">string</see> to exceed the total width.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to pad.</param>
        /// <param name="pad">The <see cref="string">string</see> to uses as padding.</param>
        /// <returns>A padded <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string pad = " How are you?";
        ///         string results = s.PadLeft(pad);
        ///     </code>
        /// </example>
        public static string PadLeft(this string s, string pad)
        {
            return s.PadLeft(pad, s.Length + pad.Length, false);
        }

        /// <summary>
        /// Left pads a <see cref="string">string</see> using the passed pad <see cref="string">string</see> for the total number of spaces.  
        /// Optionally, it will cut-off the pad so that the <see cref="string">string</see> does not exceed the total width.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to pad.</param>
        /// <param name="pad">The <see cref="string">string</see> to uses as padding.</param>
        /// <param name="totalWidth">The total number to pad the <see cref="string">string</see>.</param>
        /// <param name="cutOff">Limits overall size of <see cref="string">string</see>.</param>
        /// <returns>A padded <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string pad = " How are you?";
        ///         string actual = s.PadLeft(pad, 17, true);
        ///     </code>
        /// </example>
        public static string PadLeft(this string s, string pad, int totalWidth, bool cutOff)
        {
            if (s.Length >= totalWidth)
            {
                return s;
            }

            int padCount = pad.Length;

            string paddedString = s;

            while (paddedString.Length < totalWidth)
            {
                paddedString += pad;
            }

            // trim the excess.
            if (cutOff)
            {
                paddedString = paddedString.Substring(0, totalWidth);
            }

            return paddedString;
        }

        /// <summary>
        /// Right pads a <see cref="string">string</see> using the supplied pad <see cref="string">string</see> for the total number of spaces.  
        /// It will not cut-off the pad even if it causes the <see cref="string">string</see> to exceed the total width.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to pad.</param>
        /// <param name="pad">The <see cref="string">string</see> to uses as padding.</param>
        /// <returns>A padded <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "How are you?";
        ///         string pad = "Hello, World! ";
        ///         string results = s.PadRight(pad);
        ///     </code>
        /// </example>
        public static string PadRight(this string s, string pad)
        {
            return PadRight(s, pad, s.Length + pad.Length, false);
        }

        /// <summary>
        /// Right pads a <see cref="string">string</see> using the supplied pad <see cref="string">string</see> for the total number of spaces.  
        /// It will cut-off the pad so that the <see cref="string">string</see> does not exceed the total width.
        /// </summary>
        /// <param name="s">The <see cref="string">string</see> to pad.</param>
        /// <param name="pad">The <see cref="string">string</see> to uses as padding.</param>
        /// <param name="length">The total length to pad the <see cref="string">string</see>.</param>
        /// <param name="cutOff">Limits the overall length of the <see cref="string">string</see>.</param>
        /// <returns>A padded <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "How are you?";
        ///         string pad = "Hello, World! ";
        ///         string results = s.PadRight(pad, 17, true);
        ///     </code>
        /// </example>
        public static string PadRight(this string s, string pad, int length, bool cutOff)
        {
            if (s.Length >= length)
            {
                return s;
            }

            string paddedString = string.Empty;

            while (paddedString.Length < length - s.Length)
            {
                paddedString += pad;
            }

            // trim the excess.
            if (cutOff)
            {
                paddedString = paddedString.Substring(0, length - s.Length);
            }

            paddedString += s;

            return paddedString;
        }
    }
}
