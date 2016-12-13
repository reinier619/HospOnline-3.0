using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class ExamenDTO
    {
        public Int64 examenID { get; set; }
        public string nombre_examen { get; set; }
        public DateTime fecha_examen { get; set; }
        public string resultado { get; set; }
        public Int64 ingresoID { get; set; }

        public ExamenDTO()
        {

        }
    }
}