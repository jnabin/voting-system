using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICandidateRepository Candidates { get; }
        IVoterRepository Voters { get; }
        IVoteRepository Votes { get; }
        int Complete();
    }
}
