using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class ImagenDTO
    {
        public Int64 imagenID { get; set; }
        public DateTime fecha_informe { get; set; }
        public string descripcion { get; set; }
        public string diagnostico { get; set; }
        public Int64 ingresoID { get; set; }
        public Int64 pacienteID { get; set; }
    }
}