using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public class DepressionSymptomConfiguration : EntityConfiguration<Domain.DepressionSymptom>
    {
        protected override void ApplyChildConfiguration(EntityTypeBuilder<DepressionSymptom> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired(true);

            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
