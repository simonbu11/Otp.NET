# Otp.NET
One-Time password library, providing .NET implementations of HOTP ([RFC4226]) and TOTP ([RFC6238])

The Implementations of both algorithms is based on the reference implementations listed in the relevant RFC.

## How to get it
You can install the package from nuget.org

```powershell
Install-Package simonbu11.otp
```

## Usage

### HOTP
Create a generator
```csharp
var generator = new HmacSha1HotpGenerator(new HotpGeneratorSettings
{
    SharedSecret = OtpSharedSecret.FromAsciiString(sharedSecret)
});
```

generate code from counter
```csharp
var counter = 1;
var code = generator.Generate(counter);
```

### TOTP
Create a generator
```csharp
// There are 3 TOTP generator implementations - HmacSha512TotpGenerator, HmacSha256TotpGenerator & HmacSha1TotpGenerator
var generator = new HmacSha512TotpGenerator(new HotpGeneratorSettings
{
    SharedSecret = OtpSharedSecret.FromAsciiString(sharedSecret)
});
```

Then either generate a code from a specific time
```csharp
var time = DateTime.Now;
var actual = generator.Generate(time)
```

Or either generate a code from a specific time-step
```csharp
var timeStep = 1234567890;
var actual = generator.Generate(timeStep)
```

## License
This project is licensed under [the MIT license], you can find a copy of the license in the [LICENSE file].


  [RFC4226]: https://tools.ietf.org/html/rfc4226
  [RFC6238]: https://tools.ietf.org/html/rfc6238
  [the MIT license]: https://opensource.org/licenses/MIT
  [LICENSE file]: LICENSE.txt
