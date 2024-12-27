namespace UserCommand.Repositories.Configurations;

internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(s => s.Price)
            .HasPrecision(8, 2);

        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Arroz",
                Price = 3.99,
                Description = "Arroz blanco de grano largo, ideal para acompañar tus comidas.",
                Category ="Granos",
                QuantityInventory = 10
            }
        };

        builder.HasData(products);
    }
}
