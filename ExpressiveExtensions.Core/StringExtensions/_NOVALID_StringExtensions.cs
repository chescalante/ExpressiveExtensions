namespace ExpressiveExtensions.Core
{
    /// <summary>
    /// Contains various useful string-related extensions.
    /// </summary>
    public static class _NOVALID_StringExtensions
    {
        /// <summary>
        /// Convert a (A)RGB string to a Color object.
        /// </summary>
        /// <param name="s">An RGB or an ARGB string.</param>
        /// <returns>A Color object.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "#ffffff";
        ///         Color expected = s.ToColor();
        ///     </code>
        /// </example>
        //public static Color ToColor(this string s)
        //{
        //    s = s.Replace("#", string.Empty);

        //    byte a = System.Convert.ToByte("ff", 16);

        //    byte pos = 0;

        //    if (s.Length == 8)
        //    {
        //        a = System.Convert.ToByte(s.Substring(pos, 2), 16);
        //        pos = 2;
        //    }

        //    byte r = System.Convert.ToByte(s.Substring(pos, 2), 16);

        //    pos += 2;

        //    byte g = System.Convert.ToByte(s.Substring(pos, 2), 16);

        //    pos += 2;

        //    byte b = System.Convert.ToByte(s.Substring(pos, 2), 16);

        //    return Color.FromArgb(a, r, g, b);
        //}
    }
}
