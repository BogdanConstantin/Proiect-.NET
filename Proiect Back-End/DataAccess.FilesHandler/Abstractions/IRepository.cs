﻿namespace DataAccess.FilesHandler.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Entities.FilesHandler;

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
