﻿using DataAccess.Questions.Abstractions;

namespace BusinessLogic.Questions.Implementations
{
    using System;

    public class BaseLogic
    {
        protected readonly IRepository _repository;

        public BaseLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
    }
}
