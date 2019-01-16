using System;

namespace Entities.Questions
{
    public class Answer : BaseEntity
    {
        public string AnswerString { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
