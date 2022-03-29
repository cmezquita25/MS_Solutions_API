using System.Collections.ObjectModel;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IadminInterface _repository;
        private readonly IPorfesorService _profservice;
        private readonly IAlumnoService _alumnoservice;
        private readonly IEstudianteService _estudianteservice;
        private readonly ICursoService _cursoservice;

        public AdminController(IHttpContextAccessor httpContext, IMapper mapper, IadminInterface repository, IPorfesorService profservice, IAlumnoService alumnoservice, IEstudianteService estudianteservice, ICursoService cursoservice)
        {
            _httpContext = httpContext;
            _mapper = mapper;
            _repository = repository;
            _profservice = profservice;
            _alumnoservice = alumnoservice;
            _estudianteservice = estudianteservice;
            _cursoservice = cursoservice;
        }



        #region  Peticiones GET

        [HttpGet]
        [Route("TodosLosProfesores")]
        public async Task<IActionResult> TodosLosMaestros()
        {
            var profes = await _repository.TodosLosProfesores();
            //var answerprofess = _mapper.Map<IEnumerable<Profesor>,IEnumerable<ProfesorResponses>>(profes);
            return Ok(profes);
        }

        [HttpGet]
        [Route("TodosLosEstudiantes")]
        public async Task<IActionResult> TodosLosEstudiantes()
        {
            var students = await _repository.TodosLosEstudiante();
            //var answerprofess = _mapper.Map<IEnumerable<Estudiante>,IEnumerable<EstudianteResponses>>(students);
            return Ok(students);
        }

        [HttpGet]
        [Route("TodosLosCursos")]
        public async Task<IActionResult> TodosLosCursos()
        {
            var cursos = await _repository.TodosLosCursos();
            return Ok(cursos);
        }

        [HttpGet]
        [Route("TodasLasInscripciones")]
        public async Task<IActionResult> TodasLasInscripciones()
        {
            var inscrip = await _repository.TodasLasInscripciones();
            return Ok(inscrip);
        }

        [HttpGet]
        [Route("Estudiante/{id:int}")]
        public async Task<IActionResult> EstudiantePorId(int id)
        {
            var estudiante = await _repository.EstudiantePorId(id);

            if(estudiante==null)
            {
                return NotFound("Lo sentimos, el estudiante que desea consultar no existe.");
            }

            return Ok(estudiante);
        }

        [HttpGet]
        [Route("Profesor/{id:int}")]
        public async Task<IActionResult> ProfesorPorId(int id)
        {
            var profesor = await _repository.ProfesorPorId(id);

            if(profesor == null)
            {
                return NotFound("Lo sentimos, el profesor que desea consultar no existe.");

            }
            return Ok(profesor);
        }

        [HttpGet]
        [Route("Curso/{id:int}")]
        public async Task<IActionResult> CursoPorId(int id)
        {
            var curso = await _repository.CursoPorId(id);

            if(curso == null)
            {
                return NotFound("Lo sentimos, el curso que desea consultar no existe.");

            }
            return Ok(curso);
        }

        [HttpGet]
        [Route("Inscripcion/{id:int}")]
        public async Task<IActionResult> InscripcionPorId(int id)
        {
            var inscripcion = await _repository.InscripcionPorId(id);

            if(inscripcion==null)
            {
                return NotFound("Lo sentimos, la inscripción que desea buscar no existe.");
            }
            return Ok(inscripcion);
        }

        [HttpGet]
        [Route("LoginAdmin/{username}/{clave}")]
        public async Task<IActionResult> LoginAdmi(string username, string clave)
        {
            var administrador = await _repository.LoginAdmin(username, clave);
            return Ok(administrador);
        }
        #endregion

        #region Peticiones POST

        [HttpPost]
        [Route("Registar/Profesor")]
        public async Task<IActionResult> RegistrarProfesor(ProfesorRequest profesor)
        {
            var entity = _mapper.Map<ProfesorRequest, Profesor>(profesor);

            var profe = await _repository.RegistrarProfesor(entity);

            return Ok(profesor);
        }

        [HttpPost]
        [Route("Registrar/Estudiante")]
        public async Task<IActionResult> RegistrarEstudiante(AlumnoRequest alumno)
        {
            var entity = _mapper.Map<AlumnoRequest, Estudiante>(alumno);

            var id = await _repository.RegistrarEstudiante(entity);
            
            if(id <= 0)
                return Conflict($"¡ERROR!: Ocurrio un conflicto con la información...Intentelo nuevamente.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Estudiante/{id}";
            return Ok(alumno);
        }

        [HttpPost]
        [Route("Registrar/Curso")]
        public async Task<IActionResult> RegistrarCurso(CursoRequests curso)
        {
            var entity = _mapper.Map<CursoRequests, Curso>(curso);

            var id = await _repository.RegistrarCurso(entity);
            
            if(id <= 0)
                return Conflict($"¡ERROR!: Ocurrio un conflicto con la información...Intentelo nuevamente.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Profesor/Curso/{id}";
            return Ok(curso);
        }

        [HttpPost]
        [Route("Registrar/Inscripcion")]
        public async Task<IActionResult> RegistrarInscripcion(InscripcionRequest inscripcion)
        {
            var entity = _mapper.Map<InscripcionRequest, Inscripcion>(inscripcion);

            var id = await _repository.InscripcionAcurso(entity);
            
            if(id <= 0)
                return Conflict($"¡ERROR!: Ocurrio un conflicto con la información...Intentelo nuevamente.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/Estudiante/{id}";
            return Ok(inscripcion);
        }

        #endregion

        #region Peticiones PUT
        
        [HttpPut]
        [Route("Actualizar/Profesor/{id:int}")]
        public async Task<IActionResult> ActualizarProfesor(int id,[FromBody]Profesor profesor)
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

        [HttpPut]
        [Route("Actualizar/Estudiante/{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]Estudiante estudiante)
        {
            if(id <= 0)
                return NotFound("No se encontro su cuenta");
            
            estudiante.IdEstudiante = id;



            var updated = await _repository.Update(id, estudiante);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar su información.");
            
            return Ok(estudiante);
        }

        [HttpPut]
        [Route("Actualizar/Curso/{id:int}")]
        public async Task<IActionResult> UpdateCurso (int id,[FromBody]Curso curso)
        {
            if(id <= 0)
                return NotFound("No se encontro el curso");
            
            curso.IdCurso = id;

            var Validated = _cursoservice.ActualizarCurso_Validated(curso);

            if(!Validated)
                UnprocessableEntity("No es posible actualizar la informacion.");

            var updated = await _repository.UpdateCurso(id, curso);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar el curso.");
            
            return Ok(curso);
        }

        [HttpPut]
        [Route("Actualizar/Inscripcion/{id:int}")]
        public async Task<IActionResult> UpdateInscripcion (int id,[FromBody]Inscripcion inscripcion)
        {
            if(id <= 0)
                return NotFound("No se encontro la inscripcion");
            inscripcion.IdInscripcion = id;

            var updated = await _repository.UpdateInscripcion(id, inscripcion);

            return Ok(inscripcion);
        }
        #endregion

        #region Peticiones DELETE
        
        [HttpDelete]
        [Route("Eliminar/Profesor/{id:int}")]
        public IActionResult EliminarProfesor(int id)
        {
            _repository.EliminarProfesor(id);

            var MessageResult = "Se ha eliminado al profesor correctamente.";

            return Ok(MessageResult);
        }

        [HttpDelete]
        [Route("Eliminar/Estudiante/{id:int}")]
        public IActionResult EliminarEstudiante(int id)
        {
            _repository.EliminarEstudiante(id);

            var MessageResult = "Se ha eliminado al estudiante correctamente.";

            return Ok(MessageResult);
        }

        [HttpDelete]
        [Route("Eliminar/Curso/{id:int}")]
        public IActionResult EliminarCurso(int id)
        {
            _repository.EliminarCurso(id);

            var MessageResult = "Se ha eliminado el curso correctamente.";

            return Ok(MessageResult);
        }

        [HttpDelete]
        [Route("Eliminar/Inscripcion/{id:int}")]
        public IActionResult EliminarInscripcion(int id)
        {
            _repository.EliminarInscripcion(id);

            var MessageResult = "Se ha eliminado la inscripcion correctamente.";

            return Ok(MessageResult);
        }
        #endregion

    }
}