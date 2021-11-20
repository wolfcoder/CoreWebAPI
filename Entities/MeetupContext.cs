using Microsoft.EntityFrameworkCore;

namespace CoreWebAPI.Entities
{
    public class MeetupContext : DbContext
    {
        public MeetupContext(DbContextOptions<MeetupContext> options) : base(options)
        {             }

        public DbSet<Meetup> Meetups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MeetupDb;User=sa;Password=@BBgg1234#;");
        }
    }
}
