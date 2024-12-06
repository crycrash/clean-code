using FluentAssertions;
using Markdown;

namespace MarkdownTests;

public class BoldTests
{
    [Test]
    public void Test_StandartBoldWord()
    {
        Md.Render("__abc__4__").Should().Be("<strong>abc__4</strong>");
        Md.Render("__abc__4").Should().Be("__abc__4");
        Md.Render("__aa    bb__  __cc   aa__").Should().Be("<strong>aa    bb</strong>  <strong>cc   aa</strong>");
        Md.Render("__aa    bb__").Should().Be("<strong>aa    bb</strong>");
        Md.Render("__aaaa__").Should().Be("<strong>aaaa</strong>");
        Md.Render("__aa__ __bb__" + '\n' + "__aa__ __bb__").Should().Be("<strong>aa</strong> <strong>bb</strong>" + '\n' + "<strong>aa</strong> <strong>bb</strong>");
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
        Md.Render("#  __aaa __").Should().Be("<h1>__aaa __</h1>");
        Md.Render("_a __bbb__").Should().Be("_a <strong>bbb</strong>");
        Md.Render("__a _bbb__").Should().Be("<strong>a _bbb</strong>");
        Md.Render("#  __aaa__ __bb__").Should().Be("<h1><strong>aaa</strong> <strong>bb</strong></h1>");
        Md.Render("__aaa _b_  _cc_ a__").Should().Be("<strong>aaa <em>b</em>  <em>cc</em> a</strong>");
        Md.Render("__aaa _b_  _cc _ a__").Should().Be("<strong>aaa <em>b</em>  _cc _ a</strong>");
    }

    [Test]
    public void Test_BoldInPartOfWord()
    {
        Md.Render("__нач__але").Should().Be("<strong>нач</strong>але");
        Md.Render("сер__еди__не").Should().Be("сер<strong>еди</strong>не");
        Md.Render("кон__це.__").Should().Be("кон<strong>це.</strong>");
        Md.Render("aa  сер__еди__не").Should().Be("aa  сер<strong>еди</strong>не");
        Md.Render("кон__це.__ bb").Should().Be("кон<strong>це.</strong> bb");
    }

    [Test]
    public void Test_BoldSeveralWords()
    {
        Md.Render("ра__зных словах__").Should().Be("ра__зных словах__");
        Md.Render("ра__зных сл__овах").Should().Be("ра__зных сл__овах");
    }

    [Test]
    public void Test_BoldTextWithSpaces()
    {
        Md.Render("__ подчерки__").Should().Be("__ подчерки__");
        Md.Render("__подчерки __").Should().Be("__подчерки __");
    }
}