namespace UserCommand.Repositories.Configurations;

internal class ProductsConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var products = new List<User>
        {
            new User
            {
                Id = 1,
                UserName = "ADMIN",
                Role = "ADMINISTRADOR",
            }
        };

        builder.HasData(products);
    }
}