using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class DiagnosticoDTO
    {
        public Int64 diagnosticoID { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_diagnostico { get; set; }
        public Int64 ingresoID { get; set; }

        public DiagnosticoDTO()
        {

        }
    }
}