using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Notifications.Abstractions
{
    public interface IRepository
    {
        void Insert<T>(T entity)
            where T : BaseEntity;

        T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity;

        ICollection<T> GetAll<T>()
           where T : BaseEntity;

        void Save();
    }
}
