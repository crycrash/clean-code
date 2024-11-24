using FluentAssertions;
using Markdown;
namespace MarkdownTests;

public class BorderlineCasesTests
{

    [Test]
    public void Test_TextWithDigits()
    {
        Md.Render("_aaa12_3_a_").Should().Be("<em>aaa12_3_a</em>");
        Md.Render("123_44__9").Should().Be("123_44__9");
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
    }

    [Test]
    public void Test_IntersectionOfTags()
    {
        Md.Render("__пересечения _двойных__ и одинарных_").Should().Be("__пересечения _двойных__ и одинарных_");
        Md.Render("_пересечения __двойных_ и одинарных__").Should().Be("_пересечения __двойных_ и одинарных__");
    }
}