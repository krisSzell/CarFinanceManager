using System.Data.Entity;
using CarFinanceManager.Persistence.Models.Logging;

namespace CarFinanceManager.Persistence
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext()
            : base("DefaultConnection")
        {
        }

        public static LoggingDbContext Create()
        {
            return new LoggingDbContext();
        }

        public DbSet<FullLog> FullLogs { get; set; }
    }
}
