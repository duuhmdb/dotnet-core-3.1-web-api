using System;

namespace TechSolution.Business.Models
{
    public class AnswerComment : Entity
    {
        public string AnswerCommentText { get; set; }

        public int AnswerCommentUpvotes { get; set; }

        public int AnswerCommentDownvotes { get; set; }

        public Guid AnswerId { get; set; }

        public Answer Answer { get; set; }
    }
}
