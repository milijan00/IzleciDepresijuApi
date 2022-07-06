using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public class UseCaseConfiguration : EntityConfiguration<UseCase>
    {
        protected override void ApplyChildConfiguration(EntityTypeBuilder<UseCase> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(u => u.Roles)
                .WithOne(x => x.UseCase)
                .HasForeignKey(x => x.UseCaseId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
