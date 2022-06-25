using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly MainDbContext _dbContext;

        public PrescriptionService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PrescriptionReadDto> GetPrescriptionDtoById(int prescriptionId)
        {
            return await _dbContext.Prescriptions
                 .Include(p => p.PrescriptionMedicaments)
                 .Where(p => p.IdPrescription == prescriptionId)
                 .Select(p => new PrescriptionReadDto
                 {
                     IdPrescription = p.IdPrescription,
                     Date = p.Date,
                     DueDate = p.DueDate,
                     Doctor = new DoctorReadDto
                     {
                         IdDoctor = p.Doctor.IdDoctor,
                         FirstName = p.Doctor.FirstName,
                         LastName = p.Doctor.LastName,
                         Email = p.Doctor.Email
                     },
                     Patient = new PatientReadDto
                     {
                         IdPatient = p.Patient.IdPatient,
                         FirstName = p.Patient.FirstName,
                         LastName = p.Patient.LastName,
                         BirthDate = p.Patient.BirthDate
                     },
                     Medicaments = p.PrescriptionMedicaments.Select(m => new MedicamentReadDto
                     {
                         IdMedicament = m.IdMedicament,
                         Name = m.Medicament.Name,
                         Description = m.Medicament.Description,
                         Type = m.Medicament.Type
                     })
                 }).FirstAsync();
        }
    }
}
