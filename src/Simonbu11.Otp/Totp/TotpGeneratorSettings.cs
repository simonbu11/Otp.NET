namespace Simonbu11.Otp.Totp
{
    public class TotpGeneratorSettings : OtpGeneratorSettings
    {
        public int TimeStepInterval { get; set; } = 30;
    }
}
