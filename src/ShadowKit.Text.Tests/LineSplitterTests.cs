namespace ShadowKit.Text.Tests;

[TestFixture]
[TestOf(typeof(LineSplitter))]
public class LineSplitterTests
{
    [Test]
    public void SingleLineWithText()
    {
        var sut = new LineSplitter(LineEnding.Unix);
        var result = sut.Execute("Hello World");

        result.Count.ShouldBe(1);
        result[0].Value.ShouldBe("Hello World");
        result[0].Kind.ShouldBe(LineSplitterKind.Text);
    }

    [Test]
    public void TwoLinesDelimitedByNewLine()
    {
        var sut = new LineSplitter(LineEnding.Unix);
        var result = sut.Execute("Hello\nWorld");
        result.Count.ShouldBe(3);
        result[0].Value.ShouldBe("Hello");
        result[0].Kind.ShouldBe(LineSplitterKind.Text);
        result[1].Value.ShouldBe("\n");
        result[1].Kind.ShouldBe(LineSplitterKind.LineEnding);
        result[2].Value.ShouldBe("World");
        result[2].Kind.ShouldBe(LineSplitterKind.Text);
    }

    [Test]
    public void DetectMultipleLineEndings()
    {
        var sut = new LineSplitter(LineEnding.Windows);
        var result  = sut.Execute($"a\r\n\r\nb");

        result.Count.ShouldBe(4);
    }
}