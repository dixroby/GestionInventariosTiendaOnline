namespace ProductsCommand.Repositories.Configurations;

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
            },
            new Product
            {
                Id = 2,
                Name = "Frijoles Negros",
                Price = 2.99,
                Description = "Frijoles negros secos, perfectos para preparar guisos y ensaladas.",
                Category ="Granos",
                QuantityInventory = 11
            },
            new Product
            {
                Id = 3,
                Name = "Aceite de Oliva",
                Price = 5.49,
                Description = "Aceite de oliva extra virgen para aderezar ensaladas y cocinar.",
                Category ="Granos",
                QuantityInventory = 8
            },
            new Product
            {
                Id = 4,
                Name = "Azúcar",
                Price = 1.49,
                Description = "Azúcar blanca refinada para endulzar bebidas y postres.",
                Category ="Granos",
                QuantityInventory = 4
            }
        };

        builder.HasData(products);
    }
}
