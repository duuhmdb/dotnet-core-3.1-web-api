using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolution.Business.Models;

namespace TechSolution.Business.Interfaces
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        Task<Question> GetQuestionAnswer(Guid questionId);

        Task<IEnumerable<Question>> GetQuestionsAnswers();

        Task<Question> GetQuestionsComments(Guid questionId);

        Task<IEnumerable<Question>> GetQuestionsComments();

        Task<Question> GetQuestionAnswerComments(Guid questionId);

        Task<IEnumerable<Question>> GetQuestionsAnswersComments();
    }
}
