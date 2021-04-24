using System;

namespace TechSolution.API.ViewModels
{
    public class QuestionCommentViewModel
    {
        public Guid Id { get; set; }

        public string QuestionCommentsText { get; set; }

        public int QuestionCommentsUpvotes { get; set; }

        public int QuestionCommentsDownvotes { get; set; }

        public Guid QuestionId { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
