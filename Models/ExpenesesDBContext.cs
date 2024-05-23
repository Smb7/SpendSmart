using Microsoft.EntityFrameworkCore;

namespace Spendsmart.Models
{
    public class ExpenesesDBContext : DbContext
    {
        // Creating a place for the data to go
        public DbSet<Expense> Expenses { get; set; }

        public ExpenesesDBContext(DbContextOptions<ExpenesesDBContext> options)
            : base(options)
        {

        
        }
    }
}
