using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class SalaDTO
    {
        public Int64 salaID { get; set; }
        public string descripcion { get; set; }
        public string numero { get; set; }
        public Int64 unidadID { get; set; }

        public SalaDTO()
        {

        }
    }
}