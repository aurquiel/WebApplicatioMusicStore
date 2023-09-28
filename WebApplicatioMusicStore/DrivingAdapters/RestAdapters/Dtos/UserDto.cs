using ClassLibraryDomain.Models;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Alias { get; set; }
        public string? Password { get; set; }
        public int StoreId { get; set; }
        public string? Rol { get; set; }
        public DateTime CreationDateTime { get; set; }

        public override bool Equals(object obj)
        {
            return this.Id == ((UserDto)obj).Id && 
                this.Alias == ((UserDto)obj).Alias && 
                this.StoreId == ((UserDto)obj).StoreId &&
                this.Rol == ((UserDto)obj).Rol && 
                DateTime.Compare(this.CreationDateTime, ((UserDto)obj).CreationDateTime) == 0;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash += (hash * 7) + Id.GetHashCode();
            hash += (hash * 7) + Alias.GetHashCode();
            hash += (hash * 7) + StoreId.GetHashCode();
            hash += (hash * 7) + Rol.GetHashCode();
            hash += (hash * 7) + CreationDateTime.GetHashCode();
            return hash;
        }
    }
}
