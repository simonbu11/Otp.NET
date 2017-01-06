namespace Simonbu11.Otp
{
    public abstract class OtpGeneratorSettings
    {
        public OtpSharedSecret SharedSecret { get; set; }
        public int CodeLength { get; set; } = 8;
    }
}
