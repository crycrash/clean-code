

using Microsoft.VisualBasic;

namespace Markdown;

public class HelperFunctions
{
    private static char[] forbiddenChars = {'_', '#'};
    public static int ScreeningCheck(ref string text, int startIndex)
    {
        if (IsScreening(text, startIndex))
        {
            int endIndex = text.IndexOf('\\', startIndex + 1);
            if (endIndex == -1)
            {
                return startIndex + 1;
            }
            text = text.Remove(startIndex - 1, 1).Remove(endIndex - 1, 1);
            return endIndex - 1;
        }
        return startIndex;
    }

    private static bool IsScreening(string text, int index) =>
        index - 1 >= 0 && text[index - 1] == '\\';

    public static int FindCorrectCloseSymbolForItalic(string markdownString, int startIndex)
    {
        for (int i = startIndex + 1; i < markdownString.Length; i++)
        {
            if (markdownString[i] == '_')
            {
                if (i > 0 && markdownString[i - 1] == '\\')
                    continue;
                if (i + 1 < markdownString.Length && markdownString[i + 1] == '_')
                    continue;
                if (i - 1 > 0 && markdownString[i - 1] == '_')
                    continue;
                if (i > 0 && char.IsWhiteSpace(markdownString[i - 1]))
                    continue;
                if (i + 1 < markdownString.Length && char.IsWhiteSpace(markdownString[i + 1]))
                    continue;
                if (HelperFunctions.IsDigit(markdownString, i))
                    continue;
                return i;
            }
        }
        return -1;
    }
    public static bool IsDigit(string text, int index) =>
        index - 1 >= 0 && char.IsDigit(text[index - 1]);


    public static string ProcessNestedTag(ref string text)
    {
        text = Md.Render(text);
        return text;
    }

    public static bool ContainsWhiteSpaces(string text) =>
    text.Contains(" ") || string.IsNullOrWhiteSpace(text);

    public static bool ContainsOnlyDash(string text) =>
    text.All(symbol => forbiddenChars.Contains(symbol));

}