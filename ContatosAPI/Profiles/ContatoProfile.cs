using AutoMapper;
using ContatosAPI.Data.Dtos;
using ContatosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContatosAPI.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<CriarContatoDto, Contato>();
            CreateMap<AlteraContatoDto, Contato>();

        }
    }
}
