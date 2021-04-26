using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechSolution.API.ViewModels
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "The length of {0} must be in {2} - {1}")]
        [Display(Name = "Question title")]
        public string QuestionTitle { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(1500, MinimumLength = 20, ErrorMessage = "The length of {0} must be in {2} - {1}")]
        [Display(Name = "Body")]
        public string QuestionText { get; set; }

        [Display(Name = "Tags")]
        public string QuestionTags { get; set; }

        public double QuestionViewed { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public IEnumerable<AnswerViewModel> Answers { get; set; }

        public IEnumerable<QuestionCommentViewModel> QuestionsComments { get; set; }
    }
}
