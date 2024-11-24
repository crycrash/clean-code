namespace Markdown.Tags;
public class BoldTag : ITagHandler
{
    private const string Symbols = "__";
    private const string HtmlTag = "strong";


    public bool IsTagStart(string text, int index)
    {
        return index + 2 < text.Length && text.Substring(index, 2) == Symbols
        && !char.IsWhiteSpace(text[index + 1]);

    }
    public int ProcessTag(ref string text, int startIndex)
    {
        var newIndex = HelperFunctions.ScreeningCheck(ref text, startIndex);
        if (newIndex == startIndex)
        {
            int endIndex = text.IndexOf(Symbols, startIndex + 1);

            if (endIndex == -1)
                return startIndex + 2;

            string content = text.Substring(startIndex + 2, endIndex - startIndex - 2);
            if (HelperFunctions.ContainsWhiteSpaces(content))
                return startIndex + content.Length;
            content = HelperFunctions.ProcessNestedTag(ref content);
            string replacement = $"<{HtmlTag}>{content}</{HtmlTag}>";
            text = text.Substring(0, startIndex) + replacement + text.Substring(endIndex + 2);
            return startIndex + replacement.Length;
        }
        else
        {
            return newIndex;
        }
    }
}
