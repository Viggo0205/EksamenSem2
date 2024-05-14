using EksamenSem2.Services.Interfaces;

public interface IDataService<T> where T : class, IHasId
{
    int Create(T t);

    T? Read(int id);

    bool Delete(int id); // T? bool Delete(int id); - ???, ville hjælpe til delete af medarbejder i FjernMedarbejder.cshtml.cs

    List<T> GetAll();
}

