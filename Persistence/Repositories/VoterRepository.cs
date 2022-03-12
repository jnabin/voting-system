using Core.Domain;
using Core.Repositories;

namespace Persistence.Repositories
{
    public class VoterRepository : Repository<Voter>, IVoterRepository
    {
        public VoterRepository(VoteDbContext context) : base(context)
        {
        }
    }
}
