
using EksamenSem2.Models;
using EksamenSem2.Services.Interfaces;

public class EFCoreDataServiceBase<T> : IDataService<T> where T : class, IHasId
{


    public List<T> GetAll()
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        return GetAllWithIncludes(context).ToList();
    }

    public virtual int Create(T t)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        context.Set<T>().Add(t);
        context.SaveChanges();

        return t.Id;
    }

    public T? Read(int id)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        return GetAllWithIncludes(context).FirstOrDefault(t => t.Id == id);
    }

    public bool Delete(int id)
    {
        using auden_dk_db_eksamenContext context = new auden_dk_db_eksamenContext();

        T? tEx = context.Set<T>().Find(id);
        if (tEx == null)
            return false;

        context.Set<T>().Remove(tEx);
        return (context.SaveChanges() > 0);
    }

    protected virtual IQueryable<T> GetAllWithIncludes(auden_dk_db_eksamenContext context)
    {
        return context.Set<T>();
    }
}
