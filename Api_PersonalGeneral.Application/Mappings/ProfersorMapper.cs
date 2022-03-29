//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Api_PersonalGeneral.Domain.Entities;
using Api_PersonalGeneral.Domain.DTOS.requests;
using Api_PersonalGeneral.Domain.DTOS.responses;

namespace Api_PersonalGeneral.Application.Mappings
{
    public class ProfersorMapper : Profile
    {
        public ProfersorMapper()
        {
            CreateMap<Profesor, ProfesorResponses>()

            .ForMember(c => c.NombreCompleto, opt => opt.MapFrom(src => src.NombreCompleto))
            .ForMember(c => c.Correo, opt => opt.MapFrom(src => src.Correo))
            .ForMember(c => c.Clave, opt => opt.MapFrom(src => src.Clave))
            .ForMember(c => c.RedesSociales, opt => opt.MapFrom(src => src.RedesSociales))
            .ForMember(c => c.Descripcion, opt => opt.MapFrom(src => src.Descripcion));
            

            CreateMap<ProfesorRequest, Profesor>();
        }
    }
}