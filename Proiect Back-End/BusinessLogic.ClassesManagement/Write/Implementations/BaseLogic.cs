using System;

namespace BusinessLogic.ClassesManagement.Write.Implementations
{
    using DataAccess.ClassesManagement.Write.Abstractions;

    public class BaseLogic
    {
        protected readonly IRepository _repository;

        public BaseLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
    }
}
