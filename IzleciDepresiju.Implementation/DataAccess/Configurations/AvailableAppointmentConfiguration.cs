using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public class AvailableAppointmentConfiguration : EntityConfiguration<AvailableAppointment>
    {
        protected override void ApplyChildConfiguration(EntityTypeBuilder<AvailableAppointment> builder)
        {
            builder.Property(x => x.TherapistId).IsRequired(true);
            builder.Property(x => x.TimeFromId).IsRequired(true);
            builder.Property(x => x.TimeToId).IsRequired(true);
            builder.Property(x => x.WorkdayId).IsRequired(true);

            builder.HasMany(a => a.MadeAppointments)
                .WithOne(m => m.AvailableAppointment)
                .HasForeignKey(m => m.AvailableAppointmentId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
