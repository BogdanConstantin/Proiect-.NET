using System;
using System.Collections.Generic;
using Entities.Questions;
using Models.Questions;

namespace BusinessLogic.Questions.Abstractions
{
    public interface IAnswerLogic
    {
        Answer Create(AnswerDto answerDto);

        Answer Update(AnswerDto courseDto, Guid answerEntityId);

        Answer Delete(Guid answerEntityId);

        AnswerDto GetById(Guid answerEntityId);

        ICollection<AnswerDto> GetAll();
    }
}
