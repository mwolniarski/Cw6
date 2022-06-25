using WebApplication1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            return Ok((await doctorService.GetDoctors()));
        }

        [HttpGet]
        [Route("{doctorId}")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
            return Ok((await doctorService.GetDoctorDtoById(doctorId)));
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorWriteDto doctor)
        {
            await doctorService.AddDoctor(doctor);
            return Ok("Dodano doktora");
        }

        [HttpPut]
        [Route("{doctorId}")]
        public async Task<IActionResult> UpdateDoctor(DoctorWriteDto doctor, int doctorId)
        {
            await doctorService.UpdateDoctor(doctor, doctorId);
            return Ok("Zaktualizowano doktora");
        }

        [HttpDelete]
        [Route("{doctorId}")]
        public async Task<IActionResult> DeleteDoctorById(int doctorId)
        {
            await doctorService.DeleteDoctorById(doctorId);
            return Ok("Usunięto doctora o Id: " + doctorId);
        }
    }
}
