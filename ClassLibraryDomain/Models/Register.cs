namespace ClassLibraryDomain.Models
{
    public class Register
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int Activity { get; set; }

        public string? Message { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
