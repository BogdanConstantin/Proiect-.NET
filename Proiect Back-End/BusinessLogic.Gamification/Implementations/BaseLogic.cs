using System;
using DataAccess.Gamification.Abstractions;

namespace BusinessLogic.Gamification.Implementations
{
    public class BaseLogic
    {
        protected readonly IRepository _repository;

        public BaseLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
    }
}
