using Core.Domain;

namespace voting_system.Dto
{
    public class CreateVoter
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static implicit operator Voter(CreateVoter voter)
        {
            return new Voter
            {
                Name = voter.Name,
                Age = voter.Age
            };
        }
    }
}
