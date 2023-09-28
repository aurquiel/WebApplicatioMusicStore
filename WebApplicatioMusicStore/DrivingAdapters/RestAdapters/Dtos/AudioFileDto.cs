namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class AudioFileDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public TimeSpan Duration { get; set; }
        public double Size { get; set; }

        public override bool Equals(object obj)
        {
            return this.Name == ((AudioFileDto)obj).Name &&
                this.Path == ((AudioFileDto)obj).Path &&
                TimeSpan.Compare(this.Duration, ((AudioFileDto)obj).Duration) == 0 &&
                this.Size == ((AudioFileDto)obj).Size;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash += (hash * 7) + Name.GetHashCode();
            hash += (hash * 7) + Path.GetHashCode();
            hash += (hash * 7) + Duration.GetHashCode();
            hash += (hash * 7) + Size.GetHashCode();
            return hash;
        }
    }
}
