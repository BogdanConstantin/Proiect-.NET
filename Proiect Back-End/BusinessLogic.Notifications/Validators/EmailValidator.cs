using FluentValidation;
using Models.Notification;

namespace BusinessLogic.Notifications.Validators
{
    public class EmailValidator : AbstractValidator<EmailDto>
    {
        public EmailValidator()
        {
            RuleFor(emailDto => emailDto.Receiver)
                .NotEmpty()
                .NotNull()
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(emailDto => emailDto.Body)
                .NotEmpty()
                .NotNull()
                .Length(1, 500);

            RuleFor(emailDto => emailDto.Subject)
                .NotEmpty()
                .NotNull()
                .Length(1, 35);
        }
    }
}
