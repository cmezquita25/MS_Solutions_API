using System;
using System.Collections.Generic;

#nullable disable

namespace Api_PersonalGeneral.Domain.Entities
{
    public partial class Admin
    {
        public Admin()
        {
            
        }
        public int IdAdmin { get; set; }
        public string UserName { get; set; }
        public string Clave { get; set; }
    }
}
