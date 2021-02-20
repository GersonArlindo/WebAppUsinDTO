using System;
using System.Collections.Generic;

namespace MiPrimerAppWeb.Data.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }

        public ICollection<Loan> Loans { get; set; }

    }
}
