using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public class NavigationLinkConfiguration : EntityConfiguration<NavigationLink>
    {
        protected override void ApplyChildConfiguration(EntityTypeBuilder<NavigationLink> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.Route).IsRequired(true).HasMaxLength(30);

            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
