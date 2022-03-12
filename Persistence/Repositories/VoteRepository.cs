using Core.Domain;
using Core.Repositories;
using System.Linq;

namespace Persistence.Repositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(VoteDbContext context) : base(context)
        {
        }

        public VoteDbContext PlutoContext
        {
            get { return Context as VoteDbContext; }
        }

        public Vote VoteByUserAndCategory(int voterId, int categoryId)
        {
            return PlutoContext.Votes
                .Where(x => x.CategoryId == categoryId && x.VoterID == voterId)
                .FirstOrDefault();
        }
    }
}
