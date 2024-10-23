using FormsIW5.Common.BL.Models.User;
using FormsIW5.Common.Enums;

namespace FormsIW5.Api.App.EndToEndTests;

public class EndpointTests : IClassFixture<HttpClientFixture>
{
    // Because I am limited to a single fixture, all end to end tests are here
    // To setup fixtures for all different endpoints would require too much effort

    // What is tested is multiple users interacting with the same API
    private readonly HttpClientFixture _clientFixture;

    public EndpointTests(HttpClientFixture clientFixture)
    {
        _clientFixture = clientFixture;
    }

    [Fact]
    public async Task Check_Empty()
    {
        var response = await _clientFixture.Client.GetAsync("/api/user/");

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

        var responseTwo = await _clientFixture.Client.PostAsync("/api/user/", content);

        responseTwo.EnsureSuccessStatusCode();

        await responseTwo.Content.ReadFromJsonAsync<Guid>();

        var responseThree = await _clientFixture.Client.GetAsync("/api/user/");

        responseThree.EnsureSuccessStatusCode();

        var users = await responseThree.Content.ReadFromJsonAsync<ICollection<UserListModel>>();
        Assert.NotNull(users);
        Assert.NotEmpty(users);
    }

    [Fact]
    public async Task Check_Empty_One()
    {
        var response = await _clientFixture.Client.GetAsync("/api/user/");

        response.EnsureSuccessStatusCode();

        var recipes = await response.Content.ReadFromJsonAsync<ICollection<UserListModel>>();
        Assert.NotNull(recipes);
        Assert.Empty(recipes);
    }
}
