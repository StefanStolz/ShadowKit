
namespace ShadowKit.Text.Tests
{
    [TestFixture]
    [TestOf(typeof(DetectLineEnding))]
    public class DetectLineEndingTests
    {

        [Test]
        public void DetectUnknownIfNoEndings()
        {
           var sut = new DetectLineEnding();

           var result = sut.DetectFromString("abcd");

           result.ShouldBe(LineEndingKind.Unknown);
        }

        [Test]
        public void DetectWindows()
        {
            var sut = new DetectLineEnding();

            var result = sut.DetectFromString("a\r\nb");

            result.ShouldBe(LineEndingKind.Windows);
        }

        [Test]
        public void DetectUnix()
        {
            var sut = new DetectLineEnding();

            var result = sut.DetectFromString("a\nb");

            result.ShouldBe(LineEndingKind.Unix);
        }

        [Test]
        public void DetectMac()
        {
            var sut = new DetectLineEnding();

            var result = sut.DetectFromString("a\rb");

            result.ShouldBe(LineEndingKind.Mac);
        }
    }
}