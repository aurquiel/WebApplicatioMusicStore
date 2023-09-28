namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class SynchronizeAudioListStoreDto
    {
        public List<AudioFileDto> audioList { get; set; }
        public string storeCode { get; set; }
    }
}
