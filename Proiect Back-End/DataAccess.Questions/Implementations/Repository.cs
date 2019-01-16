using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Questions.Abstractions;
using Entities.Questions;

namespace DataAccess.Questions.Implementations
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
        {
            entity.LastChangeDate = DateTime.Now;
            _context.Set<T>().Add(entity);
        }

        public T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().OrderByDescending(o => o.LastChangeDate).FirstOrDefault(filter);
        }

        public ICollection<T> GetAll<T>() where T : BaseEntity => _context.Set<T>()
            .Where(x => x.DeletedDate == null)
            .GroupBy(group => group.EntityId)
            .Select(group => group.OrderByDescending(x => x.LastChangeDate)
                .FirstOrDefault())
            .ToList();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
