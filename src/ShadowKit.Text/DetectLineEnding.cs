using System;
using System.Linq;

namespace ShadowKit.Text
{
    /// <summary>
    /// Represents the different types of line endings that may be present in a string.
    /// </summary>
    public enum LineEndingKind
    {
        /// <summary>
        /// Represents an undefined or unrecognized type of line ending.
        /// This value is used when the line ending format cannot be determined.
        /// </summary>
        Unknown,

        /// <summary>
        /// Represents the Windows line ending format, specifically using a Carriage Return
        /// followed by a Line Feed ('\r\n') as the delimiter between lines.
        /// </summary>
        Windows,

        /// <summary>
        /// Represents the Unix line ending style, which uses a single line feed character ('\n') to terminate lines.
        /// </summary>
        Unix,

        /// <summary>
        /// Represents the line ending style used in classic Mac OS, which uses a carriage return ('\r') character.
        /// </summary>
        Mac,

        /// <summary>
        /// Represents a mixed line ending style where multiple types of line endings
        /// (e.g., Windows, Unix, or Mac) are simultaneously present in a given input.
        /// </summary>
        Mixed
    }

    /// <summary>
    /// Detects the <see cref="LineEndingKind"/> of a given <see cref="string"/>
    /// </summary>
    public sealed class DetectLineEnding
    {
        /// <summary>
        /// Detects the type of line endings used in the given text input.
        /// </summary>
        /// <param name="input">
        /// A string containing the text whose line endings are to be detected.
        /// </param>
        /// <returns>
        /// A value of the <see cref="LineEndingKind"/> enumeration representing the type of line endings
        /// detected in the input. Returns <see cref="LineEndingKind.Unknown"/> if no line endings are detected,
        /// or <see cref="LineEndingKind.Mixed"/> the line endings are not consistent.
        /// </returns>
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