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
    public class InscripcionesMapper : Profile
    {
        public InscripcionesMapper()
        {
            CreateMap<Inscripcion, InscripcionesResponses>()
            
            .ForMember(i => i.IdInscripcion, opt => opt.MapFrom(src => src.IdInscripcion))
            .ForMember(i => i.IdEstudiante, opt => opt.MapFrom(src => src.IdEstudiante))
            .ForMember(i => i.IdCurso, opt => opt.MapFrom(src => src.IdCurso));

            CreateMap<InscripcionRequest, Inscripcion>();

        }
    }
}