namespace ProductsQuery.Repositories.Options;

public class ProductsDBOptions
{
    public const string SectionKey = nameof(ProductsDBOptions);
    public string ConnectionString { get; set; }
}