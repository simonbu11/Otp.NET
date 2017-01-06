using System;
using System.Text;

namespace Simonbu11.Otp
{
    public class OtpSharedSecret
    {
        public OtpSharedSecret(byte[] data)
        {
            Data = data;   
        }

        public byte[] Data { get; set; }

        public byte[] GetKeyOfLength(int requiredLength)
        {
            if (Data.Length >= requiredLength)
            {
                return Data;
            }

            var buffer = new byte[requiredLength];
            var offset = 0;
            while (offset < buffer.Length)
            {
                var copyLength = offset + Data.Length > buffer.Length
                    ? buffer.Length - offset
                    : Data.Length;
                Array.Copy(Data, 0, buffer, offset, copyLength);
                offset += Data.Length;
            }

            return buffer;
        }

        public static OtpSharedSecret FromAsciiString(string value)
        {
            return new OtpSharedSecret(Encoding.ASCII.GetBytes(value));
        }
        public static OtpSharedSecret FromUtf8String(string value)
        {
            return new OtpSharedSecret(Encoding.UTF8.GetBytes(value));
        }
        public static OtpSharedSecret FromUnicodeString(string value)
        {
            return new OtpSharedSecret(Encoding.Unicode.GetBytes(value));
        }
        public static OtpSharedSecret FromBase64String(string value)
        {
            return new OtpSharedSecret(Convert.FromBase64String(value));
        }
        public static OtpSharedSecret FromHexString(string value)
        {
            return new OtpSharedSecret(value.HexStringToBytes());
        }
    }
}
