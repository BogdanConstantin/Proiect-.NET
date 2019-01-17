using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Questions.Abstractions;
using FluentValidation;
using FluentValidation.Results;
using Models.Questions;

namespace BusinessLogic.Questions.Validations
{
    public class AnswerValidator: AbstractValidator<AnswerDto>
    {
        private IRepository _repository;
        private int maxAnswerLength = 100;
        public AnswerValidator( IRepository repository)
        {
            _repository = repository;

            RuleFor(answerDto => answerDto.AnswerString)
                .NotEmpty()
                .NotNull()
                .Length(1, this.maxAnswerLength);


            RuleFor(answerDto => answerDto.QuestionId)
                .NotEmpty()
                .NotNull()
                .Must(BaseValidator.IsGuid);
        }
        protected override bool PreValidate(ValidationContext<AnswerDto> validationContext, ValidationResult result)
        {
            if (!BaseValidator.CheckQuestion(_repository, validationContext, result))
            {
                return false;
            }

            return base.PreValidate(validationContext, result);
        }

    }
}
