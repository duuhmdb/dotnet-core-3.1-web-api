using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechSolution.API.ViewModels
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "The length of {0} must be in {2} - {1}")]
        [Display(Name = "Body")]
        public string AnswerText { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Accepted answer")]
        public bool AcceptedAnswer { get; set; }

        public int AnswerUpvotes { get; set; }

        public int AnswerDownvotes { get; set; }

        [Required]
        public Guid QuestionId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public QuestionViewModel Question { get; set; }

        public IEnumerable<AnswerCommentViewModel> AnswerComments { get; set; }
    }
}
