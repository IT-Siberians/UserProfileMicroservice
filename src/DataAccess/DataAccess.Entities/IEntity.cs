namespace DataAccess.Entities;

public interface IEntity<TId>
{
    TId Id { get; }
}
