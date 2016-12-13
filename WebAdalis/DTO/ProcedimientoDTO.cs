using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class ProcedimientoDTO
    {
        public Int64 procedimientoID { get; set; }
        public string nombre { get; set; }
        public string cantidad { get; set; }
        public string periodo { get; set; }
        public DateTime fecha_inicio_procedimiento { get; set; }
        public Int64 ingresoID { get; set; }

        public ProcedimientoDTO()
        {

        }
    }
}