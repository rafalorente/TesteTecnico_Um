using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico_Um.Data.Dtos;
using TesteTecnico_Um.Models;

namespace TesteTecnico_Um.Profiles
{
    public class MotoristaProfile : Profile
    {
        public MotoristaProfile()
        {
            CreateMap<CreateMotoristaDto, Motorista>();
            CreateMap<Motorista, ReadMotoristaDto>();
            CreateMap<UpdateMotoristaDto, Motorista>();
        }
    }
}
