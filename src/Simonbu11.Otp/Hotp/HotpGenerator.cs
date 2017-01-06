namespace Simonbu11.Otp
{
    public abstract class HotpGenerator : OtpGenerator
    {
        protected HotpGenerator(OtpGeneratorSettings settings) : base(settings)
        {
        }

        public string Generate(long counter)
        {
            byte[] text = new byte[8];
            for (int i = text.Length - 1; i >= 0; i--)
            {
                text[i] = (byte)(counter & 0xff);
                counter >>= 8;
            }
            return Generate(text);
        }
    }
}
