namespace IntegracionGemini.Models
{
    public class OpenAiRequest
    {
        public string model { get; set; } = "deepseek-chat";
        public List<DeepSeekMessage> messages { get; set; }
    }

    public class DeepSeekMessage
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
