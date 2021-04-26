using System;
using System.ComponentModel.DataAnnotations;

namespace TechSolution.API.ViewModels
{
    public class AnswerCommentViewModel
    {
        public Guid Id { get; set; }

        [Required, Display(Name = "Body")]
        public string AnswerCommentText { get; set; }

        [Required, Display(Name = "Upvotes")]
        public int AnswerCommentUpvotes { get; set; }

        [Required, Display(Name = "Downvotes")]
        public int AnswerCommentDownvotes { get; set; }

        [Required]
        public Guid AnswerId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public AnswerViewModel Answer { get; set; }
    }
}
