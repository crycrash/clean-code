using Markdown;
using FluentAssertions;

namespace MarkdownTests;

public class HeadingTests
{
    [Test]
    public void Test_StandartHeading()
    {
        Md.Render("# aaa" + '\n' + "#  bbb").Should().Be("<h1>aaa</h1>" + '\n' + "<h1>bbb</h1>");
        Md.Render("# aaa bbb" + '\n' + "#  bbb").Should().Be("<h1>aaa bbb</h1>" + '\n' + "<h1>bbb</h1>");
        Md.Render("# aaaa").Should().Be("<h1>aaaa</h1>");
        Md.Render("#aaaa").Should().Be("#aaaa");
        Md.Render("#     aaa" + '\n' + "bbb").Should().Be("<h1>aaa</h1>" + '\n' + "bbb");
        
    }
    [Test]
    public void Test_HeadingTagsWithoutText()
    {
        Md.Render("#").Should().Be("#");
        Md.Render("##").Should().Be("##");
    }

    [Test]
    public void Test_HeadingWithOtherTags()
    {
        Md.Render("# __a__" + "\n" + "#  _b_").Should().Be("<h1><strong>a</strong></h1>" + '\n' + "<h1><em>b</em></h1>");
    }
}