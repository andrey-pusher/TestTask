namespace Domain.Interfaces.Base;

public interface IIdentifable<TId> where TId : struct
{
    public TId Id { get; set; }
}
