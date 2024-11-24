namespace Markdown.Tags;
public class HeadingTag : ITagHandler
{
    private const string Symbol = "#";
    private const string HtmlTag = "h1";

    public bool IsTagStart(string text, int index)
    {
        return text[index].ToString() == Symbol;
    }

    public int ProcessTag(ref string text, int startIndex)
    {
        var newIndex = HelperFunctions.ScreeningCheck(ref text, startIndex);
        if (newIndex == startIndex)
        {
            int endIndex = text.IndexOf('\n', startIndex + 1);
            string replacement;
            string content;
            if (endIndex == -1)
            {
                content = text.Substring(startIndex + 1, text.Length - startIndex - 1);
                if (HelperFunctions.ContainsWhiteSpaces(content))
                    return startIndex + content.Length;
                content = HelperFunctions.ProcessNestedTag(ref content);
                replacement = $"<{HtmlTag}>{content}</{HtmlTag}>";
                text = text.Substring(0, startIndex) + replacement;

                return startIndex + replacement.Length;
            }

            content = text.Substring(startIndex + 1, endIndex - startIndex - 1);
            if (HelperFunctions.ContainsWhiteSpaces(content))
                return startIndex + content.Length;
            content = HelperFunctions.ProcessNestedTag(ref content);
            replacement = $"<{HtmlTag}>{content}</{HtmlTag}>" + '\n';
            text = text.Substring(0, startIndex) + replacement + text.Substring(endIndex + 1);

            return startIndex + replacement.Length;
        }
        else
        {
            return newIndex;
        }

    }
}
