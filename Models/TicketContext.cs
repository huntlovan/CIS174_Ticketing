using Microsoft.EntityFrameworkCore;

namespace CIS174_Ticketing.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Sprint> Sprints { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprint>().HasData(
                new Sprint { SprintId = "1", Name = "Sprint 1" },
                new Sprint { SprintId = "2", Name = "Sprint 2" },
                new Sprint { SprintId = "3", Name = "Sprint 3" },
                new Sprint { SprintId = "4", Name = "Sprint 4" },
                new Sprint { SprintId = "5", Name = "Sprint 5" }
            );
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status {StatusId = "inprogress", Name = "In Progress"},
                new Status { StatusId = "done", Name = "Done" }
            );
        }
    }
}
