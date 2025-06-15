using System.Reflection;

namespace ShadowKit.IO.Tests;

[TestFixture]
public class TransientFileManagerTests
{
    [Test]
    public void TempFileFromEmbeddedResource()
    {
        EmbeddedResourceFileSource embeddedResourceFileSource =
            new EmbeddedResourceFileSource(
                Assembly.GetExecutingAssembly(),
                "SomeTextFile.txt",
                "ShadowKit.IO.Tests.Assets");

        string path;
        using (TransientFileManager sut = new TransientFileManager(embeddedResourceFileSource))
        {
            path = sut.CreateTempVersionOfFile();

            Assert.That(File.Exists(path), Is.True);
        }

        Assert.That(File.Exists(path), Is.False);
    }
}