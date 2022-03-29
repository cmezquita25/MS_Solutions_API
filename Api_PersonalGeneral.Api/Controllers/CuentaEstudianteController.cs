//cSpell: disable

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
    public class CuentaEstudianteController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IAlumnoService _service;

        private readonly IValidator<AlumnoRequest> _createValidator;
        private readonly IalumnoInterface _repository;

        public CuentaEstudianteController(IalumnoInterface repository, IHttpContextAccessor httpContext, IMapper mapper, IValidator<AlumnoRequest> createValidator, IAlumnoService service)
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._createValidator = createValidator;
            this._service = service;
        }

        [HttpGet]
        [Route("TodosLosEstudiantes")]
        public async Task<IActionResult> TodosLosEstudiantes()
        {
            var Es = await _repository.TodosLosEstudiantes();
            //var Respuesta = Estudiantes.Select(g => CreateDtoFromObject(g));
            var Respuesta = _mapper.Map<IEnumerable<Estudiante>,IEnumerable<EstudianteResponses>>(Es);
            return Ok(Respuesta);
        }
        
        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> RegistrarEstudiante(AlumnoRequest alumno)
        {
            var Val = await _createValidator.ValidateAsync(alumno);

            if(!Val.IsValid)
            
                return UnprocessableEntity (Val.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<AlumnoRequest, Estudiante>(alumno);

            var id = await _repository.RegistrarEstudiante(entity);
            
            if(id <= 0)
                return Conflict($"¡ERROR!: Ocurrio un conflicto con la información...Intentelo nuevamente.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Estudiante/{id}";
            return Ok(alumno);
        }
        
        [HttpDelete]
        [Route("EliminarCuenta/{id:int}")]
        public IActionResult EliminarCuentaEstudiante(int id)
        {
            _repository.EliminarCuentaEstudiante(id);

            var MessageResult = "Se ha eliminado tu cuenta correctamente.";

            return Ok(MessageResult);
        }

        /*[HttpGet]
        [Route("Login")]
        public IActionResult LoginEstudiante(string correo, string clave)
        {
            _repository.existStudent(correo, clave);

            return Ok();
        }
        */
    }
}