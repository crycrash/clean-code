namespace Markdown.Tags;
public class HeadingTag : BaseTagHandler
{
    protected override string Symbol => "#";
    protected override string HtmlTag => "h1";

    public override bool IsTagStart(string text, int index)
    {
        return text[index].ToString() == Symbol;
    }

    protected override int FindEndIndex(string text, int startIndex)
    {
        int endIndex = text.IndexOf('\n', startIndex + 1);
        return endIndex == -1 ? text.Length : endIndex;
    }

    protected override string ReplaceText(string text, int startIndex, int endIndex, string replacement)
    {
        if (endIndex < text.Length && text[endIndex] == '\n')
        {
            return text.Substring(0, startIndex) + replacement + '\n' + text.Substring(endIndex + 1);
        }
        return text.Substring(0, startIndex) + replacement + text.Substring(endIndex);
    }
}
