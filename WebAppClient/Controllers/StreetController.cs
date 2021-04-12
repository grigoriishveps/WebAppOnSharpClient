using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class StreetController : Controller
    {
        // GET
        private IStreetService StreetService { get; }
        
        public StreetController(IStreetService streetService)
        {
            StreetService = streetService;
        }
        public async Task<IActionResult> ListStreets()
        {
            return View(await this.StreetService.GetStreet());
        }

      
        [HttpPost]
        public async Task<IActionResult> Put(Street street)
        {
            await this.StreetService.PutStreet(street);
            //Console.Out.WriteLine(street);
            return RedirectToAction("ListStreets");
        }

    }
}