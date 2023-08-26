namespace WebApplicationMusicStore.Models
{
    public class AudioFile
    {
        public string Name { get; set; }
        
        public string Path { get; set; }

        public TimeSpan Duration { get; set; }

        public double Size { get; set; }
    }
}
