using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorReadDto>> GetDoctors();
        Task<DoctorReadDto> GetDoctorDtoById(int doctorId);
        Task AddDoctor(DoctorWriteDto doctor);
        Task UpdateDoctor(DoctorWriteDto doctor, int doctorId);
        Task DeleteDoctorById(int doctorId);
    }
}
