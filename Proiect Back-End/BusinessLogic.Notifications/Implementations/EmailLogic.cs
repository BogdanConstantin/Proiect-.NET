using System;
using System.Collections.Generic;

namespace BusinessLogic.Notifications.Implementations
{
    using BusinessLogic.Notifications.Abstractions;

    using DataAccess.Notifications.Abstractions;

    using Entities.Notifications;

    using Models.Notification;

    public class EmailLogic : BaseLogic, IEmailLogic
    {
        public EmailLogic(IRepository repository)
            : base(repository)
        {
        }

        public void Create(EmailDto emailDto)
        {
            var newEmail = new Email
                               {
                                   AuthorId = Guid.NewGuid(),
                                   Body = emailDto.Body,
                                   Receiver = emailDto.Receiver,
                                   Subject = emailDto.Subject
                               };

            _repository.Insert(newEmail);
            _repository.Save();
        }

        public EmailDto GetById(Guid emailId)
        {
            var email = _repository.GetLastByFilter<Email>(e => e.Id == emailId);

            var emailDto = new EmailDto
                               {
                                   Body = email.Body,
                                   Receiver = email.Receiver,
                                   Subject = email.Subject
                               };

            return emailDto;
        }

        public ICollection<EmailDto> GetAll()
        {
            List<EmailDto> emailDtos = new List<EmailDto>();

            var emails = _repository.GetAll<Email>();

            foreach (var email in emails)
            {
                var emailDto = new EmailDto
                                   {
                                       Body = email.Body,
                                       Receiver = email.Receiver,
                                       Subject = email.Subject
                                   };

                emailDtos.Add(emailDto);
            }

            return emailDtos;
        }
    }
}
