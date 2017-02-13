using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ExpressiveExtensions.Core
{
    public static class StringCryptography
    {
        /// <summary>
        /// Encryptes a <see cref="string">string</see> using the supplied key. Encoding is done using Aes encryption.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> that must be encrypted.</param>
        /// <param name="key">Encryption key.</param>
        /// <returns>A string representing a byte array separated by a minus sign.</returns>
        /// <exception cref="ArgumentException">Occurs when the <see cref="string">string</see> or key is null or empty.</exception>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string key = "mykey";
        ///         string encrypted = s.Encrypt(key);
        ///         string decrypted = encrypted.Decrypt(key);
        ///     </code>
        /// </example>
        public static string EncryptWithAes(this string s, string key)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");
            }

            var keyResult = Encoding.UTF8.GetBytes(key);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(keyResult, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(s);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        /// <summary>
        /// Decryptes a <see cref="string">string</see> using the supplied key. Decoding is done using Aes encryption.
        /// </summary>
        /// <param name="s"><see cref="string">String</see> that must be decrypted.</param>
        /// <param name="key">Decryption key.</param>
        /// <returns>The decrypted <see cref="string">string</see> or null if decryption failed.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string key = "mykey";
        ///         string encrypted = s.Encrypt(key);
        ///         string decrypted = encrypted.Decrypt(key);
        ///     </code>
        /// </example>
        public static string DecryptWithAes(this string s, string key)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("An empty string value cannot be encrypted.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");
            }

            var fullCipher = Convert.FromBase64String(s);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var keyResult = Encoding.UTF8.GetBytes(key);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(keyResult, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
