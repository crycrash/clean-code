using Markdown;
using FluentAssertions;
namespace MarkdownTests;

public class ItailcTests
{
    [Test]
    public void Test_StandartItalicText()
    {
        Md.Render("_aaaa_").Should().Be("<em>aaaa</em>");
        Md.Render("_aaaa_bbbb_cc_").Should().Be("<em>aaaa</em>bbbb<em>cc</em>");
        Md.Render("#_aaa_").Should().Be("<h1><em>aaa</em></h1>");
    }

    [Test]
    public void Test_NestedInItalicTags()
    {
        Md.Render("_aaa__b__a_").Should().Be("<em>aaa__b__a</em>");

    }
    [Test]
    public void Test_ItalicPartOfWord()
    {
        Md.Render("_нач_але").Should().Be("<em>нач</em>але");
        Md.Render("сер_еди_не").Should().Be("сер<em>еди</em>не");
        Md.Render("кон_це._").Should().Be("кон<em>це.</em>");
    }

    [Test]
    public void Test_ItalicSeveralWords()
    {
        Md.Render("ра_зных сл_овах").Should().Be("ра_зных сл_овах");
        Md.Render("ра__зных сл__овах").Should().Be("ра__зных сл__овах");
        Md.Render("кон_це._").Should().Be("кон<em>це.</em>");
    }

    [Test]
    public void Test_ItalicTextWithSpaces()
    {
        Md.Render("_ подчерки_").Should().Be("_ подчерки_");
        Md.Render("_подчерки _").Should().Be("_подчерки _");
    }
}