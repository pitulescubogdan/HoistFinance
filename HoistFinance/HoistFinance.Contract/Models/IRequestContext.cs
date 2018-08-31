using System.Linq;

namespace HoistFinance.Contract.ContextInterface
{
    using HoistFinance.Contract.Models;

    public interface IRequestContext
    {
        IQueryable<RequestModel> Requests { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
    }
}