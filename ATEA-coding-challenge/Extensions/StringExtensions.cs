using System.Globalization;

namespace ATEA_coding_challenge.Extensions;

public static class StringExtensions
{
    public static string SumFirstTwoArgs(this string[] arguments)
    {
        if (Int32.TryParse(arguments[0], out var intOne) && Int32.TryParse(arguments[1], out var intTwo))
        {
            return (intOne + intTwo).ToString();
        }
        if (Single.TryParse(arguments[0], out var floatOne) && Single.TryParse(arguments[1], out var floatTwo))
        {
            return (floatOne + floatTwo).ToString(CultureInfo.InvariantCulture);
        }
        return arguments[0] + " " + arguments[1];
    }
}