using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospOnline.DTO
{
    public class CamaDTO
    {
        public Int64 camaID { get; set; }
        public string descripcion { get; set; }
        public string numero { get; set; }
        public Int64 salaID { get; set; }

        public CamaDTO()
        {
        
        }
    }
}