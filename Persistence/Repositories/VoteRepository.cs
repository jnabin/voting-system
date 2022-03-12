using Core.Domain;
using Core.Repositories;

namespace Persistence.Repositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        public VoteRepository(VoteDbContext context) : base(context)
        {
        }
    }
}
