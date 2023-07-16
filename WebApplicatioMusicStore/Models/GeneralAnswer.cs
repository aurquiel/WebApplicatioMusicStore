namespace WebApplicatioMusicStore.Models
{
    public class GeneralAnswer
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public object Data { get; set; }

        public GeneralAnswer(bool status, string statusMessage, object data)
        {
            Status = status;
            StatusMessage = statusMessage;
            Data = data;
        }
    }
}
