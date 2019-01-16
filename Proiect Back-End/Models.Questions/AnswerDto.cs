using System;

namespace Models.Questions
{
    public class AnswerDto
    {
        public string AnswerString { get; set; }

        public Guid QuestionId { get; set; }
    }
}
