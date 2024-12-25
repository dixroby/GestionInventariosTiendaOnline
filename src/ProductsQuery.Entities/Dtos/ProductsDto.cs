namespace ProductsQuery.Entities.Dtos;

public class ProductsDto(int id, string name, string description, decimal price)
{
    public int Id => id;
    public string Name => name;
    public string Description => description;
    public decimal Price => price;
    public string GetFormattedBasePrice() => price.ToString("N2");
}
