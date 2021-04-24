using System;

namespace TechSolution.API.ViewModels
{
    public class AnswerCommentViewModel
    {
        public Guid Id { get; set; }

        public string AnswerCommentText { get; set; }

        public int AnswerCommentUpvotes { get; set; }

        public int AnswerCommentDownvotes { get; set; }

        public Guid AnswerId { get; set; }

        public AnswerViewModel Answer { get; set; }
    }
}
