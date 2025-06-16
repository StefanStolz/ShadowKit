using System;

namespace ShadowKit.Text;

internal sealed class LineSplitterItem : IEquatable<LineSplitterItem>
{
    public bool Equals(LineSplitterItem? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return string.Equals(this.Value, other.Value, StringComparison.Ordinal) && this.Kind == other.Kind;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || (obj is LineSplitterItem other && this.Equals(other));
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (this.Value.GetHashCode() * 397) ^ (int)this.Kind;
        }
    }

    public static bool operator ==(LineSplitterItem? left, LineSplitterItem? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(LineSplitterItem? left, LineSplitterItem? right)
    {
        return !Equals(left, right);
    }

    public string Value { get; }
    public LineSplitterKind Kind { get; }

    public LineSplitterItem(string value, LineSplitterKind kind)
    {
        this.Value = value;
        this.Kind = kind;
    }
}