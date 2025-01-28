namespace FormsIW5.Api.DAL.Common.Queries
{
    public record OwnerQueryObject
    {
        public string? OwnerId { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
