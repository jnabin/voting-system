using Core.Domain;

namespace Core.Repositories
{
    public interface IVoteRepository : IRepository<Vote>
    {
        Vote VoteByUserAndCategory(int voterId, int categoryId);
    }
}
