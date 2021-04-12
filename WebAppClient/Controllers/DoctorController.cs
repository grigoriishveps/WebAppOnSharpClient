using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorService DoctorService { get; }
        
        public DoctorController(IDoctorService doctorService)
        {
            DoctorService = doctorService;
        }
        public async Task<IActionResult> List()
        {
            return View(await this.DoctorService.GetDoctor());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(await this.DoctorService.GetDoctor());
        }
        [HttpPost]
        public async Task<IActionResult> Put(Doctor doctor)
        {
            await this.DoctorService.PutDoctor(doctor);
            //Console.Out.WriteLine(doctor);
            return RedirectToAction("List");
        }
        
        // public async Task<IActionResult> List()
        // {
        //     return View(await this.DoctorService.GetDoctor());
        // }
        // public async Task<IActionResult> List()
        // {
        //     return View(await this.DoctorService.GetDoctor());
        // }
    }
}