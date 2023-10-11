namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class SynchronizeAudioListStoreDto
    {
        public List<AudioFileDto> audioList { get; set; }
        public int storeId { get; set; }
    }
}
