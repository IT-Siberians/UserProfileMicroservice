namespace UserProfileMicroservice.DataAccess.Entities.Base;

public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; protected set; } = id;

    public override bool Equals(object? obj)
        => obj is Entity<TId> other && Id.Equals(other.Id);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Entity<TId>? other)
        => other is not null && Id.Equals(other.Id);

    public override string ToString()
        => Id.ToString() ?? Id.GetType().ToString();

    public static bool operator ==(Entity<TId> first, Entity<TId> second)
    {
        if (ReferenceEquals(first, second))
            return true;
        return !first.Id.Equals(default(TId)) && first.Equals(second);
    }
    public static bool operator !=(Entity<TId> first, Entity<TId> second)
        => !(first == second);
}