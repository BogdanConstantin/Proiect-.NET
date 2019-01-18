namespace BusinessLogic.FilesHandler.Implementations
{
    using System;
    using DataAccess.FilesHandler.Abstractions;

    public class BaseLogic
    {
        protected readonly IRepository _repository;

        public BaseLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
    }
}
