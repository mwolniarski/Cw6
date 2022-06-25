using WebApplication1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            this.prescriptionService = prescriptionService;
        }

        [HttpGet]
        [Route("{prescriptionId}")]
        public async Task<IActionResult> GetPrescriptionById(int prescriptionId)
        {
            return Ok(await prescriptionService.GetPrescriptionDtoById(prescriptionId));
        }
    }
}
