namespace FormsIW5.BL.Models.Common.User;

public class AppUserDetailModel
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
