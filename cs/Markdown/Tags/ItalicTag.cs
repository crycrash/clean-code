namespace Markdown.Tags;
public class ItalicTag : BaseTagHandler
{
    protected override string Symbol => "_";
    protected override string HtmlTag => "em";

    public override bool IsTagStart(string text, int index)
    {
        return text[index].ToString() == Symbol
               && index + 1 < text.Length
               && !char.IsWhiteSpace(text[index + 1]);
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