using NUnit.Framework;

namespace ShadowKit.Legacy.NUnit.IsolatedAppDomain.Tests;

public class AcceptanceTests
{
    public static int Value { get; set; }

    [Test]
    [IsolatedAppDomain]
    [Order(1)]
    public void RunInOtherDomain()
    {
        Value = 1;

        Assert.That(false, Is.True);
    }

    [Test]
    [Order(2)]
    public void Test2()
    {
        Assert.That(true, Is.True);

        Assert.That(Value, Is.EqualTo(0));

        Value = 2;
    }

    [Test]
    [Order(3)]
    public void Test3()
    {
        Assert.That(Value, Is.EqualTo(2));
    }
}
