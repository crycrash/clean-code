using Markdown;
using FluentAssertions;
namespace MarkdownTests;

public class ScreenTests
{
    [Test]
    public void Test_BoldWithТestedItalic()
    {
        Md.Render("\\aaa").Should().Be("\\aaa");
        Md.Render("\\__aaa__\\").Should().Be("__aaa__");
        Md.Render("\\_aaa_\\").Should().Be("_aaa_");
        Md.Render("\\#aaa\\").Should().Be("#aaa");
        Md.Render("\\\\#aa\\").Should().Be("\\#aa");
        Md.Render("\\#aa").Should().Be("\\#aa");
    }
}