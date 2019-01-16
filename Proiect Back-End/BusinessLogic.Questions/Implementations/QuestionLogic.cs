using System;
using System.Collections.Generic;
using BusinessLogic.ClassesManagement.Implementations;
using BusinessLogic.Questions.Abstractions;
using DataAccess.Questions.Abstractions;
using Entities.Questions;
using Models.Questions;

namespace BusinessLogic.Questions.Implementations
{
    public class QuestionLogic : BaseLogic, IQuestionLogic
    {
        public QuestionLogic(IRepository repository)
            : base(repository)
        {
        }
        public Question Create(QuestionDto questionDto)
        {
            var newQuestion = new Question()
            {
                AuthorId = Guid.NewGuid(),
                QuestionString = questionDto.QuestionString,
                EntityId = Guid.NewGuid(),
            };

            _repository.Insert(newQuestion);
            _repository.Save();

            return newQuestion;
        }

        public Question Delete(Guid questionEntityId)
        {
            var question = _repository.GetLastByFilter<Question>(c => c.EntityId == questionEntityId);

            question.Id = Guid.NewGuid();
            question.AuthorId = Guid.NewGuid();
            question.DeletedDate = DateTime.Now;

            _repository.Insert(question);
            _repository.Save();

            return question;
        }

        public ICollection<QuestionDto> GetAll()
        {
            List<QuestionDto> questionDtos = new List<QuestionDto>();

            var questions = _repository.GetAll<Question>();

            foreach (var question in questions)
            {
                var questionDto = new QuestionDto()
                {

                    QuestionString = question.QuestionString

                };
                questionDtos.Add(questionDto);
            }

            return questionDtos;
        }

        public QuestionDto GetById(Guid questionEntityId)
        {
            var question = _repository.GetLastByFilter<Question>(c => c.EntityId == questionEntityId);

            var newQuestionDto = new QuestionDto()
            {
                QuestionString = question.QuestionString
            };

            return newQuestionDto;
        }

        public Question Update(QuestionDto questionDto, Guid questionEntityId)
        {
            var question = _repository.GetLastByFilter<Question>(c => c.EntityId == questionEntityId);

            if (question.DeletedDate != null)
            {
                return null;
            }

            question.Id = Guid.NewGuid();
            question.AuthorId = Guid.NewGuid();
            question.QuestionString = questionDto.QuestionString;

            _repository.Insert(question);
            _repository.Save();

            return question;
        }
    }
}
