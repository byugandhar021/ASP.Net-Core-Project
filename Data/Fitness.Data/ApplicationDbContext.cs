namespace Fitness.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Fitness.Data.Common.Models;
    using Fitness.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Diet> Diets { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Nutrition> Nutritions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Diet>(e =>
            {
                e.HasOne(d => d.User)
                .WithMany(u => u.Diets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Nutrition>(e =>
            {
                e.HasOne(n => n.User)
                .WithMany(u => u.Nutritions)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Gym>(e =>
            {
                e.HasOne(g => g.User)
                .WithMany(u => u.Gyms)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Exercise>(e =>
            {
                e.HasOne(x => x.User)
                .WithMany(u => u.Exercises)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Comment>(e =>
            {
                e.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Comment>(e =>
            {
                e.HasOne(c => c.Diet)
                .WithMany(d => d.Comments)
                .HasForeignKey(c => c.DietId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Comment>(e =>
            {
                e.HasOne(c => c.Exercise)
                .WithMany(x => x.Comments)
                .HasForeignKey(c => c.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Comment>(e =>
            {
                e.HasOne(c => c.Nutrition)
                .WithMany(n => n.Comments)
                .HasForeignKey(c => c.NutritionId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Comment>(e =>
            {
                e.HasOne(c => c.Gym)
                .WithMany(g => g.Comments)
                .HasForeignKey(c => c.GymId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
