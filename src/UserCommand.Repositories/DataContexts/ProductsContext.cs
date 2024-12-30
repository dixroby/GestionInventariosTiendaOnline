namespace UserCommand.Repositories.DataContexts;

internal class ProductsContext : DbContext
{
    readonly IOptions<DBOptions> Options;
    public ProductsContext(IOptions<DBOptions> options)
    {
        Options = options;
        ChangeTracker.QueryTrackingBehavior =
            QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Options.Value.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ProductsConfiguration).Assembly);
    }

    public DbSet<User> User { get; set; }
}