﻿using System;
using System.Collections.Generic;

namespace DataAccess.Authentication.Implementations
{
    using System.Linq;
    using System.Linq.Expressions;

    using DataAccess.Authentication.Abstractions;

    using Entities.Authentication;

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
            _context.Set<T>().Add(entity);
        }

        public T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().FirstOrDefault(filter);
        }

        public ICollection<T> GetAll<T>()
            where T : BaseEntity
        {
            return _context.Set<T>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
