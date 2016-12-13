using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class PersonalDTO
    {
        public Int64 personalID { get; set; }
        public Int64 personaID { get; set; }
        public PersonaDTO persona { get; set; }
        public Int64 cargoID { get; set; }
        public Int64 unidadID { get; set; }
        public string clave { get; set; }
        
        //Campos solo para login no crear en base de datos
        public string rut { get; set; }
        public PersonalDTO()
        {

        }
    }
}