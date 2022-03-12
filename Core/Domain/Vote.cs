using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Vote
    {
        public int Id { get; set; }
        public int VoterID { get; set; }
        public int CategoryId { get; set; }
        public int CandidateId { get; set; }
        public virtual Voter Voter { get; set; }
        public virtual Category Category { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
