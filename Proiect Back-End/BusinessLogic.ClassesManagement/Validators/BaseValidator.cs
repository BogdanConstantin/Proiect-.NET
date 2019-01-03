using System;

namespace BusinessLogic.ClassesManagement.Validators
{
    using System.Text.RegularExpressions;

    using DataAccess.ClassesManagement.Abstractions;

    using Entities.ClassesManagement;

    using FluentValidation.Results;

    using Models.ClassesManagement;

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

        public static bool UserPositionIsValid(string userPosition)
        {
            return Enum.TryParse(typeof(UserPosition), userPosition, out _);
        }

        public static bool CheckCourse(IRepository repository, FluentValidation.ValidationContext<ManagementDto> validationContext, ValidationResult validationResult)
        {
            var course = repository.GetLastByFilter<Course>(x => x.Id == validationContext.InstanceToValidate.ClassId);

            if (course == null)
            {
                validationResult.Errors.Add(new ValidationFailure("ClassId", "The Course with this id was not found!"));
                return false;
            }

            return true;
        }
    }
}
