using System.Security.Cryptography;

namespace Simonbu11.Otp.Hotp
{
    public class HmacSha1HotpGenerator : HotpGenerator
    {
        public HmacSha1HotpGenerator(OtpGeneratorSettings settings) : base(settings)
        {
        }

        protected override byte[] ConvertSecretToHashKey(OtpSharedSecret sharedSecret)
        {
            return sharedSecret.GetKeyOfLength(20);
        }

        protected override byte[] ComputeHash(byte[] k, byte[] msg)
        {
            return new HMACSHA1(k).ComputeHash(msg);
        }

    }
}
