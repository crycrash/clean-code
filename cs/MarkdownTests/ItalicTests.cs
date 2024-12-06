using Markdown;
using FluentAssertions;
using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
namespace MarkdownTests;

public class ItailcTests
{
    [Test]
    public void Test_StandartItalicText()
    {
        Md.Render("_abc w_ a _b s_").Should().Be("<em>abc w</em> a <em>b s</em>");
        Md.Render("_aaaa_").Should().Be("<em>aaaa</em>");
        Md.Render("_aaaa_bbbb_cc_").Should().Be("<em>aaaa</em>bbbb<em>cc</em>");
        Md.Render("_aaaa_  bbb").Should().Be("<em>aaaa</em>  bbb");
        Md.Render("_aaaa_    _bbbb_ _cc_").Should().Be("<em>aaaa</em>    <em>bbbb</em> <em>cc</em>");
        Md.Render("_aaa   bbb_").Should().Be("<em>aaa   bbb</em>");
        Md.Render("_abc_4_").Should().Be("<em>abc_4</em>");
        Md.Render("ab_c_de").Should().Be("ab<em>c</em>de");
        Md.Render("ab_c d_a").Should().Be("ab_c d_a");
        Md.Render("\\ _a_").Should().Be("\\ <em>a</em>");
        Md.Render("_bbb" + "\n" + "bb_").Should().Be("<em>bbb" + "\n" + "bb</em>");
    }

    [Test]
    public void Test_NestedInItalicTags()
    {
        Md.Render("_some __text__ in_").Should().Be("<em>some __text__ in</em>");
        Md.Render("#  _aaa_").Should().Be("<h1><em>aaa</em></h1>");
        Md.Render("_aaa__b__a_").Should().Be("<em>aaa__b__a</em>");
        Md.Render("_aaa __b__ a_").Should().Be("<em>aaa __b__ a</em>");
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
        Md.Render("ра_зных словах_").Should().Be("ра_зных словах_");
    }

    [Test]
    public void Test_ItalicTextWithSpaces()
    {
        Md.Render("_ подчерки_").Should().Be("_ подчерки_");
        Md.Render("_подчерки _").Should().Be("_подчерки _");
    }
}