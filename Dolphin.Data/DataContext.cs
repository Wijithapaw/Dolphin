using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Dolphin.Domain.Entities;
using Dolphin.Domain;
using Dolphin.Domain.Common;
using System;
using System.Linq;

namespace Dolphin.Data
{

    public class DataContext : IdentityDbContext<User>, IDataContext
    {
        public IEnvironmentDescriptor EnvironmentDescriptor { get; private set; }

        public IDbSet<Donor> Donors { get; set; }

        public DataContext()
           : base("DataContext", throwIfV1Schema: false)
        {

        }

        public DataContext(IEnvironmentDescriptor identityDescriptor)
            : base("DataContext", throwIfV1Schema: false)
        {
            EnvironmentDescriptor = identityDescriptor;
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        public override int SaveChanges()
        {
            if (EnvironmentDescriptor != null)
            {
                foreach (var entry in this.ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Added))
                {
                    entry.Entity.CreatedBy = entry.Entity.LastUpdatedBy = EnvironmentDescriptor.UserID;
                    entry.Entity.CreatedDateUtc = entry.Entity.LastUpdatedDateUtc = DateTime.UtcNow;
                }

                foreach (var entry in this.ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Modified))
                {
                    entry.Entity.LastUpdatedBy = EnvironmentDescriptor.UserID;
                    entry.Entity.LastUpdatedDateUtc = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }

        public static void Initialize()
        {
            Database.SetInitializer<DataContext>(
                new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());

            using (var context = new DataContext())
                context.Database.Initialize(false);
        }
    }
}