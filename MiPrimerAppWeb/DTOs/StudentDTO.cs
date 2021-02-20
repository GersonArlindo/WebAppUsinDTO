using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerAppWeb.DTOs
{
    public class StudentDTO
    {
        [Required(ErrorMessage = "The StudentID es requerido")]
        [Display (Name = "Id Estudiante")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "The Name es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The LastName es requerido")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Address es requerido")]
        [Display(Name = "Direccion")]
        public string Address { get; set; }
    }
}
