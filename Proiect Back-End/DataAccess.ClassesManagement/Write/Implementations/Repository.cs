using System;

namespace DataAccess.ClassesManagement.Write.Implementations
{
    using DataAccess.ClassesManagement.Write.Abstractions;

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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
