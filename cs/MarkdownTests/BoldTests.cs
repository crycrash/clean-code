using FluentAssertions;
using Markdown;

namespace MarkdownTests;

public class BoldTests
{
    [Test]
    public void Test_StandartBoldWord()
    {
        Md.Render("__WORD__").Should().Be("<strong>WORD</strong>");
        Md.Render("__aaaa__").Should().Be("<strong>aaaa</strong>");
    }

    [Test]
    public void Test_StandartBoldWords()
    {
        Md.Render("__WORD__ BOB __PON__").Should().Be("<strong>WORD</strong> BOB <strong>PON</strong>");
        Md.Render("__aaaa__bbbb__cc__").Should().Be("<strong>aaaa</strong>bbbb<strong>cc</strong>");
    }

    [Test]
    public void Test_BoldWithOtherTags()
    {
        Md.Render("#  __aaa__").Should().Be("<h1><strong>aaa</strong></h1>");
        Md.Render("__aaa_b_a__").Should().Be("<strong>aaa<em>b</em>a</strong>");
    }

    [Test]
    public void Test_BoldInPartOfWord()
    {
        Md.Render("__нач__але").Should().Be("<strong>нач</strong>але");
        Md.Render("сер__еди__не").Should().Be("сер<strong>еди</strong>не");
        Md.Render("кон__це.__").Should().Be("кон<strong>це.</strong>");
    }

    [Test]
    public void Test_BoldSeveralWords()
    {
        Md.Render("ра__зных сл__овах").Should().Be("ра__зных сл__овах");
        Md.Render("ра__зных словах__").Should().Be("ра__зных словах__");
    }

    [Test]
    public void Test_BoldTextWithSpaces()
    {
        Md.Render("__ подчерки__").Should().Be("__ подчерки__");
        Md.Render("__подчерки __").Should().Be("__подчерки __");
    }

}