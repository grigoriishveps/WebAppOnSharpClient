using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService PatientService { get; }
        private IStreetService StreetService { get; }
        public PatientController(IPatientService patientService, IStreetService streetService)
        {
            PatientService = patientService;
            StreetService = streetService;
        }
        public async  Task<IActionResult> List()
        {
            return View(await this.PatientService.GetPatient());
        }
      
        public async Task<IActionResult> AddPatient()
        {
            return View(await  this.StreetService.GetStreet());
        }

        [HttpPost]
        public async Task<IActionResult> Put(Patient patient)
        {
            System.Console.WriteLine(" fdfsdf"  + patient.StreetId);
            await this.PatientService.PutPatient(patient);
            return RedirectToAction("List");
        }
    }
}