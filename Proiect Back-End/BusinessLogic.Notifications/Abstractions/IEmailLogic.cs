using System;
using System.Collections.Generic;

namespace BusinessLogic.Notifications.Abstractions
{
    using Models.Notification;

    public interface IEmailLogic
    {
        void Create(EmailDto emailDto);

        EmailDto GetById(Guid emailId);

        ICollection<EmailDto> GetAll();
    }
}
