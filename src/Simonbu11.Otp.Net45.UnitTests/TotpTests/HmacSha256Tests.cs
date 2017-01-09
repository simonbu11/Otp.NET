using System;
using NUnit.Framework;
using Simonbu11.Otp.Totp;

namespace Simonbu11.Otp.Net45.UnitTests.TotpTests
{
    public class HmacSha256Tests
    {
        [TestCase("12345678901234567890", 59, "46119246")]
        [TestCase("12345678901234567890", 1111111109, "68084774")]
        [TestCase("12345678901234567890", 1111111111, "67062674")]
        [TestCase("12345678901234567890", 1234567890, "91819424")]
        [TestCase("12345678901234567890", 2000000000, "90698825")]
        [TestCase("12345678901234567890", 20000000000, "77737706")]
        public void ThenItShouldGenerateCorrectCode(string sharedSecret, long secondsSinceEpoch, string expectedCode)
        {
            // Arrange
            var generator = new HmacSha256TotpGenerator(new TotpGeneratorSettings
            {
                SharedSecret = OtpSharedSecret.FromAsciiString(sharedSecret)
            });
            var time = new DateTime(1970, 1, 1).AddSeconds(secondsSinceEpoch);

            // Act
            var actual = generator.Generate(time);

            // Assert
            Assert.AreEqual(expectedCode, actual);
        }
    }
}