using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class TratamientoDTO
    {
        public Int64 tratamientoID { get; set; }
        public string descripcion { get; set; }
        public Int64 egresoID { get; set; }
        public Int64 pacienteID { get; set; }

        public Int64 ingresoID { get; set; }

        public TratamientoDTO()
        {

        }
    }
}