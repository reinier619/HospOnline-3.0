using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class EgresoDTO
    {
        public Int64 egresoID { get; set; }
        public DateTime fecha_egreso { get; set; }
        public string descripcion { get; set; }
        public Int64 ingresoID { get; set; }

        public EgresoDTO()
        {

        }
    }
}