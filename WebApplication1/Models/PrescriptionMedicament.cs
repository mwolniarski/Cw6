using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        [Required]
        [MaxLength(100)]
        public string Details { get; set; }

        [ForeignKey("IdMedicament")]
        public virtual Medicament Medicament { get; set; }

        [ForeignKey("IdPrescription")]
        public virtual Prescription Prescription { get; set; }
    }
}
