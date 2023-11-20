using System;
using System.IO;
using System.Security.Cryptography;

namespace CryptoBuddy;

public class SimmetricBuddy
{
    private static readonly byte[] Salt = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f };

    public void EncryptStream(Stream inputStream, Stream outputStream, string password)
    {
        var key = new Rfc2898DeriveBytes(password, Salt);

        using (var aes = new AesManaged())
        {
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using var cryptoStream = new CryptoStream(outputStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            inputStream.CopyTo(cryptoStream);
        }
    }

    public void DecryptStream(Stream inputStream, Stream outputStream, string password)
    {
        var key = new Rfc2898DeriveBytes(password, Salt);

        using (var aes = new AesManaged())
        {
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            using (var cryptoStream = new CryptoStream(inputStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                cryptoStream.CopyTo(outputStream);
            }
        }
    }
}

