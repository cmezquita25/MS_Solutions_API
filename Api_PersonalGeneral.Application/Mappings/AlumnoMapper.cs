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
    public class AlumnoMapper : Profile
    {
        public AlumnoMapper()
        {
            CreateMap<Estudiante, EstudianteResponses>()

            .ForMember(c => c.NombreCompleto, opt => opt.MapFrom(src => src.NombreCompleto))
            .ForMember(c => c.Correo, opt => opt.MapFrom(src =>src.Correo))
            .ForMember(c => c.Clave, opt => opt.MapFrom(src => src.Clave));
            

            CreateMap<AlumnoRequest, Estudiante>();
        }
    }
}