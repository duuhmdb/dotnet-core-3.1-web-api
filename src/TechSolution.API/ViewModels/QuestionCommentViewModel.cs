using System;
using System.ComponentModel.DataAnnotations;

namespace TechSolution.API.ViewModels
{
    public class QuestionCommentViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Body")]
        public string QuestionCommentsText { get; set; }

        [Display(Name = "Upvotes")]
        public int QuestionCommentsUpvotes { get; set; }

        [Display(Name = "Downvotes")]
        public int QuestionCommentsDownvotes { get; set; }

        [Required]
        public Guid QuestionId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
