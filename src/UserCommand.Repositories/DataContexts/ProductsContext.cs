namespace UserCommand.Repositories.DataContexts;

internal class ProductsContext : DbContext
{
    readonly IOptions<ProductsDBOptions> Options;
    public ProductsContext(IOptions<ProductsDBOptions> options)
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

    public DbSet<Product> Products { get; set; }
}