using System.Linq;

namespace HoistFinance.Contract
{
    using HoistFinance.Contract.ContextInterface;
    using HoistFinance.Contract.Models;
    using System.Data.Entity;

    public class RequestsContext : DbContext, IRequestContext
    {
        public DbSet<RequestModel> Requests { get; set; }
        public RequestsContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<RequestModel>();
            config.ToTable("Requests");
        }

        IQueryable<RequestModel> IRequestContext.Requests
        {
            get { return Requests; }
        }
        int IRequestContext.SaveChanges()
        {
            return SaveChanges();
        }

        T IRequestContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        T IRequestContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    }
}