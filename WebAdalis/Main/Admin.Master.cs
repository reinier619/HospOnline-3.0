using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospOnline.Main
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administracion"].ToString().Equals("NO"))
            {
                siderbarPublico.Visible = true;
                nombre_paciente.Text = "Paciente";
                //PacienteDTO pacienteDTO = (PacienteDTO)Session["pacienteDTO"];
                //nombre_paciente.Text = pacienteDTO.nombre + " " + pacienteDTO.apellido_paterno + " " + pacienteDTO.apellido_materno;

            }

            if (Session["Administracion"].ToString().Equals("SI"))
            {
                siderbarPersonal.Visible = true;
                nombre_paciente.Text = "Profesional";
                //nombre_paciente.Text = Session["usuario_adm"].ToString();
            }


        }


    }
}