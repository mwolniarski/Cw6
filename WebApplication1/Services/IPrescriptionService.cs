using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public interface IPrescriptionService
    {
        Task<PrescriptionReadDto> GetPrescriptionDtoById(int prescriptionId);
    }
}
