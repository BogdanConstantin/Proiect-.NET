namespace DataAccess.ClassesManagement.Write.Abstractions
{
    using System;
    using System.Linq.Expressions;

    using Entities.ClassesManagement;

    public interface IRepository
    {
        void Insert<T>(T entity)
            where T : BaseEntity;

        T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity;

        void Save();
    }
}
