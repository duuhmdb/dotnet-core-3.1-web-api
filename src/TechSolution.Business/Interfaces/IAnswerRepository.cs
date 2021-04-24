using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechSolution.Business.Models;

namespace TechSolution.Business.Interfaces
{
    public interface IAnswerRepository : IRepositoryBase<Answer>
    {
        Task<Answer> GetAnswerQuestion(Guid id);

        Task<IEnumerable<Answer>> GetAnswersQuestions();

        Task<Answer> GetAnswerComments(Guid id);

        Task<IEnumerable<Answer>> GetAnswersComments();
    }
}
