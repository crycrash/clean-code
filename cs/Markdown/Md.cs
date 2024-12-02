using Markdown.Tags;

namespace Markdown;

public class Md
{
    private static readonly List<ITagHandler> TagHandlers =
        [
            new BoldTag(),
            new ItalicTag(),
            new HeadingTag(),
            new BulletedList()
        ];

    public static string Render(string markdownString)
    {
        if (string.IsNullOrEmpty(markdownString) || HelperFunctions.ContainsOnlyDash(markdownString))
            return markdownString;

        int index = 0;
        while (index < markdownString.Length)
        {
            if (!char.IsLetter(markdownString[index]))
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
