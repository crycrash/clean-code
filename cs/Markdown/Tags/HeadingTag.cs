namespace Markdown.Tags;

public class HeadingTag
{
    public HeadingTag(string markdownString, int index)
    {
        Content = markdownString;
        Index = index;
    }

    public TypesTags TypeTag = TypesTags.Heading;
    public string Content;
    public int Index;
    private string symbol = "#";
    public bool CheckIsHeadingTag(){
        throw new NotImplementedException();
    }
}