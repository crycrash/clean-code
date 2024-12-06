namespace Markdown.Tags;
public class ItalicTag : BaseTagHandler
{
    protected override string Symbol => "_";
    protected override string HtmlTag => "em";

    public override bool IsTagStart(string text, int index)
    {
        if (text[index].ToString() != Symbol)
            return false;
        if (index + 1 < text.Length && char.IsWhiteSpace(text[index + 1]))
            return false;
        // if (index - 1 >= 0 && char.IsDigit(text[index - 1]))
        //     return false;
        return true;
    }

    protected override int FindEndIndex(string text, int startIndex)
    {
        return HelperFunctions.FindCorrectCloseSymbolForItalic(text, startIndex + 1);
    }

    protected override string ProcessNestedTag(ref string text)
    {
        return text;
    }
}