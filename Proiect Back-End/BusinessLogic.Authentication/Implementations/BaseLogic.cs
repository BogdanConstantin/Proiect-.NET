using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Authentication.Implementations
{
    using DataAccess.Authentication.Abstractions;

    public class BaseLogic
    {
        protected readonly IRepository _repository;

        public BaseLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
    }
}
