namespace ProductsCommand.Repositories.Entities;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int QuantityInventory { get; set; }
}