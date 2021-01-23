using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain;

namespace VendingMachine.SqlPersistence
{
    public class MachineEntityTypeConfiguration : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Identifier).IsRequired().HasMaxLength(50);
        }
    }
}