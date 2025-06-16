using System.Text;

namespace ShadowKit.Text.Tests;

[TestFixture]
[TestOf(typeof(StringComparerBuilder))]
public class StringComparerBuilderTests
{

    [Test]
    public void BuildComparerIgnoringLineEndings()
    {
        var input1 = "one\ntwo\nthree";
        var input2 = "one\r\ntwo\r\nthree";

        var sut = new StringComparerBuilder().IgnoreLineEndings().Build();

        var result = sut.Equals(input1, input2);

        result.ShouldBeTrue();
    }

    [Test]
    public void TrimLines()
    {
        var input1 = "  one\ntwo  ";
        var input2 = "one\ntwo";

        var sut = new StringComparerBuilder().TrimLines().Build();

        var result = sut.Equals(input1, input2);

        result.ShouldBeTrue();
    }

    [Test]
    public void TrimLinesWithDifferentLineEndings()
    {
        var input1 = "  one\ntwo  ";
        var input2 = "one\r\ntwo";

        var sut = new StringComparerBuilder().TrimLines().Build();

        var result = sut.Equals(input1, input2);

        result.ShouldBeFalse();
    }

    [Test]
    public void CompareStringsWithMixesLineEndings()
    {
        const string a = "cHVibGljIHNlYWxlZCBwYXJ0aWFsIGNsYXNzIE51bGxTb21lSW50ZXJmYWNlIDogSVNvbWVJbnRlcmZhY2UNCnsNCiAgcHJpdmF0ZSBOdWxsU29tZUludGVyZmFjZSgpDQogIHt9DQoNCiAgcHVibGljIHN0YXRpYyBJU29tZUludGVyZmFjZSBJbnN0YW5jZSB7IGdldDsgfSA9IG5ldyBOdWxsU29tZUludGVyZmFjZSgpOw0KDQogICAgcHVibGljIFN5c3RlbS5UaHJlYWRpbmcuVGFza3MuVGFzayBNZXRob2QoaW50IHZhbHVlKQogIHsKICAgICByZXR1cm4gVGFzay5Db21wbGV0ZWRUYXNrOwogIH0KCiAgcHVibGljIFN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLklFbnVtZXJhYmxlPHN0cmluZz4gR2V0SXRlbXMoKQogIHsKICAgICB5aWVsZCBicmVhazsKICB9CgoNCn0=";
        const string b = "cHVibGljIHNlYWxlZCBwYXJ0aWFsIGNsYXNzIE51bGxTb21lSW50ZXJmYWNlIDogSVNvbWVJbnRlcmZhY2UNCnsNCiAgcHJpdmF0ZSBOdWxsU29tZUludGVyZmFjZSgpDQogIHt9DQoNCiAgcHVibGljIHN0YXRpYyBJU29tZUludGVyZmFjZSBJbnN0YW5jZSB7IGdldDsgfSA9IG5ldyBOdWxsU29tZUludGVyZmFjZSgpOw0KDQpwdWJsaWMgU3lzdGVtLlRocmVhZGluZy5UYXNrcy5UYXNrIE1ldGhvZChpbnQgdmFsdWUpDQp7DQogICByZXR1cm4gVGFzay5Db21wbGV0ZWRUYXNrOw0KfQ0KDQpwdWJsaWMgU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuSUVudW1lcmFibGU8c3RyaW5nPiBHZXRJdGVtcygpDQp7DQogICB5aWVsZCBicmVhazsNCn0NCg0KDQp9";

        var value = Encoding.UTF8.GetString(Convert.FromBase64String(a));
        var expected = Encoding.UTF8.GetString(Convert.FromBase64String(b));

        var sut = new StringComparerBuilder().TrimLines().IgnoreLineEndings().Build();

        var result = sut.Equals(value, expected);

        result.ShouldBeTrue();
    }
}