using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Category
    {
        public Category()
        {
            this.Candidates = new List<Candidate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
