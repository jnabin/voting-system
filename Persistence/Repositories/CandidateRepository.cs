using Core.Domain;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(VoteDbContext context) : base(context)
        {
        }

        public VoteDbContext PlutoContext
        {
            get { return Context as VoteDbContext; }
        }

        public async Task<int?> VoteCount(int id)
        {
            var candidate = await PlutoContext.Candidates.Include(x => x.Votes)
                .FirstOrDefaultAsync(x => x.Id == id);

            return candidate != null? candidate.Votes.Count : null;
        }
    }
}
