using System;

namespace Simonbu11.Otp
{
    public abstract class OtpGenerator
    {
        protected OtpGenerator(OtpGeneratorSettings settings)
        {
            Settings = settings;
        }

        protected OtpGeneratorSettings Settings { get; set; }

        protected virtual string Generate(byte[] msg)
        {
            var k = ConvertSecretToHashKey(Settings.SharedSecret);

            var hash = ComputeHash(k, msg);

            // put selected bytes into result int
            var offset = hash[hash.Length - 1] & 0xf;

            var binary =
                ((hash[offset] & 0x7f) << 24) |
                ((hash[offset + 1] & 0xff) << 16) |
                ((hash[offset + 2] & 0xff) << 8) |
                (hash[offset + 3] & 0xff);

            var otp = binary % (int)Math.Pow(10, Settings.CodeLength);

            var result = otp.ToString();
            while (result.Length < Settings.CodeLength)
            {
                result = "0" + result;
            }
            return result;
        }

        protected abstract byte[] ConvertSecretToHashKey(OtpSharedSecret sharedSecret);
        protected abstract byte[] ComputeHash(byte[] k, byte[] msg);
    }
}
