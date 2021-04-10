using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolManagementSystem.Domain.Utilities
{


    //public class EncryptionHelper 
    //{
    //    private const string Password = @"505AFBC175E7264EAF2CF3A3325F24864FDA1032B01ED7FA";
    //    private static readonly byte[] RgbSalt = Encoding.Unicode.GetBytes(Password.Length.ToString());
    //    private readonly static PasswordDeriveBytes BytesEncryptor = new PasswordDeriveBytes(Password, RgbSalt);
    //    private readonly static PasswordDeriveBytes BytesDecryptor = new PasswordDeriveBytes(Password, RgbSalt);
    //    private readonly static RijndaelManaged RijndaelManagedEncryptor = new RijndaelManaged();
    //    private readonly static RijndaelManaged RijndaelManagedDecryptor = new RijndaelManaged();
    //    private static readonly ICryptoTransform CryptoTransformEncryptor = RijndaelManagedEncryptor.CreateEncryptor(BytesEncryptor.GetBytes(0x20), BytesEncryptor.GetBytes(0x10));
    //    private static readonly ICryptoTransform CryptoTransformDecryptor = RijndaelManagedDecryptor.CreateDecryptor(BytesDecryptor.GetBytes(0x20), BytesDecryptor.GetBytes(0x10));
    //    private const int SaltSize = 4;

 
 
        
    //    public static string Encrypt(string input)
    //    {
           

    //        return EncryptAES(input);
    //    }

    //    public static string Decrypt(string input)
    //    {
    //        return DecryptAES(input);
    //    }

    //    private static string EncryptAES(string inputText)
    //    {
    //        using (var stream = new MemoryStream())
    //        using (var stream2 = new CryptoStream(stream, CryptoTransformEncryptor, CryptoStreamMode.Write))
    //        {
    //            var buffer = Encoding.Unicode.GetBytes(inputText);
    //            // Appending salt bytes to original bytes
    //            byte[] rgbSalt = GetRandomBytes(SaltSize);
    //            byte[] bytesToBeEncrypted = new byte[rgbSalt.Length + buffer.Length];
    //            Buffer.BlockCopy(rgbSalt, 0, bytesToBeEncrypted, 0, rgbSalt.Length);
    //            Buffer.BlockCopy(buffer, 0, bytesToBeEncrypted, rgbSalt.Length, buffer.Length);
    //            stream2.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
    //            stream2.FlushFinalBlock();
    //            return HttpServerUtility.UrlTokenEncode(stream.ToArray());
    //        }
    //    }

    //    private static string DecryptAES(string inputText)
    //    {
    //        var buffer = HttpServerUtility.UrlTokenDecode(inputText);
    //        using (var stream = new MemoryStream(buffer))
    //        using (var stream2 = new CryptoStream(stream, CryptoTransformDecryptor, CryptoStreamMode.Read))
    //        {
    //            var buffer2 = new byte[buffer.Length];
    //            stream2.Read(buffer2, 0, buffer2.Length);
    //            return Encoding.Unicode.GetString(buffer2, SaltSize, buffer2.Length - SaltSize);
    //        }
    //    }


    //    public static byte[] GetRandomBytes(int length)
    //    {
    //        byte[] ba = new byte[length];
    //        RNGCryptoServiceProvider.Create().GetBytes(ba);
    //        return ba;
    //    }
    //}

    public enum EncryptionModes
	{
		/// <summary>
		/// Every times output will be different and User Session will not be validation.
		/// </summary>
		ConstantSaltNoneUserSessionNone,
		/// <summary>
		/// Every times output will be different and User Session will be validated.
		/// </summary>
		ConstantSaltNoneUserSession,
		/// <summary>
		/// Every times output will be same and User Session will not be validation.
		/// </summary>
		ConstantSaltUserSessionNone,
		/// <summary>
		/// Every times output will be same and User Session will be validated.
		/// </summary>
		ConstantSaltUserSession,
	}

    public static class EncryptionHelper
    {
        private static class PasswordHash
        {
            private const int SALT_BYTE_SIZE = 24;
            private const int HASH_BYTE_SIZE = 24;
            private const int PBKDF2_ITERATIONS = 1000;
            private const int ITERATION_INDEX = 0;
            private const int SALT_INDEX = 1;
            private const int PBKDF2_INDEX = 2;

            public static string CreateHash(string password)
            {
                var csprng = new RNGCryptoServiceProvider();
                var salt = new byte[SALT_BYTE_SIZE];
                csprng.GetBytes(salt);

                byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
                return PBKDF2_ITERATIONS + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
            }

            public static bool ValidatePassword(string password, string correctHash)
            {
                char[] delimiter = { ':' };
                string[] split = correctHash.Split(delimiter);
                int iterations = Int32.Parse(split[ITERATION_INDEX]);
                byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
                byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
                byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
                return SlowEquals(hash, testHash);
            }

            private static bool SlowEquals(byte[] a, byte[] b)
            {
                uint diff = (uint)a.Length ^ (uint)b.Length;
                for (int i = 0; i < a.Length && i < b.Length; i++)
                    diff |= (uint)(a[i] ^ b[i]);
                return diff == 0;
            }

            private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt))
                {
                    pbkdf2.IterationCount = iterations;
                    return pbkdf2.GetBytes(outputBytes);
                }
            }
        }

        public static string EncryptPassword(this string password)
        {
            return PasswordHash.CreateHash(password);
        }

        public static bool CheckPassword(this string plainPassword, string hashedPassword)
        {
            try { return PasswordHash.ValidatePassword(plainPassword, hashedPassword); }
            catch { return false; }
        }

        private static readonly byte[] Key = { 0xD9, 0x11, 0x1D, 0x1E, 0xC8, 0xB4, 0x71, 0x4B, 0x44, 0x1, 0x6B, 0x92, 0x20, 0x8D, 0xD7, 0xFC, 0x47, 0xDB, 0x36, 0xE9, 0xF5, 0x42, 0x98, 0x82, 0x3C, 0x22, 0xDD, 0x86, 0x7C, 0x9B, 0xFA, 0x5A, };
        private static readonly byte[] IV = { 0x3D, 0x7F, 0x60, 0x7E, 0x22, 0xDE, 0x8, 0x26, 0x1B, 0x7B, 0xE9, 0x3C, 0x5D, 0x7B, 0x11, 0xD2, };
        private static readonly AesManaged AesAlgorithm = new AesManaged();
        private static readonly ICryptoTransform Encryptor = AesAlgorithm.CreateEncryptor(EncryptionHelper.Key, EncryptionHelper.IV);
        private static readonly ICryptoTransform Decryptor = AesAlgorithm.CreateDecryptor(EncryptionHelper.Key, EncryptionHelper.IV);
        private static readonly int SaltLength = 4;
        private static readonly string ConstantSalt = "1234";
        private static readonly int GuidLength = Guid.Empty.ToString("D").Length;

        private static byte[] _Encrypt(this string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, Encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }
                var encrypted = msEncrypt.ToArray();
                return encrypted;
            }
        }

        private static string _Decrypt(this byte[] cipherText)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            using (var msDecrypt = new MemoryStream(cipherText))
            using (var csDecrypt = new CryptoStream(msDecrypt, Decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new StreamReader(csDecrypt))
            {
                var plaintext = srDecrypt.ReadToEnd();
                return plaintext;
            }
        }

        private const string SessionIDForEncryption = "$SessionIDForEncryption$";

        public static void InitializeSessionIDForEncryption(Guid guid)//Call this function when session is created so that it is initialized for user. otherwise exception will be thrown.
        {
            HttpContext.Current.Session[SessionIDForEncryption] = guid;
        }

        private static Guid CurrentUserSessionGuid
        {
            get
            {
                try
                {
                    return (Guid)HttpContext.Current.Session[SessionIDForEncryption];
                }
                catch
                {
                    var httpContext = HttpContext.Current;
                    if (httpContext == null)
                        throw new InvalidOperationException("HttpContext is null.");
                    var session = httpContext.Session;
                    if (session == null)
                        throw new InvalidOperationException("HttpContext.Current.Session is null.");
                    var guid = (Guid?)HttpContext.Current.Session[SessionIDForEncryption];
                    if (guid == null)
                        throw new InvalidOperationException("SessionIDForEncryption is null.");
                    throw new InvalidOperationException();
                }
            }
        }

        private static string _Encrypt(this string plainText, EncryptionModes encryptionModes)
        {
            string salt;
            Guid guid;
            switch (encryptionModes)
            {
                case EncryptionModes.ConstantSaltNoneUserSessionNone:
                    salt = System.Web.Security.Membership.GeneratePassword(EncryptionHelper.SaltLength, 0);
                    guid = Guid.Empty;
                    break;
                case EncryptionModes.ConstantSaltNoneUserSession:
                    salt = System.Web.Security.Membership.GeneratePassword(EncryptionHelper.SaltLength, 0);
                    guid = EncryptionHelper.CurrentUserSessionGuid;
                    break;
                case EncryptionModes.ConstantSaltUserSessionNone:
                    salt = ConstantSalt;
                    guid = Guid.Empty;
                    break;
                case EncryptionModes.ConstantSaltUserSession:
                    salt = ConstantSalt;
                    guid = EncryptionHelper.CurrentUserSessionGuid;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("", encryptionModes, null);
            }
            plainText = salt + guid.ToString("D") + plainText;
            return HttpServerUtility.UrlTokenEncode(plainText._Encrypt());
           // return Convert.ToBase64String(plainText._Encrypt());
        }

        public static string Encrypt(this string plainText, EncryptionModes encryptionModes = EncryptionModes.ConstantSaltNoneUserSession)
        {
            return plainText._Encrypt(encryptionModes);
        }

        public static string Decrypt(this string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;
            var decrypted = HttpServerUtility.UrlTokenDecode(cipherText)._Decrypt();    //;  Convert.FromBase64String(cipherText)._Decrypt();
            var saltRemovedDecrypted = decrypted.Substring(EncryptionHelper.SaltLength);
            var guid = Guid.ParseExact(saltRemovedDecrypted.Substring(0, EncryptionHelper.GuidLength), "D");
            if (guid != Guid.Empty && guid != EncryptionHelper.CurrentUserSessionGuid)
                throw new InvalidOperationException("Encryption: Session mismatched.");
            return saltRemovedDecrypted.Substring(EncryptionHelper.GuidLength);
        }

        [Conditional("DEBUG")]
        public static void EncryptionTests()
        {
            var random = new Random();
            for (var i = 0; i < Int16.MaxValue; i++)
            {
                var length = random.Next(1, 128);
                var plainText = System.Web.Security.Membership.GeneratePassword(length, random.Next(0, length));
                plainText = plainText + plainText.ToLower() + plainText.ToUpper();
                var cypherText1 = plainText.Encrypt();
                var decrypted1 = cypherText1.Decrypt();

                var cypherText2 = plainText.Encrypt();
                var decrypted2 = cypherText2.Decrypt();

                if (plainText != decrypted1 || plainText != decrypted2 || cypherText1 == cypherText2)
                    throw new Exception();
            }
        }
    }

}
