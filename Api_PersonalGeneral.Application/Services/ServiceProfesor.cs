//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;
using Api_PersonalGeneral.Domain.Interfaces;

namespace Api_PersonalGeneral.Application.Services
{
    public class ServiceProfesor : IPorfesorService
    {
        public bool ProfesorValidated(Profesor profesor)
        {
            if(string.IsNullOrEmpty(profesor.NombreCompleto))
                return false;
            if(string.IsNullOrEmpty(profesor.Correo))
                return false;
            if(string.IsNullOrEmpty(profesor.Clave))
                return false;
            if(string.IsNullOrEmpty(profesor.RedesSociales))
                return false;
            if(string.IsNullOrEmpty(profesor.Descripcion))
                return false;
            
            if(profesor.IdProfesor <= 0)
                return false;

            return true;
        }

        public bool ActualizarProfesor_Validated(Profesor profesor)
        {
            if(string.IsNullOrEmpty(profesor.NombreCompleto))
                return false;
            if(string.IsNullOrEmpty(profesor.Correo))
                return false;
            if(string.IsNullOrEmpty(profesor.Clave))
                return false;
            if(string.IsNullOrEmpty(profesor.RedesSociales))
                return false;
            if(string.IsNullOrEmpty(profesor.Descripcion))
                return false;
            
            if(profesor.IdProfesor <= 0)
                return false;

            return true;
        }
    }
}