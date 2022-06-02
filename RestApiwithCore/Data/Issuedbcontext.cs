using Microsoft.EntityFrameworkCore;
using RestApiwithCore.Models;

namespace RestApiwithCore.Data
{
    public class Issuedbcontext:DbContext
    {
        public Issuedbcontext(DbContextOptions<Issuedbcontext> options):base(options)
        {

        }
        public DbSet<Issue> issues { get; set; }
    }
}
