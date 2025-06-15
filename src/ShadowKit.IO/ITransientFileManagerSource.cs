using System.IO;

namespace ShadowKit.IO;

public interface ITransientFileManagerSource
{
    string FileName { get; }
    Stream GetDataStream();
}