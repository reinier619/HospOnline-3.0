using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class FormulaMedicamentoDTO
    {
        public Int64 formulamedicamentoID { get; set; }
        public string medicamento { get; set; }
        public string cantidad { get; set; }
        public string medida { get; set; }
        public string unidad_medida { get; set; }
        public Int64 ingresoID { get; set; }


        public FormulaMedicamentoDTO()
        {

        }
    }
}