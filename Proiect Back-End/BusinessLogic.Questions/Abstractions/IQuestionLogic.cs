using System;
using System.Collections.Generic;
using Entities.Questions;
using Models.Questions;

namespace BusinessLogic.Questions.Abstractions
{
    public interface IQuestionLogic
    {
        Question Create(QuestionDto questionDto);

        Question Update(QuestionDto questionDto, Guid questionEntityId);

        Question Delete(Guid questionEntityId);

        QuestionDto GetById(Guid questionEntityId);

        ICollection<QuestionDto> GetAll();
    }
}
