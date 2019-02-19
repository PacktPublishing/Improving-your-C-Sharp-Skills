using Microsoft.EntityFrameworkCore;

namespace SpeakerMeet.Models
{
    public class SpeakerMeetContext : DbContext
    {
        public SpeakerMeetContext(DbContextOptions<SpeakerMeetContext> options) : base(options)
        { }

        public virtual DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>().ToTable("Speaker");
        }
    }
}