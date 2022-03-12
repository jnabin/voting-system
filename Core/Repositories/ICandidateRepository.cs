using Core.Domain;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Task<int?> VoteCount(int id);
    }
}
