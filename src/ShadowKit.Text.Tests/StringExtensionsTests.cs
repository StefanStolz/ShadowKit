namespace ShadowKit.Text.Tests;

[TestFixture]
public class StringExtensionsTests
{
    [Test]
    [TestCaseSource(nameof(ToLinesTestCaseData))]
    public void ToLines(string input, IEnumerable<string> expected)
    {
        var result = input.ToLines();

        result.ShouldBe(expected);
    }

    public static IEnumerable<TestCaseData> ToLinesTestCaseData()
    {
        yield return new TestCaseData("abc", new[] { "abc" });
        yield return new TestCaseData("""
                                      abc
                                      def
                                      """, new[] { "abc", "def" });

        yield return new TestCaseData("""
                                      abc

                                      def
                                      """, new[] { "abc", "", "def" });
    }
}