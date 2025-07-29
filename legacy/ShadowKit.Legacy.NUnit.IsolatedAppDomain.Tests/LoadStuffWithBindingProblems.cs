using LibOne;
using LibTwo;
using NUnit.Framework;

namespace ShadowKit.Legacy.NUnit.IsolatedAppDomain.Tests;

[TestFixture]
public class LoadStuffWithBindingProblems
{
    [Test]
    [IsolatedAppDomain]
    public void Execute()
    {
        One.DoIt();
        Two.DoIt();
    }
}