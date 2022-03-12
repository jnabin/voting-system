using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Voter
    {
        public Voter()
        {
            this.Votes = new List<Vote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public bool CanVote()
        {
            return this.Age > 18;
        }
    }
}
