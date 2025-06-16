using System;
using System.Linq;

namespace ShadowKit.Text
{
    public enum LineEndingKind
    {
        Unknown,
        Windows,
        Unix,
        Mac,
        Mixed
    }

    /// <summary>
    /// Detects the <see cref="LineEndingKind"/> of a given <see cref="string"/>
    /// </summary>
    public sealed class DetectLineEnding
    {
        public LineEndingKind DetectFromString(string input)
        {
            int lfCount = input.Count(c => c == '\n');
            int crCount = input.Count(c => c == '\r');
            int crlfCount = input.Split(new[] { "\r\n" }, StringSplitOptions.None).Length - 1;

            if (crlfCount == 0 && crCount == 0 && lfCount == 0)
            {
                return LineEndingKind.Unknown;
            }

            if (crlfCount > 0 && crlfCount == lfCount && crlfCount == crCount)
            {
                return LineEndingKind.Windows;
            }

            if (crCount > 0 && lfCount == 0)
            {
                return LineEndingKind.Mac;
            }

            if (lfCount > 0 && crCount == 0)
            {
                return LineEndingKind.Unix;
            }

            return LineEndingKind.Mixed;
        }
    }
}