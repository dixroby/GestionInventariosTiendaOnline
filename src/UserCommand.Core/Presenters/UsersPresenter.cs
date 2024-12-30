namespace UserCommand.Core.Presenters;

internal class UsersPresenter(): IUsersOutputPort
{
    public Task HandleResultAsync()
    {
        return Task.CompletedTask;
    }
}