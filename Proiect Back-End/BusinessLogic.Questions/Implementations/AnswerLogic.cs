using System;
using System.Collections.Generic;
using BusinessLogic.Questions.Abstractions;
using DataAccess.Questions.Abstractions;
using Entities.Questions;
using Models.Questions;

namespace BusinessLogic.Questions.Implementations
{
    public class AnswerLogic : BaseLogic, IAnswerLogic
    {
        public readonly IQuestionNotification _questionNotification;
        public AnswerLogic(IRepository repository, IQuestionNotification questionNotification)
            : base(repository)
        {
            _questionNotification = questionNotification;
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

            var body = "This is the answer: " + newAnswer.AnswerString;
            var notification = new Notification
            {
                Subject = "A new answer was added",
                Body = body,
                Receiver = "learningsmart211@gmail.com"
            };

            _questionNotification.SendEmail(notification);

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
