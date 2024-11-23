namespace Markdown.Tags;

public class ScreenTag
{
    public ScreenTag(string markdownString, int index)
    {
        Content = markdownString;
        Index = index;
    }

    public TypesTags TypeTag = TypesTags.Screen;
    public string Content;
    public int Index;
    private string symbol = "\\";
    public bool CheckIsScreenTag(){
        throw new NotImplementedException();
    }
}