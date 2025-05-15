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
        private iChatbotService _chatbotService;

        public HomeController( iChatbotService chatbotService)

        {
            _chatbotService = chatbotService;
        }
        public async Task<IActionResult> Index()
        {
            string response = await _chatbotService.GetChatbotResponse("Hola, como estas?");
            ViewBag.chatbotAnswer = response;
            return View();
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
    

}
