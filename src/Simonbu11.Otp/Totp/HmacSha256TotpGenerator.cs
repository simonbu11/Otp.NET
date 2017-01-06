using System.Security.Cryptography;

namespace Simonbu11.Otp.Totp
{
    public class HmacSha256TotpGenerator : TotpGenerator
    {
        public HmacSha256TotpGenerator(TotpGeneratorSettings settings) : base(settings)
        {
        }

        protected override byte[] ConvertSecretToHashKey(OtpSharedSecret sharedSecret)
        {
            return sharedSecret.GetKeyOfLength(32);
        }

        protected override byte[] ComputeHash(byte[] k, byte[] msg)
        {
            return new HMACSHA256(k).ComputeHash(msg);
        }
    }
}