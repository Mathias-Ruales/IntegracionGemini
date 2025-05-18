using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IntegracionGemini.Models
{
    public class chatBotViewModel
    {
        public string SelectedProvider { get; set; }
        public string Prompt { get; set; }
        public string ChatbotResponse { get; set; }
        public string Error { get; set; }

        public List<SelectListItem> Providers { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "OpenAI", Text = "OpenAI" },
            new SelectListItem { Value = "Gemini", Text = "Gemini" }
        };
    }
}
