using System;
using AutoMapper;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using Api_PersonalGeneral.Domain.Entities;
using Api_PersonalGeneral.Domain.Interfaces;
using Api_PersonalGeneral.Domain.DTOS.requests;
using Api_PersonalGeneral.Domain.DTOS.responses;
using Api_PersonalGeneral.Infraestructure.Repositories;

namespace Api_PersonalGeneral.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscripcionesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IInscripcionesIntefaces _repository;

        public InscripcionesController(IInscripcionesIntefaces repository, IHttpContextAccessor httpContext, IMapper mapper)
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("TodosLosInscritos")]
        public async Task<IActionResult> TodosLosInscritos()
        {
            var Is = await _repository.TodosLosInscritos();
            //var Respuesta = Estudiantes.Select(g => CreateDtoFromObject(g));
            //var Respuesta = _mapper.Map<IEnumerable<Inscripcion>,IEnumerable<InscripcionesResponses>>(Is);
            return Ok(Is);
        }
    }
}