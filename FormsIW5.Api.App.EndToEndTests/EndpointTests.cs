using Azure;
using FormsIW5.Common.BL.Models.User;
using FormsIW5.Common.Enums;
using System.Net;

namespace FormsIW5.Api.App.EndToEndTests;

public class EndpointTests : IClassFixture<HttpClientFixture>
{

    // ** NOTICE: **
    // Unable to complete all end-to-end tests due to insufficient Azure credits. 
    // Realized too late that creating a new SQL Server database incurs charges, reducing available credits.
    // Consequently, I could not afford to finish all end-to-end tests.

    private readonly HttpClientFixture _clientFixture;

    public EndpointTests(HttpClientFixture clientFixture)
    {
        _clientFixture = clientFixture;
    }

    //DummyClass
    private class DummyUserDetailModel
    {
        public required string UserName { get; set; }
        public string? ProfilePicture { get; set; }
        public int Role { get; set; }
    }

    // -- USERS --

    [Fact]
    public async Task User_Create_One_User_ReturnsNewUserId()
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

        //Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Guid>();
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public async Task User_Create_Two_User_WithSameId_ReturnsConflict()
    {
        //Arrange
        var newUser = new UserDetailModel
        {
            UserName = "Test2",
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

    [Fact]
    public async Task User_GetAllUsers_ReturnsAtleastOne()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test3",
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
    public async Task User_Create_One_User_And_GetUserList_ById_ReturnsSameUser()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test4",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);

        var postResponse = await _clientFixture.Client.PostAsync("/api/user/", content);
        postResponse.EnsureSuccessStatusCode();
        var postResult = await postResponse.Content.ReadFromJsonAsync<Guid>();

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/list/{postResult}");
        var getResult = await getResponse.Content.ReadFromJsonAsync<UserListModel>();

        //Assert
        Assert.NotNull(getResult);
        Assert.NotEqual(Guid.Empty, getResult.Id);
        Assert.Equal(newUser.UserName, getResult.UserName);
        Assert.Equal(newUser.ProfilePicture, getResult.ProfilePicture);
        Assert.Equal(newUser.Role, getResult.Role);
    }

    [Fact]
    public async Task User_Create_One_User_And_GetUserDetail_ById_ReturnsSameUser()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test5",
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
        Assert.Empty(getResult.Forms);
    }

    [Fact]
    public async Task User_Create_One_User_WithOnly_UserName_And_ProfilePicture_GetUserDetail_ById_ReturnsSameUserWithDefaultValues()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test6",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
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
        Assert.Equal(UserRole.User, getResult.Role);
        Assert.Empty(getResult.Forms);
    }

    [Fact]
    public async Task User_Create_One_User_WithOnly_UserName_And_Role_GetUserDetail_ById_ReturnsSameUserWithDefaultValues()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test7",
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
        Assert.Null(getResult.ProfilePicture);
        Assert.Equal(newUser.Role, getResult.Role);
        Assert.Empty(getResult.Forms);
    }

    [Fact]
    public async Task User_Create_One_User_WithOnly_UserName_GetUserDetail_ById_ReturnsSameUserWithDefaultValues()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test8"
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
        Assert.Null(getResult.ProfilePicture);
        Assert.Equal(UserRole.User, getResult.Role);
        Assert.Empty(getResult.Forms);
    }

    //9
    [Fact]
    public async Task User_Create_One_User_WithNotAbsolute_ProfilePictureUrl_ReturnsBadRequest()
    {
        //Arrange
        var newUser = new DummyUserDetailModel
        {
            UserName = "Test9",
            ProfilePicture = "string",
            Role = 0
        };

        var content = JsonContent.Create(newUser);

        // Act
        var postResponse = await _clientFixture.Client.PostAsync("/api/user/", content);

        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, postResponse.StatusCode);
    }

    [Fact]
    public async Task User_Create_One_User_GetUserDetail_ById_WithEmptyGuid_ReturnsBadRequest()
    {
        //Arrange
        Guid uniqueId = Guid.Empty;

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/{uniqueId}");

        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, getResponse.StatusCode);
    }

    [Fact]
    public async Task User_Create_One_User_GetUserDetail_ById_UniqueGuid_ReturnsBadRequest()
    {
        //Arrange
        Guid uniqueId = Guid.Parse("7e29b62c-77ad-4cb3-9ef5-c56e231876a7");

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/{uniqueId}");

        //Assert
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task User_Create_One_User_And_SearchUser_ByUserName_ReturnsAtleastOneUser()
    {
        //Arrange
        var newUser = new UserCreateModel
        {
            UserName = "Test12",
            ProfilePicture = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Onions.jpg/387px-Onions.jpg"),
            Role = UserRole.User
        };

        var content = JsonContent.Create(newUser);

        var postResponse = await _clientFixture.Client.PostAsync("/api/user/", content);
        postResponse.EnsureSuccessStatusCode();

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/search/?username={newUser.UserName}");
        getResponse.EnsureSuccessStatusCode();

        var getResult = await getResponse.Content.ReadFromJsonAsync<ICollection<UserListModel>>();

        //Assert
        Assert.NotNull(getResult);
        Assert.NotEmpty(getResult);
    }

    [Fact]
    public async Task User_SearchUser_ByUniqueUserName_ReturnsEmptyList()
    {
        //Arrange
        var username = "Test13";

        // Act
        var getResponse = await _clientFixture.Client.GetAsync($"/api/user/search/?username={username}");
        getResponse.EnsureSuccessStatusCode();

        var getResult = await getResponse.Content.ReadFromJsonAsync<ICollection<UserListModel>>();

        //Assert
        Assert.NotNull(getResult);
        Assert.Empty(getResult);
    }

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
        Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
    }
}