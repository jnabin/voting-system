using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class VoteDbContext : DbContext
    {
        public VoteDbContext(DbContextOptions<VoteDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Voter> Voters { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new CategoryConfiguration().Configure(builder.Entity<Category>());
            new CandidateConfiguration().Configure(builder.Entity<Candidate>());
            new VoteConfiguration().Configure(builder.Entity<Vote>());
            new VoterConfiguration().Configure(builder.Entity<Voter>());
        }
    }
}
