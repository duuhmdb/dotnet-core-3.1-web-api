using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;
using TechSolution.Data.Context;

namespace TechSolution.Data.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(TechSolutionDbContext ctx) : base(ctx)
        {

        }
        public async Task<Question> GetQuestionAnswer(Guid questionId)
        {
            return await _context.Questions.AsNoTracking()
                .Include(p => p.Answers)
                .FirstOrDefaultAsync(p => p.Id == questionId);
        }

        public async Task<Question> GetQuestionAnswerComments(Guid questionId)
        {
            return await _context.Questions.AsNoTracking()
                       .Include(p => p.QuestionsComments)
                       .Include(p => p.Answers)
                       .ThenInclude(p => p.AnswerComments)
                       .FirstOrDefaultAsync(p => p.Id == questionId);
        }

        public async Task<IEnumerable<Question>> GetQuestionsAnswers()
        {
            return await _context.Questions.AsNoTracking()
                .Include(p => p.Answers)
                .ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionsAnswersComments()
        {
            return await _context.Questions.AsNoTracking()
             .Include(p => p.QuestionsComments)
             .Include(p => p.Answers)
             .ThenInclude(p => p.AnswerComments)
             .ToListAsync();
        }

        public async Task<Question> GetQuestionsComments(Guid questionId)
        {
            return await _context.Questions.AsNoTracking()
                .Include(p => p.QuestionsComments)
                .FirstOrDefaultAsync(p => p.Id == questionId);
        }

        public async Task<IEnumerable<Question>> GetQuestionsComments()
        {
            return await _context.Questions
                .AsNoTracking()
                .Include(x => x.QuestionsComments)
                .ToListAsync();
        }
    }
}
