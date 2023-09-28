using ClassLibraryDomain.Models;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public DateTime CreationDateTime { get; set; }

        public override bool Equals(object obj)
        {
            return this.Id == ((StoreDto)obj).Id && 
                this.Code == ((StoreDto)obj).Code && 
                DateTime.Compare(this.CreationDateTime, ((StoreDto )obj).CreationDateTime) == 0;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash += (hash * 7) + Id.GetHashCode();
            hash += (hash * 7) + Code.GetHashCode();
            hash += (hash * 7) + CreationDateTime.GetHashCode();
            return hash;
        }
    }
}
