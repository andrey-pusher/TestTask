namespace Domain.Interfaces.Base;

public interface IReadable<TId, TModel>
    where TId : struct
    where TModel : IIdentifable<TId>
{
    TModel Read(TId id);
}
