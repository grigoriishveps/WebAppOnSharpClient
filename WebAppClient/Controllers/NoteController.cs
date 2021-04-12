using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class NoteController : Controller
    {
        // GET
        private INoteService NoteService { get; }
        private IPatientService PatientService { get; }
        private IDoctorService DoctorService { get; }
        private IDiseaseService DiseaseService { get; }
        
        public NoteController(INoteService noteService, IPatientService patientService, IDoctorService doctorService, IDiseaseService diseaseService)
        {
            NoteService = noteService;
            PatientService = patientService;
            DoctorService = doctorService;
            DiseaseService = diseaseService;
        }

        public async Task<IActionResult> Notes()
        {
            
            return View(await this.NoteService.GetNote());
        }

        [HttpGet]
        public async Task<IActionResult> AddNote()
        {
            return View(new HelpObjects(await  this.PatientService.GetPatient(),
                await  this.DoctorService.GetDoctor(),
                await this.DiseaseService.GetDisease()));
        }
        [HttpPost]
        public async Task<IActionResult> Put(Note note)
        {
            await this.NoteService.PutNote(note);
            //Console.Out.WriteLine(note);
            return RedirectToAction("Notes");
        }
    }
}