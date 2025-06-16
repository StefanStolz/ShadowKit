using System.Text;

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

        [Test]
        public void DetectMixed()
        {
            const string encodedText =
                "cHVibGljIHNlYWxlZCBwYXJ0aWFsIGNsYXNzIE51bGxTb21lSW50ZXJmYWNlIDogSVNvbWVJbnRlcmZhY2UNCnsNCiAgcHJpdmF0ZSBOdWxsU29tZUludGVyZmFjZSgpDQogIHt9DQoNCiAgcHVibGljIHN0YXRpYyBJU29tZUludGVyZmFjZSBJbnN0YW5jZSB7IGdldDsgfSA9IG5ldyBOdWxsU29tZUludGVyZmFjZSgpOw0KDQogICAgcHVibGljIFN5c3RlbS5UaHJlYWRpbmcuVGFza3MuVGFzayBNZXRob2QoaW50IHZhbHVlKQogIHsKICAgICByZXR1cm4gVGFzay5Db21wbGV0ZWRUYXNrOwogIH0KCiAgcHVibGljIFN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLklFbnVtZXJhYmxlPHN0cmluZz4gR2V0SXRlbXMoKQogIHsKICAgICB5aWVsZCBicmVhazsKICB9CgoNCn0=";

            var sut = new DetectLineEnding();

            var result = sut.DetectFromString(Encoding.UTF8.GetString(Convert.FromBase64String(encodedText)));

            result.ShouldBe(LineEndingKind.Mixed);
        }
    }
}