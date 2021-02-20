using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiPrimerAppWeb.DTOs;
using MiPrimerAppWeb.Data.Entities;

namespace MiPrimerAppWeb.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();

        }
    }
}
