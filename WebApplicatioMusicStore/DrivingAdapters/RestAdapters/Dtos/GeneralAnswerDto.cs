namespace WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos
{
    public class GeneralAnswerDto<T> where T : class
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public T Data { get; set; }

        public GeneralAnswerDto(bool status, string statusMessage, T data)
        {
            Status = status;
            StatusMessage = statusMessage;
            Data = data;
        }
    }
}
