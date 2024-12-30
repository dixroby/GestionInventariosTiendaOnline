namespace ProductsCommand.Entities.Dtos;

public class ProductsDto(int id,
                         string name,
                         string description,
                         double price,
                         string category,
                         int quantityInventory)
{
    public int Id => id;
    public string Name => name;
    public string Description => description;
    public double Price => price;
    public string Category => category;
    public int QuantityInventory => quantityInventory;
}
