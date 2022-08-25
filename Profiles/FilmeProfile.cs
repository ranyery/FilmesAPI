using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile: Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
        }
    }
}
