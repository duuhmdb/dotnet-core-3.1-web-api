using System.Collections.Generic;

namespace TechSolution.Business.Models
{
    public class Question : Entity
    {
        public string QuestionTitle { get; set; }

        public string QuestionText { get; set; }

        public string QuestionTags { get; set; }

        public double QuestionViewed { get; set; }

        public IEnumerable<Answer> Answers { get; set; }

        public IEnumerable<QuestionComment> QuestionsComments { get; set; }
    }
}
