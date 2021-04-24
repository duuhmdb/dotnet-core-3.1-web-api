using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;
using TechSolution.Data.Context;

namespace TechSolution.Data.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(TechSolutionDbContext context) : base(context)
        {
        }

        public async Task<Answer> GetAnswerComments(Guid id)
        {
            return await _context.Answers.AsNoTracking()
                .Include(p => p.AnswerComments)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Answer> GetAnswerQuestion(Guid id)
        {
            return await _context.Answers.AsNoTracking()
                .Include(p => p.Question)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Answer>> GetAnswersComments()
        {
            return await _context.Answers.AsNoTracking()
                .Include(p => p.AnswerComments)
                .ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetAnswersQuestions()
        {
            return await _context.Answers.AsNoTracking()
             .Include(p => p.Question)
             .ToListAsync();
        }
    }
}
