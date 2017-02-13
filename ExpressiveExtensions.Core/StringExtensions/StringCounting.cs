using System.Text.RegularExpressions;

namespace ExpressiveExtensions.Core
{
    public static class StringCounting
    {
        /// <summary>
        /// Gets the number of instances of specified character in the <see cref="string">string</see>.
        /// </summary>
        /// <param name="value">The <see cref="String">String</see> to evaulate.</param>
        /// <param name="character">The value to look for in the <paramref name="value">value</paramref>.</param>
        /// <returns>The number of instances of the specified character in the specified <see cref="string">string</see>.</returns>
        /// <example>
        ///   <code language="c#">
        ///     string value = "Hello, World!";
        ///     string character = "l";
        ///     int charCount = value.CharacterInstanceCount(character);
        ///   </code>
        /// </example>
        public static int CharacterInstanceCount(this string value, string character)
        {
            int intReturnValue = 0;

            for (int intCharacter = 0; intCharacter <= (value.Length - 1); intCharacter++)
            {
                if (value.Substring(intCharacter, 1) == character)
                {
                    intReturnValue += 1;
                }
            }

            return intReturnValue;
        }

        /// <summary>
        /// Counts all words in a given <see cref="string">string</see>.  Excludes whitespaces, tabs and line breaks.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to inspect.</param>
        /// <returns>The number of words in the <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         int count = s.WordCount();    
        ///     </code>
        /// </example>
        public static int WordCount(this string s)
        {
            var count = 0;

            var re = new Regex(@"[^\s]+");
            var matches = re.Matches(s);
            count = matches.Count;

            return count;
        }

        /// <summary>
        /// Calculates the number of times a word exists withing a <see cref="string">string</see>.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to evaluate.</param>
        /// <param name="word">Word to search for.</param>
        /// <returns>Number of times the word exists within the <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World! How are you doing today?";
        ///         string word = "How";
        ///         int count = s.WordInstanceCount(word);
        ///     </code>
        /// </example>
        public static int WordInstanceCount(this string s, string word)
        {
            Regex r = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
            MatchCollection mc = r.Matches(s);
            return mc.Count;
        }
    }
}
