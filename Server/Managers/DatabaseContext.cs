using IFK.Server.DataTypes;
using IFK.Server.DataTypes.Issues;
using System.Data.Entity;

namespace IFK.Server.Managers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Issue> Issues { get; set; }
        //public DbSet<Notification> Notifications { get; set; }

        public DatabaseContext() : base("name=IfkDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Squad>()
                    .HasMany(squad => squad.Composition)
                    .WithOptional(user => user.Squad)
                    .HasForeignKey(user => user.SquadID);

            builder.Entity<Squad>()
                    .HasMany(squad => squad.Issues)
                    .WithRequired(issue => issue.Squad)
                    .HasForeignKey(issue => issue.SquadID);

            //builder.Entity<Issue>()
            //        .HasRequired(issue => issue.User);

            base.OnModelCreating(builder);
        }

        public void DropData()
        {
            Squads.RemoveRange(Squads);
            Issues.RemoveRange(Issues);
            Users.RemoveRange(Users);
            Sprints.RemoveRange(Sprints);
            //this.Notifications.RemoveRange(this.Notifications);
        }
    }

    public class ContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext> { }
}
