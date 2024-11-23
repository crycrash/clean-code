namespace Markdown.Tags;

public class BoldTag
{
    public BoldTag(string markdownString, int index)
    {
        Content = markdownString;
        Index = index;
    }

    public TypesTags TypeTag = TypesTags.Bold;
    public string Content;
    public int Index;
    private string symbol = "__";
    public bool CheckIsBoldTag(){
        throw new NotImplementedException();
    }
}