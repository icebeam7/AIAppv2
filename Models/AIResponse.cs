namespace AIApp.Models
{
    public class AIResponse
    {
        public string id { get; set; }
        public int created { get; set; }
        public AIChoice[] choices { get; set; }
    }
}
