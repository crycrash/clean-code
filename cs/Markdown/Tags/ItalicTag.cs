namespace Markdown.Tags;
public class ItalicTag : ITagHandler
{
    private const string Symbol = "_";
    private const string HtmlTag = "em";

    public bool IsTagStart(string text, int index)
    {
        return text[index].ToString() == Symbol
               && index + 1 < text.Length
               && !char.IsWhiteSpace(text[index + 1]);
    }

    public int ProcessTag(ref string text, int startIndex)
    {

        var newIndex = HelperFunctions.ScreeningCheck(ref text, startIndex);
        if (newIndex == startIndex)
        {
            int endIndex = HelperFunctions.FindCorrectCloseSymbolForItalic(text, startIndex + 1);

            if (endIndex == -1)
                return startIndex + 1;

            string content = text.Substring(startIndex + 1, endIndex - startIndex - 1);
            if (HelperFunctions.ContainsWhiteSpaces(content))
                return startIndex + content.Length;
            string replacement = $"<{HtmlTag}>{content}</{HtmlTag}>";
            text = text.Substring(0, startIndex) + replacement + text.Substring(endIndex + 1);

            return startIndex + replacement.Length;
        }
        else
        {
            return newIndex;
        }
    }
}
