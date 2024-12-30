namespace ProductsQuery.Entities.Dtos;

public class ProductsDto(int id, string name, string description, double price, string category, int quantityInventory)
{
    public int Id => id;
    public string Name => name;
    public string Description => description;
    public double Price => price;
    public string Category => category;
    public int QuantityInventory => quantityInventory;
    public string GetFormattedBasePrice() => price.ToString("N2");

    public static bool TryParse(string input, out ProductsDto product) 
    { 
        product = null; 
        var parts = input.Split(','); 
        if (parts.Length != 6) return false; 
        if (!int.TryParse(parts[0], out int id) || !double.TryParse(parts[3], out double price) || !int.TryParse(parts[5], out int quantityInventory)) 
        { return false; } product = new ProductsDto(id, parts[1], parts[2], price, parts[4], quantityInventory); return true; 
    }
}
