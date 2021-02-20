using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPrimerAppWeb.Data.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


        public ICollection<Loan> Loans { get; set; }
    }
}
