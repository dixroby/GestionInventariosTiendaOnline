namespace ProductsCommand.Core.Tests.Presenters;

public class ProductsPresenterTests
{
    [Fact]
    public async Task HandleResultAsync_Should_CompleteTask()
    {
        // Arrange
        var presenter = new ProductsPresenter();

        // Act
        var task = presenter.HandleResultAsync();

        // Assert
        Assert.Equal(Task.CompletedTask, task);
    }
}