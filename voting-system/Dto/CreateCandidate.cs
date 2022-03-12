using Core.Domain;

namespace voting_system.Dto
{
    public class CreateCandidate
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public static implicit operator Candidate(CreateCandidate candidate)
        {
            return new Candidate
            {
                Name = candidate.Name,
                CategoryId = candidate.CategoryId
            };
        }
    }
}
