using System;
using System.Collections.Generic;
using BusinessLogic.ClassesManagement.Implementations;
using BusinessLogic.Questions.Abstractions;
using DataAccess.Questions.Abstractions;
using Entities.Questions;
using Models.Questions;

namespace BusinessLogic.Questions.Implementations
{
    public class AnswerLogic : BaseLogic, IAnswerLogic
    {
        public AnswerLogic(IRepository repository)
            : base(repository)
        {
        }

        public Answer Create(AnswerDto answerDto)
        {
            var newAnswer = new Answer()
            {
                AuthorId = Guid.NewGuid(),
                AnswerString = answerDto.AnswerString,
                EntityId = Guid.NewGuid(),
                QuestionId = answerDto.QuestionId,
            };

            _repository.Insert(newAnswer);
            _repository.Save();

            return newAnswer;
        }

        public Answer Delete(Guid answerEntityId)
        {
            var answer = _repository.GetLastByFilter<Answer>(c => c.EntityId == answerEntityId);

            answer.Id = Guid.NewGuid();
            answer.AuthorId = Guid.NewGuid();
            answer.DeletedDate = DateTime.Now;

            _repository.Insert(answer);
            _repository.Save();

            return answer;
        }

        public ICollection<AnswerDto> GetAll()
        {
            List<AnswerDto> answerDtos = new List<AnswerDto>();

            var answers = _repository.GetAll<Answer>();

            foreach (var answer in answers)
            {
                var answerDto = new AnswerDto()
                {

                    AnswerString = answer.AnswerString,
                    QuestionId = answer.QuestionId,
                };
                answerDtos.Add(answerDto);
            }

            return answerDtos;
        }

        public AnswerDto GetById(Guid answerEntityId)
        {
            var answer = _repository.GetLastByFilter<Answer>(c => c.EntityId == answerEntityId);

            var newAnswerDto = new AnswerDto()
            {

                AnswerString = answer.AnswerString,
                QuestionId = answer.QuestionId,
            };

            return newAnswerDto;
        }

        public Answer Update(AnswerDto courseDto, Guid answerEntityId)
        {
            var answer = _repository.GetLastByFilter<Answer>(c => c.EntityId == answerEntityId);

            if (answer.DeletedDate != null)
            {
                return null;
            }

            answer.Id = Guid.NewGuid();
            answer.AuthorId = Guid.NewGuid();
            answer.AnswerString = courseDto.AnswerString;
            answer.QuestionId = courseDto.QuestionId;

            _repository.Insert(answer);
            _repository.Save();

            return answer;
        }
    }
}
