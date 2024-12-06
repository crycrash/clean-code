using FluentAssertions;
using Markdown;
namespace MarkdownTests;

public class BorderlineCasesTests
{

    [Test]
    public void Test_TextWithDigits()
    {
        Md.Render("_aaa12_3_a_").Should().Be("<em>aaa12_3_a</em>");
        Md.Render("__aaa12_3_a__").Should().Be("<strong>aaa12_3_a</strong>");
        Md.Render("_123_").Should().Be("<em>123</em>");
        Md.Render("__123__").Should().Be("<strong>123</strong>");
        Md.Render("__12__3").Should().Be("__12__3");
        Md.Render("_12_3").Should().Be("_12_3");
        Md.Render("__aaa12__3__a").Should().Be("<strong>aaa12__3</strong>a");
        Md.Render("_aaa12__3__a_").Should().Be("<em>aaa12__3__a</em>");
        Md.Render("__aaa12__3__a__").Should().Be("<strong>aaa12__3__a</strong>");
    }

    [Test]
    public void Test_TagsWithoutText()
    {
        Md.Render("____").Should().Be("____");
        Md.Render("___").Should().Be("___");
        Md.Render("__").Should().Be("__");
        Md.Render("_").Should().Be("_");
    }
    [Test]
    public void Test_TextWithUnpairedTags()
    {
        Md.Render("__Непарные_").Should().Be("__Непарные_");
        Md.Render("_Непарные__").Should().Be("_Непарные__");
        Md.Render("__s_ __s").Should().Be("__s_ __s");
        Md.Render("__s _s__").Should().Be("<strong>s _s</strong>");
        Md.Render("__s_ s__").Should().Be("<strong>s_ s</strong>");
    }

    [Test]
    public void Test_IntersectionOfTags()
    {
        Md.Render("_a __bbb__ a_").Should().Be("<em>a __bbb__ a</em>");
        Md.Render("__s _s__ _d_").Should().Be("<strong>s _s</strong> <em>d</em>");
        Md.Render("__s _s__ _d_").Should().Be("<strong>s _s</strong> <em>d</em>");
        Md.Render("__a _bbb__ a_").Should().Be("__a _bbb__ a_");
        Md.Render("a__ b_ _c __bb").Should().Be("a__ b_ _c __bb");
        Md.Render("__пересечения _двойных__ и одинарных_").Should().Be("__пересечения _двойных__ и одинарных_");
        Md.Render("_пересечения __двойных_ и одинарных__").Should().Be("_пересечения __двойных_ и одинарных__");
    }
}