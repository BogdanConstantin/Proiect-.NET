using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ClassesManagement.Validators
{
    using FluentValidation;
    using FluentValidation.Results;

    using Models.ClassesManagement;

    public class CourseValidator : AbstractValidator<CourseDto>
    {
        public CourseValidator()
        {
            RuleFor(courseDto => courseDto.CourseTitle)
                .NotEmpty()
                .NotNull()
                .Length(1, 35);

            RuleFor(courseDto => courseDto.Semester)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(1, 2);

            RuleFor(courseDto => courseDto.Year)
                .NotEmpty()
                .NotNull()
                .InclusiveBetween(1, 3);
        }
    }
}
