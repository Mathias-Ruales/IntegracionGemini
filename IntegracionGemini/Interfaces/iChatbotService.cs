namespace IntegracionGemini.Interfaces
{
    public interface iChatbotService
    {

        public Task<string> GetChatbotResponse(string prompt);
        public Task<bool> SaveResponseInDatabase(string chatbotPrompt, string chatbotResponse);

    }
}
