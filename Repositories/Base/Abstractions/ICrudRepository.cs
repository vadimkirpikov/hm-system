namespace HousingManagementService.Repositories.Base.Abstractions;

public interface ICrudRepository<T, TView> : ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>,
    IReadRepository<TView>;
