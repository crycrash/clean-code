namespace Markdown.Tags;

public class ItalicTag
{
    public ItalicTag(string markdownString, int index)
    {
        Content = markdownString;
        Index = index;
    }

    public TypesTags TypeTag = TypesTags.Italic;
    public string Content;
    public int Index;
    private string symbol = "_";

    public bool CheckIsItalicTag(){
        throw new NotImplementedException();
    }
}