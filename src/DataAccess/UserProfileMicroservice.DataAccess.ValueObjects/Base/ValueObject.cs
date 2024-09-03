using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions;

namespace UserProfileMicroservice.DataAccess.ValueObjects.Base;

public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
{
    public readonly T Value;

    protected ValueObject(T value)
    {
        Validate(value);
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    protected abstract void Validate(T value);

    public override string ToString()
    {
        return Value?.ToString() ?? GetType().ToString();
    }

    public override int GetHashCode()
    {
        return Value!.GetHashCode();
    }

    public override bool Equals(object? other)
        => Equals(other as ValueObject<T>);

    public bool Equals(ValueObject<T>? other)
    {
        if (ReferenceEquals(this, other))
            return true;
        if (other is null)
            return false;
        if (GetType() != other.GetType())
            return false;
        return other.Value!.Equals(Value);
    }

    public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
        => left is null ? false : left.Equals(right);

    public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
        => !(left == right);
}