using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public class WorkdayConfiguration : EntityConfiguration<Workday>
    {
        protected override void ApplyChildConfiguration(EntityTypeBuilder<Workday> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(10);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(w => w.AvailableAppointments)
                .WithOne(a => a.Workday)
                .HasForeignKey(a => a.WorkdayId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
