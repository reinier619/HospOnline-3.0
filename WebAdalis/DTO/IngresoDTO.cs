using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class IngresoDTO
    {
        public Int64 ingresoID { get; set; }
        public string estado { get; set; }
        public string enfermedad { get; set; }
        public Int64 unidadID { get; set; }
        public UnidadDTO unidad { get; set; }
        public Int64 salaID { get; set; }
        public SalaDTO sala { get; set; }
        public Int64 camaID { get; set; }
        public CamaDTO cama { get; set; }
        public string descripcion { get; set; }
        public Int64 pacienteID { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string hora_ingreso { get; set; }

        public IngresoDTO()
        {

        }
    }
}