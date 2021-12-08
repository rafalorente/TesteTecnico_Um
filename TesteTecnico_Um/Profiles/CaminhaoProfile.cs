using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico_Um.Data.Dtos.Caminhao;
using TesteTecnico_Um.Models;

namespace TesteTecnico_Um.Profiles
{
    public class CaminhaoProfile : Profile
    {
        public CaminhaoProfile()
        {
            CreateMap<CreateCaminhaoDto, Caminhao>();
            CreateMap<Caminhao, ReadCaminhaoDto>();
            CreateMap<UpdateCaminhaoDto, Caminhao>();
        }
    }
}
