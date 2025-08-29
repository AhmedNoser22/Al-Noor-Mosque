namespace Al_Noor.Infrastructure.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Young> youngs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Worker> workers { get; set; }


    }
}
