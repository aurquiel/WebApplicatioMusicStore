namespace ClassLibraryDomain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Alias { get; set; }

        public string? Password { get; set; }

        public int StoreId { get; set; }

        public string? Rol { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
