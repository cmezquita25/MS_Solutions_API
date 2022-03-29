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
    public class CuentaProfesorController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IPorfesorService _service;

        private readonly IValidator<ProfesorRequest> _createValidator;
        private readonly IprofesorInterface _repository;

        public CuentaProfesorController(IprofesorInterface repository, IHttpContextAccessor httpContext, IMapper mapper, IValidator<ProfesorRequest> createValidator, IPorfesorService service)
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._createValidator = createValidator;
            this._service = service;
        }

        [HttpGet]
        [Route("TodosLosProfesores")]
        public async Task<IActionResult> TodosLosProfesores()
        {
            var prof = await _repository.TodosLosProfesores();
            //var RespuestaDenuncia = denuncias.Select(g => CreateDtoFromObject(g));
            //var Respuesta = _mapper.Map<IEnumerable<Profesor>,IEnumerable<ProfesorResponses>>(prof);
            return Ok(prof);
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> RegistrarProfesor(ProfesorRequest profesor)
        {
            var Val = await _createValidator.ValidateAsync(profesor);

            if(!Val.IsValid)
            
                return UnprocessableEntity (Val.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<ProfesorRequest, Profesor>(profesor);

            var id = await _repository.RegistrarProfesor(entity);
            
            if(id <= 0)
                return Conflict($"¡ERROR!: Ocurrio un conflicto con la información...Intentelo nuevamente.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Profesor/{id}";
            return Ok(profesor);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public IActionResult EliminarCuenta(int id)
        {
            _repository.EliminarCuentaProfesor(id);

            var MessageResult = "Se ha eliminado tu cuenta correctamente.";

            return Ok(MessageResult);
        }

        [HttpGet]
        [Route("LoginProf/{correo}/{clave}")]
        public async Task<IActionResult> LoginProf(string correo, string clave)
        {
            var profesor = await _repository.LoginProf(correo, clave);
            return Ok(profesor);
        }
    }
}