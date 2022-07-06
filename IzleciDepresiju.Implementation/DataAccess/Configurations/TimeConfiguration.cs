using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public class TimeConfiguration : EntityConfiguration<Time>
    {
        protected override void ApplyChildConfiguration(EntityTypeBuilder<Time> builder)
        {
            builder.Property(x => x.Value).IsRequired(true).HasMaxLength(10);

            builder.HasIndex(x => x.Value).IsUnique();


            builder.HasMany(t => t.AvailableAppointmentsForEndingTime)
                .WithOne(a => a.TimeFrom)
                .HasForeignKey(a => a.TimeFromId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasMany(t => t.AvailableAppointmentsForStartingTime)
                .WithOne(a => a.TimeTo)
                .HasForeignKey(a => a.TimeToId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
