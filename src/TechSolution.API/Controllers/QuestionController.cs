using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolution.API.ViewModels;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;

namespace TechSolution.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/questions")]
    [Authorize]
    public class QuestionController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionService _questionService;
        
        public QuestionController(IMapper mapper,
                                  IQuestionRepository questionRepository,
                                  IQuestionService questionService,
                                  INotificator notificator) : base(notificator)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _questionService = questionService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<QuestionViewModel>> Get()
        {
            var questions = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(await _questionRepository.GetAll());

            return questions;
        }

        [HttpGet("question/{id:guid}")]
        public async Task<QuestionViewModel> Get(Guid id)
        {
            return _mapper.Map<Question, QuestionViewModel>(await _questionRepository.GetById(id));
        }

        [Route("new")]
        [HttpPost]
        public async Task<ActionResult<QuestionViewModel>> Post(QuestionViewModel questionViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var question = _mapper.Map<QuestionViewModel, Question>(questionViewModel);

            await _questionService.CreateQuestion(question);

            return CustomResponse(questionViewModel);
        }

        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult<QuestionViewModel>> Put(Guid id, QuestionViewModel questionViewModel)
        {
            if (id != questionViewModel.Id)
            {
                Notify("Question id does not match");
                return CustomResponse(questionViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _questionService.UpdateQuestion(_mapper.Map<QuestionViewModel, Question>(questionViewModel));

            return CustomResponse(questionViewModel);
        }

        [HttpDelete("remove/{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var questionViewModel = await _questionRepository.GetById(id);

            if (questionViewModel == null) return NotFound();

            await _questionService.DeleteQuestion(id);

            return CustomResponse();
        }
    }
}
