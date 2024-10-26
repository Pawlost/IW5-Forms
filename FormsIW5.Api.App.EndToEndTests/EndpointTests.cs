using Azure;
using FormsIW5.Common.BL.Models.User;
using FormsIW5.Common.Enums;
using System.Net;

namespace FormsIW5.Api.App.EndToEndTests;

public class EndpointTests : IClassFixture<HttpClientFixture>
{
    // TODO: rewrite commets
    // Because I am limited to a single fixture, all end to end tests are here
    // To setup fixtures for all different endpoints would require too much effort

    // What is tested is multiple users interacting with the same API
    // Ideally I would have more connnection strings, due to financial reasons it is like this
    private readonly HttpClientFixture _clientFixture;

    public EndpointTests(HttpClientFixture clientFixture)
    {
        _clientFixture = clientFixture;
    }

    // -- USERS --

    // 1
    [Fact]
    public async Task User_Post_Create_One_DetailUser_ReturnsNewUserId()
    {
        //Arrange
        var newUser = new UserDetailModel
        {
            UserName = "Test User10",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };
        var content = JsonContent.Create(newUser);

        //Act
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Guid>();
        Assert.NotEqual(Guid.Empty, result);
    }

    // 2
    [Fact]
    public async Task User_Create_One_DetailUser_ReturnsNewUserId()
    {
        //Arrange
        var newUser = new UserDetailModel
        {
            UserName = "Test1",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };
        var content = JsonContent.Create(newUser);

        //Act
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);
        response.EnsureSuccessStatusCode();

        var badRequestResponse = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        Assert.Equal(HttpStatusCode.Conflict, badRequestResponse.StatusCode);
    }

    /*
    [Fact]
    public async Task User_Create_And_SearchByName_ReturnsUserListWithCorrentUserNameRegex()
    {

    }

    [Fact]
    public async Task User_Create_And_Update_And_GetDetail_ReturnsUpdatedUserDetail()
    {

    }*/

    [Fact]
    public async Task User_Create_And_Delete_DeletesUserList()
    {
        //Arrange
        var newUser = new UserDetailModel
        {
            Id = Guid.Parse("8ed98a79-304f-4731-a688-2821cd1cc577"),
            UserName = "Test User21",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);

        var postResponse = await _clientFixture.Client.PostAsync("/api/user/", content);
        postResponse.EnsureSuccessStatusCode();
        var postResult = await postResponse.Content.ReadFromJsonAsync<Guid>();

        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/{postResult}");
        var getResult = await getResponse.Content.ReadFromJsonAsync<UserDetailModel>();

        // Act
        var deleteResponse = await _clientFixture.Client.DeleteAsync($"/api/user/{newUser.Id}");

        //Assert
        deleteResponse.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, getResponse.StatusCode);
    }

    [Fact]
    public async Task User_Create_One_DetailUser_And_GetAllUsers_ReturnsAtleastOne()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test User2",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);

        var postResponse = await _clientFixture.Client.PostAsync("/api/user/", content);
        postResponse.EnsureSuccessStatusCode();
        var postResult = await postResponse.Content.ReadFromJsonAsync<Guid>();

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/");
        var getResult = await getResponse.Content.ReadFromJsonAsync<ICollection<UserListModel>>();

        //Assert
        Assert.NotNull(getResult);
        Assert.NotEmpty(getResult);
    }

    [Fact]
    public async Task GetUserDetail_ByEmptyId_ReturnsNotFound()
    {
        //Arrange
        Guid uniqueId = Guid.Empty;

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/{uniqueId}");

        //Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, getResponse.StatusCode);
    }

    [Fact]
    public async Task GetUserDetail_ByUniqueId_ReturnsNotFound()
    {
        //Arrange
        Guid uniqueId = Guid.Parse("7e29b62c-77ad-4cb3-9ef5-c56e231876a7");

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/{uniqueId}");

        //Assert
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task User_Create_One_DetailUser_And_GetUserDetail_ById_ReturnsSameUser()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test User3",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);

        var postResponse = await _clientFixture.Client.PostAsync("/api/user/", content);
        postResponse.EnsureSuccessStatusCode();
        var postResult = await postResponse.Content.ReadFromJsonAsync<Guid>();

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/{postResult}");
        var getResult = await getResponse.Content.ReadFromJsonAsync<UserDetailModel>();

        //Assert
        Assert.NotNull(getResult);
        Assert.NotEqual(Guid.Empty, getResult.Id);
        Assert.Equal(newUser.UserName, getResult.UserName);
        Assert.Equal(newUser.ProfilePicture, getResult.ProfilePicture);
        Assert.Equal(newUser.Role, getResult.Role);
    }


    [Fact]
    public async Task User_Create_One_User_UserName_And_ProfilePicture_ReturnsNewUserId()
    {
        // TODO: returns correct detail
        //Arrange
        var newUser = new UserDetailModel
        {
            UserName = "Test User4",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg")
        };

        var content = JsonContent.Create(newUser);

        //Act
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Guid>();
        Assert.NotEqual(Guid.Empty, result);
    }


    [Fact]
    public async Task User_Create_One_User_UserName_And_UserRole_ReturnsNewUserId()
    {
        // TODO: returns correct detail

        //Arrange
        var newUser = new UserDetailModel
        {
            UserName = "Test User5",
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);

        //Act
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Guid>();
        Assert.NotEqual(Guid.Empty, result);
    }


    [Fact]
    public async Task User_Create_One_User_UserNameOnly_ReturnsDefaultValues()
    {
        // TODO: default values
        //Arrange
        var newUser = new UserDetailModel
        {
            UserName = "Test User6"
        };

        var content = JsonContent.Create(newUser);

        //Act
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Guid>();
        Assert.NotEqual(Guid.Empty, result);
    }

    private class DummyUserDetailModel
    {
        public string? ProfilePicture { get; set; }
        public UserRole Role { get; set; }
    }

    [Fact]
    public async Task User_Create_One_DetailUser_WithoutUserName_ReturnsBadRequest()
    {
        //Arrange
        var newUser = new DummyUserDetailModel
        {
            ProfilePicture = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg",
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);

        //Act
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task User_Create_Two_DetailUsers_WithSameUserName_ReturnsConflixt()
    {
        //Arrange
        var newUser = new UserDetailModel
        {
            UserName = "Test User8",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };
        var content = JsonContent.Create(newUser);
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);
        response.EnsureSuccessStatusCode();

        var secondPostResponse = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        Assert.Equal(System.Net.HttpStatusCode.Conflict, secondPostResponse.StatusCode);
    }
   

    [Fact]
    public async Task User_Create_One_DetailUser_WithId_ReturnsUserId()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test User",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };
        var content = JsonContent.Create(newUser);

        //Act
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Guid>();
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public async Task User_Create_Two_DetailUser_WithSameId_ReturnsConflict()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test User7",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);
        var response = await _clientFixture.Client.PostAsync("/api/user/", content);

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Guid>();

        //Act
        var conflictResponse = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        Assert.Equal(System.Net.HttpStatusCode.Conflict, conflictResponse.StatusCode);
    }
}