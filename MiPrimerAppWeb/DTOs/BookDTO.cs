using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerAppWeb.DTOs
{
    public class BookDTO
    {
        [Required(ErrorMessage = "The BookId es requerido")]
        [Display(Name = "Id Libro")]
        public int BookID { get; set; }
        [Required(ErrorMessage = "The Title es requerido")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Editorial es requerido")]
        [Display(Name = "Editorial")]
        public string Editorial { get; set; }
        [Required(ErrorMessage = "The Autor es requerido")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }
    }
}
