using BusinessLogic.Gamification.Abstractions;
using Entities.Gamification;
using Models.Gamification;
using System;
using System.Collections.Generic;
using DataAccess.Gamification.Abstractions;
using Models.Gamification.Read;

namespace BusinessLogic.Gamification.Implementations
{
    public class SessionLogic :BaseLogic,  ISessionLogic
    {
        public SessionLogic(IRepository repository)
            : base(repository)
        {
            
        }

        public Session Create(SessionWriteDto sessionDto)
        {
            var entityId = Guid.NewGuid();

            var newSession = new Session
            {
                Id = entityId,
                AuthorId = Guid.NewGuid(),
                SecurityCode = entityId.ToString().Substring(0, 4).ToUpper(),
                Question = sessionDto.Question,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddSeconds(sessionDto.AllocatedTime)
            };

            _repository.Insert(newSession);
            _repository.Save();
            return newSession;
        }

        public ICollection<SessionReadDto> GetAll()
        {
            List<SessionReadDto> sessionsDtos = new List<SessionReadDto>();

            var sessions = _repository.GetAll<Session>();

            foreach (var session in sessions)
            {
                var sessionDto = new SessionReadDto()
                {

                    Question = session.Question,
                    SecurityCode =  session.SecurityCode

                };
                sessionsDtos.Add(sessionDto);
            }

            return sessionsDtos;
        }

        public SessionReadDto GetById(Guid sessionEntityId)
        {
            var session = _repository.GetLastByFilter<Session>(c => c.Id == sessionEntityId);

            var newSessionDto = new SessionReadDto()
            {
                Question = session.Question,
                SecurityCode = session.SecurityCode
            };

            return newSessionDto;
        }

        public Session Delete(Guid sessionEntityId)
        {
            var session = _repository.GetLastByFilter<Session>(c => c.Id == sessionEntityId);
            
            _repository.Delete(session);
            _repository.Save();

            return session;
        }
    }
}
