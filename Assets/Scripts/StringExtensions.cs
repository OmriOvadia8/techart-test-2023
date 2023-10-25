public static class StringExtensions
{
    public static string ToN0String(this float number)
    {
        return number.ToString("N0");
    }

    public static string ToN0String(this int number)
    {
        return number.ToString("N0");
    }

    public static string ToMultiplierString(this int multiplierValue)
    {
        return $"X{multiplierValue}";
    }

    public static string Colorize(this string text, string hexColor)
    {
        return $"<color=#{hexColor}>{text}</color>";
    }

    public static string FormatWithColor(this string actionString, string playerName, string hexColor)
    {
        return $"{actionString} {playerName.Colorize(hexColor)}";
    }
}
