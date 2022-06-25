using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly MainDbContext _dbContext;

        public DoctorService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DoctorReadDto>> GetDoctors()
        {
            return await _dbContext.Doctors.Select(x => new DoctorReadDto
            {
                IdDoctor = x.IdDoctor,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToListAsync();
        }

        public async Task<DoctorReadDto> GetDoctorDtoById(int doctorId)
        {
            Doctor doctor = await GetDoctorById(doctorId);

            return new DoctorReadDto
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
        }

        private async Task<Doctor> GetDoctorById(int doctorId)
        {
            Doctor doctor = (await _dbContext.Doctors.ToListAsync()).FirstOrDefault(doctor => doctor.IdDoctor == doctorId);
            if (doctor != null)
                return doctor;
            else
            {
                throw new Exception("Brak doktora o podanym Id: " + doctorId);
            }
        }

        public async Task AddDoctor(DoctorWriteDto doctor)
        {

            Doctor newDoctor = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            await _dbContext.AddAsync(newDoctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDoctor(DoctorWriteDto doctor, int doctorId)
        {
            Doctor doctorToUpdate = await GetDoctorById(doctorId);

            doctorToUpdate.FirstName = doctor.FirstName;
            doctorToUpdate.LastName = doctor.LastName;
            doctorToUpdate.Email = doctor.Email;

            _dbContext.Doctors.Attach(doctorToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDoctorById(int doctorId)
        {
            Doctor doctorToDelete = await GetDoctorById(doctorId);
            _dbContext.Doctors.Attach(doctorToDelete);
            _dbContext.Entry(doctorToDelete).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
