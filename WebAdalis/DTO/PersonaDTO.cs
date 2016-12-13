using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class PersonaDTO
    {
        public Int64 personaID { get; set; }
        public string rut { get; set; }
        public string digito_verificador { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public PersonaDTO()
        {

        }
    }
}