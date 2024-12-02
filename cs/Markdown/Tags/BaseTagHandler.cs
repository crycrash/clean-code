namespace Markdown.Tags;

public abstract class BaseTagHandler : ITagHandler
{
    protected abstract string Symbol { get; }
    protected abstract string HtmlTag { get; }

    public abstract bool IsTagStart(string text, int index);

    public virtual int ProcessTag(ref string text, int startIndex)
    {
        var newIndex = HelperFunctions.ScreeningCheck(ref text, startIndex);
        if (newIndex != startIndex)
            return newIndex;

        int endIndex = FindEndIndex(text, startIndex);

        if (endIndex == -1)
            return startIndex + Symbol.Length;

        string content = ExtractContent(text, startIndex, endIndex);
        if (HelperFunctions.ContainsWhiteSpaces(content))
            return startIndex + content.Length;

        content = ProcessNestedTag(ref content);
        string replacement = WrapWithHtmlTag(content);
        text = ReplaceText(text, startIndex, endIndex, replacement);

        return startIndex + replacement.Length;
    }

    protected virtual string ProcessNestedTag(ref string text)
    {
        return HelperFunctions.ProcessNestedTag(ref text);
    }

    protected virtual int FindEndIndex(string text, int startIndex)
    {
        return text.IndexOf(Symbol, startIndex + Symbol.Length);
    }

    protected virtual string ExtractContent(string text, int startIndex, int endIndex)
    {
        return text.Substring(startIndex + Symbol.Length, endIndex - startIndex - Symbol.Length);
    }

    protected virtual string WrapWithHtmlTag(string content)
    {
        return $"<{HtmlTag}>{content}</{HtmlTag}>";
    }

    protected virtual string ReplaceText(string text, int startIndex, int endIndex, string replacement)
    {
        return text.Substring(0, startIndex) + replacement + text.Substring(endIndex + Symbol.Length);
    }
}