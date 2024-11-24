namespace Markdown;
using Markdown.Tags;

public static class Md
{
    public static void Main(){
        
    }
    private static readonly List<ITagHandler> tagHandlers = new List<ITagHandler>
            {
                new BoldTag(),
                new ItalicTag(),
                new HeadingTag()
            };

    public static string Render(string markdownString)
    {
        int index = 0;
        if (HelperFunctions.ContainsOnlyDash(markdownString))
            return markdownString;

        while (index < markdownString.Length)
        {
            bool tagProcessed = false;
            if (!char.IsLetter(markdownString[index]))
            {
                foreach (var handler in tagHandlers)
                {
                    if (handler.IsTagStart(markdownString, index))
                    {
                        index = handler.ProcessTag(ref markdownString, index);
                        tagProcessed = true;
                        break;
                    }
                }
            }
            if (!tagProcessed)
            {
                index++;
            }
        }
        return markdownString;
    }
}