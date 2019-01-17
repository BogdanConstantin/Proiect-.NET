using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using DataAccess.Questions.Abstractions;
using Entities.Questions;
using FluentValidation.Results;
using Models.Questions;

namespace BusinessLogic.Questions.Validations
{
   public static class BaseValidator
    {
        public static bool IsGuid(Guid candidate)
        {
            Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

            if (isGuid.IsMatch(candidate.ToString()))
            {
                return true;
            }

            return false;
        }

        public static bool CheckQuestion(IRepository repository, FluentValidation.ValidationContext<AnswerDto> validationContext, ValidationResult validationResult)
        {
            var course = repository.GetLastByFilter<Question>(x => x.Id == validationContext.InstanceToValidate.QuestionId);

            if (course == null)
            {
                validationResult.Errors.Add(new ValidationFailure("QuestionId", "The Question with this id was not found!"));
                return false;
            }

            return true;
        }
    }
}
