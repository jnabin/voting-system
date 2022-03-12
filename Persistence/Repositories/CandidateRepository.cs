using Core.Domain;
using Core.Repositories;

namespace Persistence.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(VoteDbContext context) : base(context)
        {
        }
    }
}
