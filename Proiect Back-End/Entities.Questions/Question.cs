using System.Collections.Generic;

namespace Entities.Questions
{
    public class Question : BaseEntity
    {
        public string QuestionString { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
