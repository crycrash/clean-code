namespace Markdown;

public class HelperFunctions
{
    private static readonly char[] forbiddenChars = ['_', '#'];
    public static int ScreeningCheck(ref string text, int startIndex)
    {
        if (IsScreening(text, startIndex))
        {
            int endIndex = text.IndexOf('\\', startIndex + 1);
            if (endIndex == -1)
                return startIndex + 1;
            text = text.Remove(startIndex - 1, 1).Remove(endIndex - 1, 1);
            return endIndex - 1;
        }
        return startIndex;
    }

    public static int FindCorrectCloseSymbolForItalic(string text, int startIndex)
    {
        for (int i = startIndex + 1; i < text.Length; i++)
        {
            if (text[i] == '_' && !IsScreening(text, i)
                && !IsPartOfDoubleUnderscore(text, i) && !IsSurroundedByWhitespaceOrDigit(text, i))
            {
                return i;
            }
        }
        return -1;
    }

    private static bool IsScreening(string text, int index) =>
        index - 1 >= 0 && text[index - 1] == '\\';

    public static bool IsDigit(string text, int index) =>
        index - 1 >= 0 && char.IsDigit(text[index - 1]);

    public static string ProcessNestedTag(ref string text) =>
        Md.Render(text);

    public static bool ContainsWhiteSpaces(string text) =>
        text.Contains(' ') || string.IsNullOrWhiteSpace(text);

    public static bool ContainsOnlyDash(string text) =>
        text.All(symbol => forbiddenChars.Contains(symbol));

    private static bool IsPartOfDoubleUnderscore(string text, int index) =>
        (index + 1 < text.Length && text[index + 1] == '_') ||
        (index > 0 && text[index - 1] == '_');

    private static bool IsSurroundedByWhitespaceOrDigit(string text, int index) =>
        (index > 0 && char.IsWhiteSpace(text[index - 1])) ||
        (index + 1 < text.Length && char.IsWhiteSpace(text[index + 1])) ||
        (index > 0 && char.IsDigit(text[index - 1]));
}
