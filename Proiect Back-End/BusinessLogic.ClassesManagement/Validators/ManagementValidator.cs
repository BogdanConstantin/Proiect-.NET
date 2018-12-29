using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ClassesManagement.Validators
{
    using System.Text.RegularExpressions;

    using DataAccess.ClassesManagement.Abstractions;

    using Entities.ClassesManagement;

    using FluentValidation;
    using FluentValidation.Results;

    using Models.ClassesManagement;

    public class ManagementValidator : AbstractValidator<ManagementDto>
    {
        private IRepository _repository;

        public ManagementValidator(IRepository repository)
        {
            _repository = repository;

            RuleFor(managementDto => managementDto.ClassId)
                .NotEmpty()
                .NotNull()
                .Must(BaseValidator.IsGuid);

            RuleFor(managementDto => managementDto.UserId)
                .NotEmpty()
                .NotNull()
                .Must(BaseValidator.IsGuid);

            RuleFor(managementDto => managementDto.UserPosition)
                .NotEmpty()
                .NotNull()
                .Must(BaseValidator.UserPositionIsValid).WithMessage("That is not a valid user position");
        }


        protected override bool PreValidate(ValidationContext<ManagementDto> validationContext, ValidationResult result)
        {
            if (!BaseValidator.CheckCourse(_repository, validationContext, result))
            {
                return false;
            }

            return base.PreValidate(validationContext, result);
        }
    }
}
