using Entities.Gamification;
using Models.Gamification;
using System;
using System.Collections.Generic;
using Models.Gamification.Read;

namespace BusinessLogic.Gamification.Abstractions
{
    public interface ISessionLogic
    {
        Session Create(SessionWriteDto sessionDto);
       
        Session Delete(Guid sessionEntityId);

        SessionReadDto GetById(Guid sessionEntityId);

        ICollection<SessionReadDto> GetAll();
    }
}
