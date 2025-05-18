using IntegracionGemini.Interfaces;
using IntegracionGemini.Models;
using Microsoft.Extensions.FileProviders.Composite;
using Newtonsoft.Json;
using System.Text;

namespace IntegracionGemini.Repository
{
    public class GeminiRepository : iChatbotService
    {
        private HttpClient _httpClient;
        private string GeminiKey = "AIzaSyDlEsNyQ2UuPtFVKkGR-zyfi7SkGuQrLeM";

        public GeminiRepository()
        {
            _httpClient = new HttpClient(); 
        }
        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + GeminiKey;

            GeminiRequest request = new GeminiRequest
            {
                contents = new List<GeminiContent>
                {
                    new GeminiContent
                    {
                        parts = new List<GeminiPart>
                        {
                            new GeminiPart
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };
            string requestJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            var answer = await response.Content.ReadAsStringAsync();
            
            
            dynamic jsonResponse = JsonConvert.DeserializeObject(answer);
            string resultText = jsonResponse?.candidates?[0]?.content?.parts?[0]?.text;

            return resultText ?? "No response from model.";
        }

        public Task<bool> SaveResponseInDatabase(string chatbotPrompt, string chatbotResponse)
        {
            throw new NotImplementedException();
        }

      
    }
}
