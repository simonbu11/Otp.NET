using System;
using Simonbu11.Otp.Totp;
using Xunit;

namespace Simonbu11.Otp.Net45.UnitTests.TotpTests
{
    public class HmacSha512Tests
    {
        [InlineData("12345678901234567890", 59, "90693936")]
        [InlineData("12345678901234567890", 1111111109, "25091201")]
        [InlineData("12345678901234567890", 1111111111, "99943326")]
        [InlineData("12345678901234567890", 1234567890, "93441116")]
        [InlineData("12345678901234567890", 2000000000, "38618901")]
        [InlineData("12345678901234567890", 20000000000, "47863826")]
        public void ThenItShouldGenerateCorrectCode(string sharedSecret, long secondsSinceEpoch, string expectedCode)
        {
            // Arrange
            var generator = new HmacSha512TotpGenerator(new TotpGeneratorSettings
            {
                SharedSecret = OtpSharedSecret.FromAsciiString(sharedSecret)
            });
            var time = new DateTime(1970, 1, 1).AddSeconds(secondsSinceEpoch);

            // Act
            var actual = generator.Generate(time);

            // Assert
            Assert.Equal(expectedCode, actual);
        }

        [InlineData("GQ2TCMRSGQ2TELJRMRQTQLJUMI3DSLJYMYZWILJWGUYWMNBSMM3DSODDGY2DKMJSGI2DKMRNGFSGCOBNGRRDMOJNHBTDGZBNGY2TCZQ",59, "29303361")]
        [InlineData("GQ2TCMRSGQ2TELJRMRQTQLJUMI3DSLJYMYZWILJWGUYWMNBSMM3DSODDGY2DKMJSGI2DKMRNGFSGCOBNGRRDMOJNHBTDGZBNGY2TCZQ", 1234567890, "84853786")]
        [InlineData("GQ2TCMRSGQ2TELJRMRQTQLJUMI3DSLJYMYZWILJWGUYWMNBSMM3DSODDGY2DKMJSGI2DKMRNGFSGCOBNGRRDMOJNHBTDGZBNGY2TCZQ", 2000000000, "98909859")]

        public void ThenItShouldGenerateCodeFromBase32Encoded(string sharedSecret, long secondsSinceEpoch, string expectedCode)
        {
            // Arrange
            var generator = new HmacSha512TotpGenerator(new TotpGeneratorSettings
            {
                SharedSecret = OtpSharedSecret.FromBase32String(sharedSecret)
            });
            var time = new DateTime(1970, 1, 1).AddSeconds(secondsSinceEpoch);

            // Act
            var actual = generator.Generate(time);

            // Assert
            Assert.Equal(expectedCode, actual);
        }
    }
}
