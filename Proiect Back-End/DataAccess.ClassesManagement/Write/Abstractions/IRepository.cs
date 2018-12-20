namespace DataAccess.ClassesManagement.Write.Abstractions
{
    using Entities.ClassesManagement;

    public interface IRepository
    {
        void Insert<T>(T entity)
            where T : BaseEntity;

        void Save();
    }
}
