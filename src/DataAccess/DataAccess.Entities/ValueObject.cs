using System.Runtime.CompilerServices;

namespace DataAccess.Entities;

public abstract class ValueObject<T>
{
    public readonly T Value;

    public ValueObject(T value)
    {
        if (!Valydate(value))
            throw new ArgumentException($"Value is not valid");
        this.Value = value;
    }

    public abstract bool Valydate(T value);
}