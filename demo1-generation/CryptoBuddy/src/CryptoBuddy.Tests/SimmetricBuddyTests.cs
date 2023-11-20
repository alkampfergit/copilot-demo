using System.IO;
using System.Text;
using Xunit;
using CryptoBuddy;

namespace CryptoBuddy.Tests
{
    public class SimmetricBuddyTests
    {
        [Fact]
        public void TestEncryptDecryptStream()
        {
            // Arrange
            var simmetricBuddy = new SimmetricBuddy();
            var originalStream = new MemoryStream(Encoding.UTF8.GetBytes("Hello, CryptoBuddy!"));
            var encryptedStream = new MemoryStream();
            var decryptedStream = new MemoryStream();

            // Act
            simmetricBuddy.EncryptStream(originalStream, encryptedStream, "password");
            
            // encrypted stream is closed by encrypt stream 
            using var toDecryptStream = new MemoryStream(encryptedStream.ToArray());
            simmetricBuddy.DecryptStream(toDecryptStream, decryptedStream, "password");
            decryptedStream.Position = 0; // Reset stream position

            // Assert
            var decryptedMessage = new StreamReader(decryptedStream).ReadToEnd();
            Assert.Equal("Hello, CryptoBuddy!", decryptedMessage);
        }
    }
}