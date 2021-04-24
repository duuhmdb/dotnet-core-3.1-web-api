using System;

namespace TechSolution.Business.Models
{
    public class QuestionComment : Entity
    {
        public string QuestionCommentsText { get; set; }

        public int QuestionCommentsUpvotes { get; set; }

        public int QuestionCommentsDownvotes { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
