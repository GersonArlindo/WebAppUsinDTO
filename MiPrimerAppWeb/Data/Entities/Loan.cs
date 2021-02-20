using System;

namespace MiPrimerAppWeb.Data.Entities
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int BookID { get; set; }
        public int StudentID { get; set; }
        public DateTime DateLoan { get; set; }


        public Student Student { get; set; }
        public Book Book { get; set; }
    }
}
