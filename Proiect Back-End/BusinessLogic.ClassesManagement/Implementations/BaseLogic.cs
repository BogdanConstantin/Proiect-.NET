namespace BusinessLogic.ClassesManagement.Implementations
{
    using System;

    using DataAccess.ClassesManagement.Abstractions;

    public class BaseLogic
    {
        protected readonly IRepository _repository;

        public BaseLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
    }
}
