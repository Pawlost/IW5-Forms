using FormsIW5.Common.BL.Models.User;
using FormsIW5.Common.Enums;

namespace FormsIW5.Api.App.EndToEndTests;

public class EndControllerTests : IAsyncLifetime
{
    private readonly FormsIW5ApiApplicationFactory application;
    private readonly HttpClient client;

    public EndControllerTests()
    {
        application = new FormsIW5ApiApplicationFactory();
        client = application.CreateClient();
    }

    [Fact]
    public async Task Check_Empty()
    {
        var response = await client.GetAsync("/api/user/");

        response.EnsureSuccessStatusCode();

        var recipes = await response.Content.ReadFromJsonAsync<ICollection<UserListModel>>();
        Assert.NotNull(recipes);
        Assert.Empty(recipes);


        var newUser = new UserDetailModel
        {
            UserName = "John Doe",
            Role = UserRole.User
        };

        // Serialize the user object to JSON.
        var content = JsonContent.Create(newUser);

        var responseTwo = await client.PostAsync("/api/user/", content);

        responseTwo.EnsureSuccessStatusCode();

        await responseTwo.Content.ReadFromJsonAsync<Guid>();

        var responseThree = await client.GetAsync("/api/user/");

        responseThree.EnsureSuccessStatusCode();

        var users = await responseThree.Content.ReadFromJsonAsync<ICollection<UserListModel>>();
        Assert.NotNull(users);
        Assert.NotEmpty(users);
    }

    public async Task InitializeAsync()
    {
        await application.MigrateAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await application.DisposeAsync();
    }
}
