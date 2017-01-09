﻿using System;
using NUnit.Framework;
using Simonbu11.Otp.Totp;

namespace Simonbu11.Otp.Net45.UnitTests.TotpTests
{
    public class HmacSha512Tests
    {
        [TestCase("12345678901234567890", 59, "90693936")]
        [TestCase("12345678901234567890", 1111111109, "25091201")]
        [TestCase("12345678901234567890", 1111111111, "99943326")]
        [TestCase("12345678901234567890", 1234567890, "93441116")]
        [TestCase("12345678901234567890", 2000000000, "38618901")]
        [TestCase("12345678901234567890", 20000000000, "47863826")]
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
            Assert.AreEqual(expectedCode, actual);
        }

        [TestCase("GQ2TCMRSGQ2TELJRMRQTQLJUMI3DSLJYMYZWILJWGUYWMNBSMM3DSODDGY2DKMJSGI2DKMRNGFSGCOBNGRRDMOJNHBTDGZBNGY2TCZQ",59, "29303361")]
        [TestCase("GQ2TCMRSGQ2TELJRMRQTQLJUMI3DSLJYMYZWILJWGUYWMNBSMM3DSODDGY2DKMJSGI2DKMRNGFSGCOBNGRRDMOJNHBTDGZBNGY2TCZQ", 1234567890, "84853786")]
        [TestCase("GQ2TCMRSGQ2TELJRMRQTQLJUMI3DSLJYMYZWILJWGUYWMNBSMM3DSODDGY2DKMJSGI2DKMRNGFSGCOBNGRRDMOJNHBTDGZBNGY2TCZQ", 2000000000, "98909859")]

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
            Assert.AreEqual(expectedCode, actual);
        }
    }
}
