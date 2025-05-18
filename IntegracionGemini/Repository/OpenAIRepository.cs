using System.Text;
using IntegracionGemini.Interfaces;
using IntegracionGemini.Models;
using Newtonsoft.Json;

namespace IntegracionGemini.Repository
{
    public class OpenAIRepository : iChatbotService
    {
        private readonly HttpClient _httpClient;

        private readonly string OpenAiKey = "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";

        public OpenAIRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", OpenAiKey);
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = "https://api.groq.com/openai/v1/chat/completions";

            var request = new OpenAiRequest
            {
                model = "llama-3.3-70b-versatile",
                messages = new List<DeepSeekMessage>
        {
            new DeepSeekMessage { role = "user", content = prompt }
        }
            };

            string json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Content = content;

            // Use your GROQ API key here
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", OpenAiKey);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
            string resultText = jsonResponse?.choices?[0]?.message?.content;

            return resultText ?? "No response from model.";
        }

        public Task<bool> SaveResponseInDatabase(string chatbotPrompt, string chatbotResponse)
        {
            throw new NotImplementedException();
        }
    }
}
