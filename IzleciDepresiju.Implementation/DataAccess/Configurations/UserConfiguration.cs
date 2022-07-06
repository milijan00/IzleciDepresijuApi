using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ApplyChildConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Username).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Image).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(100);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();


            builder.HasMany(u => u.MadeAppointments)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.AvailableAppointments)
                .WithOne(a => a.Therapist)
                .HasForeignKey(a => a.TherapistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
