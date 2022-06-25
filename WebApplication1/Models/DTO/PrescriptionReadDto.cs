using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DTO
{
    public class PrescriptionReadDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientReadDto Patient { get; set; }
        public DoctorReadDto Doctor { get; set; }
        public IEnumerable<MedicamentReadDto> Medicaments { get; set; }
    }
}
