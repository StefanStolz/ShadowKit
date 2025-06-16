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

        result.ShouldBe([new LineSplitterItem("Hello World", LineSplitterKind.Text)]);
    }

    [Test]
    public void TwoLinesDelimitedByNewLine()
    {
        var sut = new LineSplitter(LineEnding.Unix);
        var result = sut.Execute("Hello\nWorld");

        result.ShouldBe([
            new LineSplitterItem("Hello", LineSplitterKind.Text),
            new LineSplitterItem("\n", LineSplitterKind.LineEnding),
            new LineSplitterItem("World", LineSplitterKind.Text)
        ]);
    }

    [Test]
    public void DetectMultipleLineEndings()
    {
        var sut = new LineSplitter(LineEnding.Windows);
        var result = sut.Execute("a\r\n\r\nb");

        result.Count.ShouldBe(4);
    }
}