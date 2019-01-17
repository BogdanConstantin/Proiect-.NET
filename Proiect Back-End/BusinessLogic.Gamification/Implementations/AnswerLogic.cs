using BusinessLogic.Gamification.Abstractions;
using DataAccess.Gamification.Abstractions;
using Entities.Gamification;
using Models.Gamification.Read;
using Models.Gamification.Write;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Gamification.Implementations
{
    public class AnswerLogic : BaseLogic, IAnswerLogic
    {
        public AnswerLogic(IRepository repository)
            : base(repository)
        {

        }

        public Answer Create(Guid sessionEntityId, AnswerWriteDto answerDto)
        {
            var session = _repository.GetLastByFilter<Session>(c => c.Id == sessionEntityId);

            Answer newAnswer = null;

            if (session != null)
            {
                if (session.SecurityCode == answerDto.SecurityCode && session.EndDate >= DateTime.Now)
                {
                    newAnswer = new Answer
                    {
                        Id = Guid.NewGuid(),
                        AuthorId = Guid.NewGuid(),
                        Input = answerDto.Answer,
                        SessionId = sessionEntityId
                    };

                    _repository.Insert(newAnswer);
                    _repository.Save();
                }
            }

            return newAnswer;
        }

        public Answer Delete(Guid answerEntityId)
        {
            var answer = _repository.GetLastByFilter<Answer>(c => c.Id == answerEntityId);

            _repository.Delete(answer);
            _repository.Save();

            return answer;
        }

        public AnswerReadDto GetById(Guid answerEntityId)
        {
            var answer = _repository.GetLastByFilter<Answer>(c => c.Id == answerEntityId);

            var newAnswerDto = new AnswerReadDto()
            {
                Answer = answer.Input
            };

            return newAnswerDto;
        }

        public ICollection<AnswerReadDto> GetAll(Guid sessionEntityId)
        {
            List<AnswerReadDto> answersDtos = new List<AnswerReadDto>();

            var answers = _repository.GetAll<Answer>();

            foreach (var answer in answers)
            {
                var answerDto = new AnswerReadDto()
                {
                    Answer = answer.Input
                };

                if (answer.SessionId == sessionEntityId)
                {
                    answersDtos.Add(answerDto);
                }
            }

            return answersDtos;
        }
    }
}
