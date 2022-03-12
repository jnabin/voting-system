using Core.Domain;

namespace voting_system.Dto
{
    public class CreateVote
    {
        public int VoterID { get; set; }
        public int CategoryId { get; set; }
        public int CandidateId { get; set; }

        public static implicit operator Vote(CreateVote vote)
        {
            return new Vote
            {
                VoterID = vote.VoterID,
                CandidateId = vote.CandidateId,
                CategoryId = vote.CategoryId
            };
        }
    }
}
