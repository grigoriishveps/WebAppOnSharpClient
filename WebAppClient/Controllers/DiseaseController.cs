using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class DiseaseController:Controller
    {
        private IDiseaseService DiseaseService { get; }
        
        public DiseaseController(IDiseaseService diseaseService)
        {
            DiseaseService = diseaseService;
        }
        public async Task<IActionResult> ListDiseases()
        {
            return View(await this.DiseaseService.GetDisease());
        }
        public async Task<IActionResult> InfoDisease(int id)
        {
            return View(await this.DiseaseService.GetDisease(id));
        }
        
        public async Task<IActionResult> AddDisease()
        {
            return View(await this.DiseaseService.GetDisease());
        }
        [HttpPost]
        public async Task<IActionResult> Put(Disease disease)
        {
            await this.DiseaseService.PutDisease(disease);
            //Console.Out.WriteLine(doctor);
            return RedirectToAction("ListDiseases");
        }
    }
}