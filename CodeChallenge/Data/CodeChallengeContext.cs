using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Data.Model;

namespace CodeChallenge.Data
{
    public class CodeChallengeContext : DbContext
    {
        public CodeChallengeContext (DbContextOptions<CodeChallengeContext> options)
            : base(options)
        {
        }

        public DbSet<CodeChallenge.Data.Model.Animal> Animal { get; set; }
    }
}
