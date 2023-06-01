namespace Domain.Interfaces.Base;

public interface IUpdatable<TId, TModel>
    where TId : struct
    where TModel : IIdentifable<TId>
{
    TModel Update(TModel model);
}
