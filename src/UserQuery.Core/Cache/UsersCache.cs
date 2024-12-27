using UserQuery.Entities.Dtos;

namespace UserQuery.Core.Cache;

internal class UsersCache(IDistributedCache cache,
                             ILogger<UsersCache> logger) : IUserCache
{
    const string CacheKey = "productsCache";

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        IEnumerable<UserDto> products = null;
        try
        {
            var productsCache = await cache.GetStringAsync(CacheKey);
            if (!string.IsNullOrEmpty(productsCache))
            {
                products = JsonSerializer.Deserialize<IEnumerable<UserDto>>(productsCache);
                logger.LogInformation("Products retrieved from cache");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting products from cache");
        }
        return products;
    }

    public async Task SetUserAsync(IEnumerable<UserDto> products)
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