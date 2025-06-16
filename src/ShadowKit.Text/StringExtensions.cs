using System.Collections.Generic;
using System.IO;

namespace ShadowKit.Text;

public static class StringExtensions
{
    public static IEnumerable<string> ToLines(this string input)
    {
        using var stringReader = new StringReader(input);

        while (stringReader.ReadLine() is { } line)
        {
            yield return line;
        }
    }
}