using System;
using Simonbu11.Otp.Totp;
using Xunit;

namespace Simonbu11.Otp.Net45.UnitTests.TotpTests
{
    public class HmacSha1Tests
    {
        [Theory]
        [InlineData("12345678901234567890", 59, "94287082")]
        [InlineData("12345678901234567890", 1111111109, "07081804")]
        [InlineData("12345678901234567890", 1111111111, "14050471")]
        [InlineData("12345678901234567890", 1234567890, "89005924")]
        [InlineData("12345678901234567890", 2000000000, "69279037")]
        [InlineData("12345678901234567890", 20000000000, "65353130")]
        public void ThenItShouldGenerateCorrectCode(string sharedSecret, long secondsSinceEpoch, string expectedCode)
        {
            // Arrange
            var generator = new HmacSha1TotpGenerator(new TotpGeneratorSettings
            {
                SharedSecret = OtpSharedSecret.FromAsciiString(sharedSecret)
            });
            var time = new DateTime(1970, 1, 1).AddSeconds(secondsSinceEpoch);

            // Act
            var actual = generator.Generate(time);

            // Assert
            Assert.Equal(expectedCode, actual);
        }
    }
}