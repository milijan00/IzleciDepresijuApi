using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore;
namespace IzleciDepresiju.Implementation.DataAccess.Configurations
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false);

            this.ApplyChildConfiguration(builder);
        }

        protected abstract void ApplyChildConfiguration(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder); 
    }
}
