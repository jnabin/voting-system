using Core;
using Core.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VoteDbContext _context;

        public UnitOfWork(VoteDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Candidates = new CandidateRepository(_context);
            Voters = new VoterRepository(_context);
            Votes = new VoteRepository(_context);
        }

        public ICategoryRepository Categories { get; set; }

        public ICandidateRepository Candidates { get; set; }

        public IVoterRepository Voters { get; set; }

        public IVoteRepository Votes { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
