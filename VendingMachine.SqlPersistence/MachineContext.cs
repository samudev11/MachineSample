using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain;

namespace VendingMachine.SqlPersistence
{
    public class MachineContext : DbContext
    {
        public MachineContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MachineEntityTypeConfiguration).Assembly);
        }
    }
}