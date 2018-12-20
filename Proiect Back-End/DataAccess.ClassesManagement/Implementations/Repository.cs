namespace DataAccess.ClassesManagement.Implementations
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using DataAccess.ClassesManagement.Abstractions;

    using Entities.ClassesManagement;

    public class Repository: IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Insert<T>(T entity)
            where T : BaseEntity
        {
            entity.LastChangeDate = DateTime.Now;
            _context.Set<T>().Add(entity);
        }

        public T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().OrderByDescending(o => o.LastChangeDate).FirstOrDefault(filter);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
