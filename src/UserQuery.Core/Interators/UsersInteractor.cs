using UserQuery.BusinessObjects;

namespace UserQuery.Core.Interators;

internal class UsersInteractor(IUserRepository repository,
                                  IUserOutputPort presenter,
                                  IUserCache cache) : IUserInputPort
{
    public async Task GetUserAsync()
    {
        var Result = await cache.GetUsersAsync();

        if (Result == null)
        {
            Result =
                await repository
                .GetUserSortedByDescendingPriceAsync();

            await cache.SetUserAsync(Result);
        }
        await presenter.HandleResultAsync(Result);
    }
}