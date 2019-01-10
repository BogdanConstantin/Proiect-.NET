using System;
using System.Collections.Generic;
using Entities.Notifications;

namespace BusinessLogic.Notifications.Abstractions
{
    using Models.Notification;

    public interface IEmailLogic
    {
        Email Create(EmailDto emailDto);

        EmailDto GetById(Guid emailId);

        ICollection<EmailDto> GetAll();
    }
}
