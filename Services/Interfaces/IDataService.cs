using EksamenSem2.Services.Interfaces;

public interface IDataService<T> where T : class, IHasId
{
    int Create(T t);

    T? Read(int id);

    bool Delete(int id);

    List<T> GetAll();
}

