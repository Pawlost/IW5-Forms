namespace FormsIW5.Api.BL.Queries
{
    public record OwnerQueryParameters
    {
        public string? OwnerId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
