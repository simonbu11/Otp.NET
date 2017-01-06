using System;

namespace Simonbu11.Otp.Totp
{
    public abstract class TotpGenerator : OtpGenerator
    {
        protected TotpGenerator(TotpGeneratorSettings settings)
            : base(settings)
        {
            Settings = settings;
            Epoch = new DateTime(1970, 1, 1);
        }


        protected new TotpGeneratorSettings Settings { get; set; }
        protected DateTime Epoch { get; }


        public virtual string Generate(DateTime time)
        {
            var timeStep = (long)Math.Floor((time - Epoch).TotalSeconds / Settings.TimeStepInterval);
            return Generate(timeStep);
        }
        public virtual string Generate(long timeStep)
        {
            var time = timeStep.ToString("X");
            while (time.Length < 16)
            {
                time = "0" + time;
            }

            // Get the HEX in a Byte[]
            var msg = time.HexStringToBytes();

            return Generate(msg);
        }

        
    }
}
