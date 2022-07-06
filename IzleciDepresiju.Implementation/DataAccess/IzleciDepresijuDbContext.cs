using IzleciDepresiju.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzleciDepresiju.Implementation.DataAccess
{
    public class IzleciDepresijuDbContext : DbContext
    {
       public DbSet<NavigationLink> NavigationLinks { get; set; }
       public DbSet<Role> Roles { get; set; }
       public DbSet<Time> Times { get; set; }
       public DbSet<Workday> Workdays { get; set; }
       public DbSet<DepressionSymptom> DepressionSymptoms { get; set; }
       public DbSet<AvailableAppointment> AvailableAppointments { get; set; }
       public DbSet<MadeAppointment> MadeAppointments { get; set; }
       public DbSet<RoleUseCase> RolesUseCases { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<UseCase> UseCases { get; set; }
        private IApplicationUser User { get; set; }
        public IzleciDepresijuDbContext(IApplicationUser user)
        {
            User = user;
        }
        //public IzleciDepresijuDbContext()
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MadeAppointment>().Property(x => x.BookedAt).IsRequired(true).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<MadeAppointment>().HasKey(x => new { x.UserId, x.AvailableAppointmentId, x.BookedAt });
            modelBuilder.Entity<RoleUseCase>().HasKey(x => new { x.RoleId, x.UseCaseId});
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-39RJT5L\SQLEXPRESS;Initial Catalog=IzleciDepresiju;Integrated Security=True");
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is Entity e)
                {
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = User.Identity;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
