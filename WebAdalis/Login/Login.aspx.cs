using HospOnline.DTO;
using HospOnline.NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospOnline.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.Attributes.Add("placeholder", "Rut del Paciente...");
            txtPassword.Attributes.Add("placeholder", "Contraseña...");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            PacienteNEG pacienteNEG = new PacienteNEG();
            PacienteDTO pacienteDTO = new PacienteDTO();
            PacienteDTO retornoDTO = new PacienteDTO();

            pacienteDTO.rut = txtUsuario.Text;
            pacienteDTO.clave = txtPassword.Text;

            retornoDTO = pacienteNEG.buscarPorRut(pacienteDTO);

            if (retornoDTO != null)
            {
                Session["Administracion"] = "NO";
                
                Session["pacienteDTO"] = retornoDTO;

                IngresoDTO ingresoDTO = new IngresoDTO();
                IngresoNEG ingresoNEG = new IngresoNEG();

                ingresoDTO.pacienteID = retornoDTO.pacienteID;

                ingresoDTO = ingresoNEG.readxPaciente(ingresoDTO);

                if (ingresoDTO != null)
                {
                    if (retornoDTO.rut == txtUsuario.Text && retornoDTO.clave == txtPassword.Text)
                    {
                        Session["ingresoDTO"] = ingresoDTO;

                        Response.Redirect("../Main/Home.aspx");
                    }
                    else
                    {
                        lblAdvertencia.Text = "Usuario y Contraseña incorrectas";
                    }

                }
                else
                {
                    lblAdvertencia.Text = "Usuario y Contraseña incorrectas";
                }

            }
        }
    }
}