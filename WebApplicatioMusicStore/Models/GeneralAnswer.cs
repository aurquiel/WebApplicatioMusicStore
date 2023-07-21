namespace WebApplicatioMusicStore.Models
{
    public class GeneralAnswer<T> where T : class
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public T Data { get; set; }

        public GeneralAnswer(bool status, string statusMessage, T data)
        {
            Status = status;
            StatusMessage = statusMessage;
            Data = data;
        }
    }
}
