namespace AIApp.Models
{
    public class AIChoice
    {
        public int index { get; set; }
        public string finish_reason { get; set; }
        public AIMessage message { get; set; }
    }
}
