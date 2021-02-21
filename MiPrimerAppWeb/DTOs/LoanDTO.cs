using MiPrimerAppWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerAppWeb.DTOs
{
    public class LoanDTO
    {
        [Required(ErrorMessage = "The PrestamoId es requerido")]
        [Display(Name = "Id Prestamo")]
        public int LoanID { get; set; }
        [Required(ErrorMessage = "The BookId es requerido")]
        [Display(Name = "Id Libro")]
        public int BookID { get; set; }
        [Required(ErrorMessage = "The EstudentId es requerido")]
        [Display(Name = "Id Estudiante")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "The Fecha de prestamo es requerido")]
        [Display(Name = "Fecha de Prestamo")]
        public DateTime DateLoan { get; set; }

        public Student Student { get; set; }
        public Book Book { get; set; }
    }
}
