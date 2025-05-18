using IntegracionGemini.Interfaces;
using IntegracionGemini.Models;
using IntegracionGemini.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IntegracionGemini.Controllers
{
    public class HomeController : Controller
    {
        private readonly Func<string, iChatbotService> _chatbotFactory;

        public HomeController(Func<string, iChatbotService> chatbotFactory)
        {
            _chatbotFactory = chatbotFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new chatBotViewModel
            {
                SelectedProvider = "OpenAI" // default selection
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(chatBotViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Prompt))
            {
                model.Error = "Please enter a prompt.";
                return View(model);
            }

            var chatbot = _chatbotFactory(model.SelectedProvider);
            model.ChatbotResponse = await chatbot.GetChatbotResponse(model.Prompt);

            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration =0, Location = ResponseCacheLocation.None, NoStore =true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    //aaaaaaaaaaaaa

}
