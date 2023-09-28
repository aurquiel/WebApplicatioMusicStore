using NAudio.CoreAudioApi;

namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int Activity { get; set; }
        public string? Message { get; set; }
        public DateTime CreationDateTime { get; set; }

        public override bool Equals(object obj)
        {
            return this.Id == ((RegisterDto)obj).Id &&
                this.StoreId == ((RegisterDto)obj).StoreId &&
                this.Activity == ((RegisterDto)obj).Activity &&
                this.Message == ((RegisterDto)obj).Message &&
                DateTime.Compare(this.CreationDateTime, ((RegisterDto)obj).CreationDateTime) == 0;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash += (hash * 7) + Id.GetHashCode();
            hash += (hash * 7) + StoreId.GetHashCode();
            hash += (hash * 7) + Activity.GetHashCode();
            hash += (hash * 7) + Message.GetHashCode();
            hash += (hash * 7) + CreationDateTime.GetHashCode();
            return hash;
        }
    }
}
