using Core.Domain;
using Core.Repositories;
using System.Linq;

namespace Persistence.Repositories
{
    public class VoterRepository : Repository<Voter>, IVoterRepository
    {
        public VoterRepository(VoteDbContext context) : base(context)
        {
        }
    }
}
