namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class AudioFileDto
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public int StoreId { get; set; }

        public string Path { get; set; }

        public double Size { get; set; }

        public TimeSpan Duration { get; set; }

        public bool CheckForTime { get; set; }

        public TimeSpan TimeToPlay { get; set; }

        public override bool Equals(object obj)
        {
            return this.Id == ((AudioFileDto)obj).Id &&
                this.Order == ((AudioFileDto)obj).Order &&
                this.Name == ((AudioFileDto)obj).Name &&
                this.StoreId == ((AudioFileDto)obj).StoreId &&
                this.Path == ((AudioFileDto)obj).Path &&
                this.Size == ((AudioFileDto)obj).Size &&
                TimeSpan.Compare(this.Duration, ((AudioFileDto)obj).Duration) == 0 &&
                this.CheckForTime == ((AudioFileDto)obj).CheckForTime &&
                TimeSpan.Compare(this.TimeToPlay, ((AudioFileDto)obj).TimeToPlay) == 0;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash += (hash * 7) + Id.GetHashCode();
            hash += (hash * 7) + Order.GetHashCode();
            hash += (hash * 7) + Name.GetHashCode();
            hash += (hash * 7) + StoreId.GetHashCode();
            hash += (hash * 7) + Path.GetHashCode();
            hash += (hash * 7) + Size.GetHashCode();
            hash += (hash * 7) + Duration.GetHashCode();
            hash += (hash * 7) + CheckForTime.GetHashCode();
            hash += (hash * 7) + TimeToPlay.GetHashCode();
            return hash;
        }
    }
}
