using Simonbu11.Otp.Hotp;
using Xunit;

namespace Simonbu11.Otp.Net45.UnitTests.HotpTests
{
    public class HmacSha1Tests
    {
        [Theory]
        [InlineData("12345678901234567890", 0, "755224")]
        [InlineData("12345678901234567890", 1, "287082")]
        [InlineData("12345678901234567890", 2, "359152")]
        [InlineData("12345678901234567890", 3, "969429")]
        [InlineData("12345678901234567890", 4, "338314")]
        [InlineData("12345678901234567890", 5, "254676")]
        [InlineData("12345678901234567890", 6, "287922")]
        [InlineData("12345678901234567890", 7, "162583")]
        [InlineData("12345678901234567890", 8, "399871")]
        [InlineData("12345678901234567890", 9, "520489")]
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
            Assert.Equal(expectedCode, actual);
        }
    }
}
