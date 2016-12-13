using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class PacienteDTO
    {
        public Int64 pacienteID { get; set; }
        public string rut { get; set; }
        public string digito_verificador { get; set; }
        public string nombre{ get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string edad { get; set; }
        public DateTime fecha_registro { get; set; }
        public string hora_ingreso { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public string clave { get; set; }

        public PacienteDTO()
        {

        }
    }
}