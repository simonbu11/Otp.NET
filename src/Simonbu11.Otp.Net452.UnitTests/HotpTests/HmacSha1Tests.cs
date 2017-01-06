using System;
using NUnit.Framework;
using Simonbu11.Otp.Hotp;

namespace Simonbu11.Otp.Net452.UnitTests.HotpTests
{
    public class HmacSha1Tests
    {
        [TestCase("12345678901234567890", 0, "755224")]
        [TestCase("12345678901234567890", 1, "287082")]
        [TestCase("12345678901234567890", 2, "359152")]
        [TestCase("12345678901234567890", 3, "969429")]
        [TestCase("12345678901234567890", 4, "338314")]
        [TestCase("12345678901234567890", 5, "254676")]
        [TestCase("12345678901234567890", 6, "287922")]
        [TestCase("12345678901234567890", 7, "162583")]
        [TestCase("12345678901234567890", 8, "399871")]
        [TestCase("12345678901234567890", 9, "520489")]
        public void ThenItShouldGenerateCorrectCode(string sharedSecret, long counter, string expectedCode)
        {
            // Arrange
            var generator = new HmacSha1HotpGenerator(new HotpGeneratorSettings
            {
                SharedSecret = OtpSharedSecret.FromAsciiString(sharedSecret)
            });

            // Act
            var actual = generator.Generate(counter);

            // Assert
            Assert.AreEqual(expectedCode, actual);
        }
    }
}
