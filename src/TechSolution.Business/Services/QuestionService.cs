using System;
using System.Linq;
using System.Threading.Tasks;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;

namespace TechSolution.Business.Services
{
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository,
                               INotificator notificator) : base(notificator)
        {
            _questionRepository = questionRepository;
        }

        public async Task CreateQuestion(Question question)
        {
            var existsQuestion = await _questionRepository
                .GetByExpression(x => x.QuestionTitle == question.QuestionTitle ||
                x.QuestionText == question.QuestionText);

            if (existsQuestion.Any())
            {
                Notify("There is already an question similar to this");
                return;
            }

            await _questionRepository.Insert(question);
        }

        public async Task DeleteQuestion(Guid id)
        {
            var exists = await _questionRepository.GetById(id);

            if (exists == null)
            {
                Notify("There is no such question.");
                return;
            }

            await _questionRepository.Delete(id);
        }

        public async Task UpdateQuestion(Question question)
        {
            var questionUpdate = await _questionRepository.GetById(question.Id);

            questionUpdate.QuestionTags = question.QuestionTags;
            questionUpdate.QuestionText = question.QuestionText;
            questionUpdate.QuestionTitle = question.QuestionTitle;

            await _questionRepository.Update(questionUpdate);
        }
    }
}
