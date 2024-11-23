namespace Markdown;

public class Token
{
    public Token(string markdownString, int index, TypesToken typeToken)
    {
        Content = markdownString;
        Index = index;
        TypeToken = typeToken;
    }

    public TypesToken TypeToken;
    public string Content;
    public int Index;
    public List<Token> NestedTags = new List<Token>();
}
