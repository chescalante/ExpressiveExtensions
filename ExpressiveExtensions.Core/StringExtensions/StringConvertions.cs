using System;
using System.Text;

namespace ExpressiveExtensions.Core
{
    public static class StringConvertions
    {
        ///// <summary>
        ///// Base64 decodes a <see cref="string">string</see>.
        ///// </summary>
        ///// <param name="s">A base64 encoded <see cref="string">string</see>.</param>
        ///// <returns>A decoded <see cref="string">string</see>.</returns>
        ///// <example>
        /////   <para>The following example encodes a <see cref="string">string</see> and decodes it back to its original value.</para>
        /////   <code language="c#">
        /////     string encoded = "Hello, World!".Base64Encode();   
        /////     string decoded = encoded.Base64Decode();
        /////   </code>
        ///// </example>
        //public static string ToBase64Decode(this string s)
        //{
        //    byte[] decbuff = Convert.FromBase64String(s);

        //    return Encoding.UTF8.GetString(decbuff);
        //}

        ///// <summary>
        ///// Base64 encodes a <see cref="string">string</see>.
        ///// </summary>
        ///// <param name="s">An input <see cref="string">string</see>.</param>
        ///// <returns>A base64 encoded <see cref="string">string</see>.</returns>
        ///// <example>
        /////   <para>The following example encodes a <see cref="string">string</see> and decodes it back to its original value.</para>
        /////   <code language="c#">
        /////     string encoded = "Hello, World!".Base64Encode();   
        /////     string decoded = encoded.Base64Decode();
        /////   </code>
        ///// </example>
        //public static string ToBase64Encode(this string s)
        //{
        //    byte[] encbuff = Encoding.UTF8.GetBytes(s);

        //    return Convert.ToBase64String(encbuff);
        //}

        /// <summary>
        /// Converts the supplied <paramref name="Value">value</paramref> to an <see cref="Boolean">Boolean</see>.
        /// </summary>
        /// <param name="value">The <see cref="string">string</see> value to convert.</param>
        /// <returns>The resulting <see cref="Boolean">Boolean</see> value.</returns>
        /// <remarks>If an error occurs while converting the value (ie the <see cref="string">string</see> value does not convert to a boolean value), <c>false</c> will be returned.</remarks>
        /// <example>
        ///     <code language="c#">
        ///         string s = "False";
        ///         bool results = s.ToBoolean();     
        ///     </code>
        /// </example>
        public static bool ToBoolean(this string value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///// <summary>
        ///// Returns a byte array of a specified <see cref="string">string</see>.
        ///// </summary>
        ///// <param name="text">The text to go into the byte array.</param>
        ///// <returns>A byte array of text.</returns>
        ///// <example>
        /////     <code language="c#">
        /////         string s = "Hello, World!";
        /////         byte[] converted = s.ToByteArray();
        /////     </code>
        ///// </example>
        //public static byte[] ToByteArray(this string text)
        //{
        //    return Encoding.ASCII.GetBytes(text);
        //}

        /// <summary>
        /// Converts the supplied <paramref name="value">value</paramref> to a <see cref="Decimal">Decimal</see>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The resulting <see cref="Decimal">Decimal</see> value.</returns>
        /// <example>
        ///     <code language="c#">
        ///         Decimal result = "5".ToDecimal();
        ///     </code>
        /// </example>
        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value) == true || (value == null) == true || value.IsNumeric() == false)
            {
                return 0;
            }
            else
            {
                return System.Convert.ToDecimal(value);
            }
        }

        /// <summary>
        /// Converts the supplied <paramref name="Value">value</paramref> to an <see cref="Int16">Int16</see>.
        /// </summary>
        /// <param name="value">The <see cref="string">string</see> value to convert.</param>
        /// <returns>The resulting <see cref="Int16">Int16</see> value.</returns>
        /// <example>
        ///     <code language="c#">
        ///         int number = "5".ToInt16();
        ///     </code>
        /// </example>
        public static short ToInt16(this string value)
        {
            if (string.IsNullOrEmpty(value) == true || (value == null) == true || value.IsNumeric() == false)
            {
                return System.Convert.ToInt16(0);
            }
            else
            {
                return System.Convert.ToInt16(value);
            }
        }

        /// <summary>
        /// Converts the supplied <paramref name="value">value</paramref> to an <see cref="Int32">Int32.</see>
        /// </summary>
        /// <param name="value">The <see cref="string">string</see> value to convert.</param>
        /// <returns>The resulting Integer.</returns>
        /// <example>
        ///     <code language="c#">
        ///         int number = "5".ToInt32();
        ///     </code>
        /// </example>
        public static int ToInt32(this string value)
        {
            if (string.IsNullOrEmpty(value) == true || (value == null) == true || value.IsNumeric() == false)
            {
                return System.Convert.ToInt32(0);
            }
            else
            {
                return System.Convert.ToInt32(value);
            }
        }

        /// <summary>
        /// Converts the supplied <paramref name="Value">value</paramref> to an <see cref="Int64">Int64</see>.
        /// </summary>
        /// <param name="value">The <see cref="string">string</see> value to convert.</param>
        /// <returns>The resulting <see cref="Int64">Int64</see> value.</returns>
        /// <example>
        ///     <code language="c#">
        ///         int number = "294967295".ToInt64();
        ///     </code>
        /// </example>
        public static long ToInt64(this string value)
        {
            if (string.IsNullOrEmpty(value) == true || (value == null) == true || value.IsNumeric() == false)
            {
                return System.Convert.ToInt64(0);
            }
            else
            {
                return System.Convert.ToInt64(value);
            }
        }

        /// <summary>
        /// Replaces underscores with a space.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to examine.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello_World!_How_are_you_today?";
        ///         string results = s.SlugDecode();
        ///     </code>
        /// </example>
        public static string ToSlugDecode(this string s)
        {
            return s.Replace("_", " ");
        }

        /// <summary>
        /// Replaces spaces with a underscores.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> to examine.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello World! How are you today?";
        ///         string results = s.SlugEncode();
        ///     </code>
        /// </example>
        public static string ToSlugEncode(this string s)
        {
            return s.Replace(" ", "_");
        }
    }
}
