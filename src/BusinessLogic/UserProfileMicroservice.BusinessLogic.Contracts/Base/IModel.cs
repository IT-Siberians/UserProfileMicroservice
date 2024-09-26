namespace UserProfileMicroservice.BusinessLogic.Contracts.Base;

public interface IModel<out TId>
    where TId : struct
{
    public TId Id { get; }
}
