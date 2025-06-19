using System.Collections.Generic;
using System.IO;

namespace ShadowKit.Text;

public static class StringExtensions
{
    /// <summary>
    /// Splits the input string into its individual lines.
    /// </summary>
    /// <param name="input">The input string to be split into lines.</param>
    /// <returns>
    /// An enumerable collection of strings, where each string represents a line from the input.
    /// </returns>
    public static IEnumerable<string> ToLines(this string input)
    {
        using var stringReader = new StringReader(input);

        while (stringReader.ReadLine() is { } line)
        {
            yield return line;
        }
    }
}