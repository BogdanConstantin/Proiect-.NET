using DataAccess.Notifications.Abstractions;
using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Notifications.Implementations
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Insert<T>(T entity)
            where T : BaseEntity
        {}

        public T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return null;

        }

        public ICollection<T> GetAll<T>() where T : BaseEntity
        {
            return null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
