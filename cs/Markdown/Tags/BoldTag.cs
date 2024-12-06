namespace Markdown.Tags;
public class BoldTag : BaseTagHandler
{
    protected override string Symbol => "__";
    protected override string HtmlTag => "strong";

    public override bool IsTagStart(string text, int index)
    {
        if (index + 2 >= text.Length || text.Substring(index, 2) != Symbol)
            return false;
        if (index + 1 < text.Length && char.IsWhiteSpace(text[index + 1]))
            return false;
        if (index - 1 >= 0 && char.IsDigit(text[index - 1]))
            return false;
        return true;
    }
}