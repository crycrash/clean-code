namespace Markdown;

public class HelperFunctions
{
    private static readonly char[] forbiddenChars = ['_', '#'];

    public static int FindCorrectCloseSymbolForItalic(string text, int startIndex)
    {
        for (int i = startIndex + 1; i < text.Length; i++)
        {
            if (text[i] == '_' && !IsPartOfDoubleUnderscore(text, i) && !IsSurroundedByWhitespaceOrDigit(text, i))
            {
                return i;
            }
        }
        return -1;
    }

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
