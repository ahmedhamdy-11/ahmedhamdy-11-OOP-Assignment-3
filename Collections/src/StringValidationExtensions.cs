using System.Text.RegularExpressions;

namespace Collections;

public static class StringValidationExtensions
{
    private static readonly Regex EgyptianPhoneRegex = new(@"^(?:0|\+20)1[0125]\d{8}$", RegexOptions.Compiled);

    private static readonly Regex EgyptianNationalIdRegex = new(@"^[23]\d{13}$", RegexOptions.Compiled);

    
    public static bool IsValidEgyptianPhone(this string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        return EgyptianPhoneRegex.IsMatch(input);
    }

   
    public static bool IsValidEgyptianNationalId(this string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        return EgyptianNationalIdRegex.IsMatch(input);
    }
}
