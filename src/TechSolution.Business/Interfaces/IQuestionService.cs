using System;
using System.Threading.Tasks;
using TechSolution.Business.Models;

namespace TechSolution.Business.Interfaces
{
    public interface IQuestionService
    {
        Task CreateQuestion(Question question);

        Task UpdateQuestion(Question question);

        Task DeleteQuestion(Guid question);
    }
}
