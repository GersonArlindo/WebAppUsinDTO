using MiPrimerAppWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerAppWeb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return; //Db has been seeded
            }

            var books = new Book[]
            {
                new Book{Title="El corazón de la piedra", Editorial="Nocturna", Autor="José María García López"},
                new Book{Title="Salmos de vísperas", Editorial="Obra social de Caja de Avila", Autor="Esteban Hernández Castelló"},
                new Book{Title="La música en las catedrales españolas del Siglo de Oro", Editorial="Alianza Música", Autor="Robert Stevenson"},
                new Book{Title="Tomás Luis de Victoria: A guide to research", Editorial="Garland Publishing Inc.", Autor="Eugene Casjen Cramer"},
                new Book{Title="Studies in the Music of Tomás Luis de Victoria", Editorial="Ashgate", Autor="Eugene Casjen Cramer"}

            };
            foreach (Book b in books)
                {
                context.Books.Add(b);
            }
            context.SaveChanges();

            var students = new Student[]
            {
                new Student{StudentID=1010, Name="Gerson Arlindo", LastName="Gonzalez Calis", Address="Final 5 calle ote."},
                new Student{StudentID=2020, Name="Hellen Nicole", LastName="Ulloa Marin", Address="Colonia snta Jertrudis"},
                new Student{StudentID=3030, Name="Anderson Evelio", LastName="Gomez Salgado", Address="Av. nueva España Barrio Nueva España"},
                new Student{StudentID=4040, Name="Genesis Rocio", LastName="Guillen Martinez", Address="Avenida Jerusalen"},
                new Student{StudentID=5050, Name="Amada Marleni", LastName="Vasquez", Address="Barrio Dolores Chinameca San Miguel"}
            };
            foreach (Student s in students)
                {
                context.Students.Add(s);
            }
            context.SaveChanges();
            var loans = new Loan[]
            {
                new Loan{BookID=1, StudentID=1010, DateLoan=DateTime.Parse("2020-09-01")},
                new Loan{BookID=3, StudentID=2020, DateLoan=DateTime.Parse("2020-10-01")},
                new Loan{BookID=3, StudentID=3030, DateLoan=DateTime.Parse("2020-11-01")},
                new Loan{BookID=4, StudentID=4040, DateLoan=DateTime.Parse("2020-01-01")},
                new Loan{BookID=5, StudentID=5050, DateLoan=DateTime.Parse("2020-02-01")}
            };
            foreach (Loan l in loans)
            {
                context.Loans.Add(l);
            }
            context.SaveChanges();
        }

    }
}
