using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Models.Questions;

namespace BusinessLogic.Questions.Validations
{
    public class QuestionValidator : AbstractValidator<QuestionDto>
    {
        private int maxQuestionLength = 100;
        public QuestionValidator()
        {
            RuleFor(questionDto => questionDto.QuestionString)
                .NotEmpty()
                .NotNull()
                .Length(1, this.maxQuestionLength);
        }
    }
}
