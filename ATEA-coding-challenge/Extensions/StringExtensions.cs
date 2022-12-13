using System.Globalization;

namespace ATEA_coding_challenge.Extensions;

public static class StringExtensions
{
    public static string? SumFirstTwoArgs(this string[] arguments)
    {
        try
        {
            if (arguments.Length != 2)
            {
                throw new Exception("Wrong number of arguments.");
            }
            if (arguments[0] is null || arguments[1] is null)
            {
                throw new Exception("Either one or both arguments are null.");
            }
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}