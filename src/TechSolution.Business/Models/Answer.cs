using System;
using System.Collections.Generic;

namespace TechSolution.Business.Models
{
    public class Answer : Entity
    {
        public string AnswerText { get; set; }

        public bool AcceptedAnswer { get; set; }

        public int AnswerUpvotes { get; set; }

        public int AnswerDownvotes { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        public IEnumerable<AnswerComment> AnswerComments { get; set; }
    }
}
