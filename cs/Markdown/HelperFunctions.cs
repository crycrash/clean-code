namespace Markdown;

public class HelperFunctions
{
    private static readonly char[] forbiddenChars = ['_', '#'];

    private static readonly char[] tagChars = ['_', '#', '\\'];

    public static int FindCorrectCloseSymbolForItalic(string text, int startIndex)
    {
        for (int i = startIndex + 1; i < text.Length; i++)
        {
            if (text[i] == '_' && !IsPartOfDoubleUnderscore(text, i) && IsValidCloseSymbol(text, i))
                return i;
        }
        return -1;
    }

    private static bool IsValidCloseSymbol(string text, int index)
    {
        if (index + 1 < text.Length && char.IsDigit(text[index + 1]))
            return false;
        if (index - 1 >= 0 && char.IsDigit(text[index - 1]))
        {
            if (index + 1 == text.Length || text.Substring(index + 1).All(char.IsWhiteSpace))
                return true;

            return false;
        }
        return true;
    }

    public static string ProcessNestedTag(ref string text)
    {
        Md md = new Md(['_', '\\']);
        return md.Render(text);
    }

    public static bool ContainsOnlyDash(string text) =>
        text.All(symbol => forbiddenChars.Contains(symbol));

    public static bool ContainsOnlyHeading(string text) =>
        text.All(symbol => symbol == '#');

    public static bool ContainsOnlySpases(string text) =>
        string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text);

    private static bool IsPartOfDoubleUnderscore(string text, int index) =>
        (index + 1 < text.Length && text[index + 1] == '_') ||
        (index > 0 && text[index - 1] == '_');

    public static bool ContainsUnderscore(string text) => text.Contains('_');

    public static (List<int>, List<int>) GetUnderscoreIndexes(string text)
    {
        List<int> singleUnderscoreIndexes = new List<int>();
        List<int> doubleUnderscoreIndexes = new List<int>();
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '_' && ((i + 1 < text.Length && text[i + 1] != '_') || i == text.Length - 1))
            {
                singleUnderscoreIndexes.Add(i);
            }
            if (i + 1 < text.Length && text[i] == '_' && text[i + 1] == '_')
            {
                doubleUnderscoreIndexes.Add(i);
                i++;
            }
        }
        return (singleUnderscoreIndexes, doubleUnderscoreIndexes);
    }

    public static bool HasUnpairedTags(List<int> indexes1, List<int> indexes2)
    {
        if (indexes1.Count < 2 || indexes2.Count < 2 || indexes1.Count % 2 == 1 || indexes2.Count % 2 == 1)
        {
            return false;
        }
        return true;
    }

    public static bool AreSegmentsIntersecting(int[] segment1, int[] segment2)
    {
        return segment1[1] >= segment2[0] && segment1[0] <= segment2[1];
    }

    public static bool AreSegmentsNested(int[] segment1, int[] segment2)
    {
        return (segment1[0] >= segment2[0] && segment1[1] <= segment2[1]) ||
               (segment2[0] >= segment1[0] && segment2[1] <= segment1[1]);
    }

    public static string RemoveExtraSpaces(string input)
    {
        return string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }
}
