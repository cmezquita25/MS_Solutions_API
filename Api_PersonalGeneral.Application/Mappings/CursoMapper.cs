//cSpell:disable

using AutoMapper;
using Api_PersonalGeneral.Domain.Entities;
using Api_PersonalGeneral.Domain.DTOS.requests;
using Api_PersonalGeneral.Domain.DTOS.responses;

namespace Api_PersonalGeneral.Application.Mappings
{
    public class CursoMapper : Profile
    {
        public CursoMapper()
        {
            CreateMap<Curso, CursoResponses>()

            .ForMember(c => c.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(c => c.FechaDeInicio, opt => opt.MapFrom(src => src.FechaInicio))
            .ForMember(c => c.FechaDeCierre, opt => opt.MapFrom(src => src.FechaCierre))
            .ForMember(c => c.Descripcion, opt => opt.MapFrom(src => src.Descripcion));
            

            CreateMap<CursoRequests, Curso>();
            
        }
    }
}