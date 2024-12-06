using Markdown.Tags;

namespace Markdown;

public class Md
{
    private static readonly List<ITagHandler> TagHandlers =
        [
            new BoldTag(),
            new ItalicTag(),
            new HeadingTag(),
            new EscapeTag()
        ];
    private readonly char[] tagChars;

    public Md(char[]? customTagChars = null)
    {
        tagChars = customTagChars ?? ['_', '#', '\\'];
    }

    private bool CanBeTag(char symbol) => tagChars.Contains(symbol);

    public string Render(string markdownString)
    {
        int index = 0;
        while (index < markdownString.Length)
        {
            if (CanBeTag(markdownString[index]))
            {
                if (TryProcessTag(ref markdownString, ref index))
                    continue;
            }
            index++;
        }

        return markdownString;
    }

    private static bool TryProcessTag(ref string markdownString, ref int index)
    {
        foreach (var handler in TagHandlers)
        {
            if (handler.IsTagStart(markdownString, index))
            {
                index = handler.ProcessTag(ref markdownString, index);
                return true;
            }
        }
        return false;
    }
}
