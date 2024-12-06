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
        Md.Render("# aa# aa# aa# aa# aa# aa").Should().Be("<h1>aa# aa# aa# aa# aa# aa</h1>");
        Md.Render("# abb" + "\n" + "ba_").Should().Be("<h1>abb</h1>ba_");

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
        Md.Render("# Заголовок __с _разными_ символами__").Should().Be("<h1>Заголовок <strong>с <em>разными</em> символами</strong></h1>");
        Md.Render("# __bold _italic_ text__").Should().Be("<h1><strong>bold <em>italic</em> text</strong></h1>");
        Md.Render("# __bold _italic_ text__\n").Should().Be("<h1><strong>bold <em>italic</em> text</strong></h1>\n");
    }
}