using System;
using System.Collections.Generic;
using Entities.Gamification;
using Models.Gamification.Read;
using Models.Gamification.Write;

namespace BusinessLogic.Gamification.Abstractions
{
    public interface IAnswerLogic
    {
        Answer Create(Guid sessionsEntityId, AnswerWriteDto answerDto);

        Answer Delete(Guid answerEntityId);

        AnswerReadDto GetById(Guid answerEntityId);

        ICollection<AnswerReadDto> GetAll(Guid sessionEntityId);
    }
}
