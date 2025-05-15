
using IntegracionGemini.Interfaces;
namespace IntegracionGemini.Repository
{
    public class OpenAIRepository : iChatbotService
    {
        public Task<string> GetChatbotResponse(string prompt)
        {

            throw new NotImplementedException();
        }

        public Task<bool> SaveResponseInDatabase(string chatbotPrompt, string chatbotResponse)
        {
            throw new NotImplementedException();
        }
    }
}
