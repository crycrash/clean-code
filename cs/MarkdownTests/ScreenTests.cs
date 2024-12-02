using Markdown;
using FluentAssertions;
namespace MarkdownTests;

public class ScreenTests
{
    [Test]
    public void Test_BoldWithТestedItalic()
    {
        Console.WriteLine("\\");
        Md.Render("\\aaa").Should().Be("\\aaa", "Один экранированный символ и строка без тэгов. Ему нечего экранировать");
        Md.Render("\\__aaa__\\").Should().Be("__aaa__", "Экранированный символ в конце и начале. Экранирует жирный тэг");
        Md.Render("\\_aaa_\\").Should().Be("_aaa_", "Экранированный символ в конце и начале. Экранирует курсивный тэг");
        Md.Render("\\# aaa\\").Should().Be("# aaa", "Экранированный символ в конце и начале. Экранирует заголовочный тэг");
        Md.Render("\\\\# aa\\").Should().Be("\\# aa", "Экранированный символ в конце и начале, и в теле тэга. Экранированный символ тоже можно экранировать");
        Md.Render("\\#aa\\").Should().Be("\\#aa\\", "Экранированный символ в конце и начале, но тэг неправильно написан. Нет экранизации");
    }
}