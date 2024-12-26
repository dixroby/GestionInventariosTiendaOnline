namespace ProductsQuery.Core.Cache;

internal class ProductsCache(IDistributedCache cache,
                             ILogger<ProductsCache> logger): IProductsCache
{
    const string CacheKey = "productsCache";

    public async Task<IEnumerable<ProductsDto>> GetProductsAsync()
    {
        IEnumerable<ProductsDto> products = null;
        try
        {
            var productsCache = await cache.GetStringAsync(CacheKey);
            if (!string.IsNullOrEmpty(productsCache))
            {
                products = JsonSerializer.Deserialize<IEnumerable<ProductsDto>>(productsCache);
                logger.LogInformation("Products retrieved from cache");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting products from cache");
        }
        return products;
    }

    public async Task SetProductsAsync(IEnumerable<ProductsDto> products)
    {
        try
        {
            string productsJson = JsonSerializer.Serialize(products);
            var options = 
                new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));

            await cache.SetStringAsync(CacheKey, productsJson, options);
            logger.LogInformation("Set Specials to cache");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }
}