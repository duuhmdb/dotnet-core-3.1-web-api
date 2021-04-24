using System;
using System.Collections.Generic;

namespace TechSolution.API.ViewModels
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }

        public string AnswerText { get; set; }

        public bool AcceptedAnswer { get; set; }

        public int AnswerUpvotes { get; set; }

        public int AnswerDownvotes { get; set; }

        public Guid QuestionId { get; set; }

        public QuestionViewModel Question { get; set; }

        public IEnumerable<AnswerCommentViewModel> AnswerComments { get; set; }
    }
}
