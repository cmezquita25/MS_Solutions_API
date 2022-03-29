//cSpell:disable
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
    public class ProfesorController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly ICursoService _service;

        private readonly IPorfesorService _profservice;
        private readonly IValidator<CursoRequests> _createValidator;
        private readonly ImaestroInterface _repository;

        public ProfesorController(ImaestroInterface repository, IHttpContextAccessor httpContext, IMapper mapper, IValidator<CursoRequests> createValidator, ICursoService service, IPorfesorService profservice)
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._createValidator = createValidator;
            this._service = service;
            this._profservice = profservice;
        }

        //*Ver todos los cursos
        [HttpGet]
        [Route("TodosLosCursos")]
        public async  Task<IActionResult> TodosLosCursos()
        {
            var cursos = await _repository.TodosLosCursos();
            //var answerCursos = _mapper.Map<IEnumerable<Curso>,IEnumerable<CursoResponses>>(cursos);
            return Ok(cursos);
        } 

        //*Registrar curso
        [HttpPost]
        [Route("RegistrarCurso")]
        public async Task<IActionResult> RegistrarCurso(CursoRequests curso)
        {
            var Val = await _createValidator.ValidateAsync(curso);

            if(!Val.IsValid)
            
                return UnprocessableEntity (Val.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<CursoRequests, Curso>(curso);

            var id = await _repository.RegistrarCurso(entity);
            
            if(id <= 0)
                return Conflict($"¡ERROR!: Ocurrio un conflicto con la información...Intentelo nuevamente.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Profesor/Curso/{id}";
            return Ok(curso);
        }

        //*Buscar curso por id
        [HttpGet]
        [Route("Curso/{id:int}")]
        public async Task<IActionResult> CursoPorId(int id)
        {
            var Curso = await _repository.CursoPorId(id);

            if(Curso == null)
                return NotFound("Lo sentimos, el curso no fue encontrado.");

            //var respuesta = _mapper.Map<Curso, CursoResponses>(Curso);

            return Ok(Curso);
        }

        //*Modificar curso
        [HttpPut]
        [Route("ModificarCurso/{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]Curso curso)
        {
            if(id <= 0)
                return NotFound("No se encontro el curso");
            
            curso.IdCurso = id;

            var Validated = _service.ActualizarCurso_Validated(curso);

            if(!Validated)
                UnprocessableEntity("No es posible actualizar la informacion.");

            var updated = await _repository.Update(id, curso);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar el curso.");
            
            return Ok(curso);
        }
        //*Eliminar curso
        [HttpDelete]
        [Route("EliminarCurso/{id:int}")]
        public IActionResult EliminarCurso(int id)
        {
            _repository.EliminarCurso(id);

            var MessageResult = "Se ha eliminado el curso correctamente.";

            return Ok(MessageResult);
        }


        //*El profesor podra buscar su información
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> ProfesorPorId(int id)
        {
            var Profesor = await _repository.ProfesorPorId(id);

            if(Profesor == null)
                return NotFound("Lo sentimos, su cuenta no fue encontrada.");

            // respuesta = _mapper.Map<Profesor, ProfesorResponses>(Profesor);

            return Ok(Profesor);
        }

        //*El profesor podra modificar su información
        [HttpPut]
        [Route("ModificarInfo/{id:int}")]
        public async Task<IActionResult> ActualizarProfesor (int id,[FromBody]Profesor profesor)
        {
            if(id <= 0)
                return NotFound("No se encontro su cuenta");
            
            profesor.IdProfesor = id;

            var Validated = _profservice.ActualizarProfesor_Validated(profesor);

            if(!Validated)
                UnprocessableEntity("No es posible actualizar la informacion.");

            var updated = await _repository.ActualizarProfesor(id, profesor);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar su información.");
            
            return Ok(profesor);
        }
    }
}