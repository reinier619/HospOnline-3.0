using HospOnline.DTO;
using HospOnline.NEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospOnline.Main
{
    public partial class Ingreso_Tratamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBuscar.Attributes.Add("placeholder", "Rut del Paciente...");
        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoDTO ingresoDTO = (IngresoDTO)Session["ingreso_ADM_DTO"];
            PacienteDTO pacienteDTO = (PacienteDTO)Session["paciente_ADM_DTO"];

            TratamientoNEG tratamientoNEG = new TratamientoNEG();
            TratamientoDTO tratamientoDTOIN = new TratamientoDTO();
            int retorno = 0;

            tratamientoDTOIN.descripcion = txtNombreTratamiento.Text;
            tratamientoDTOIN.ingresoID = ingresoDTO.ingresoID;
            tratamientoDTOIN.pacienteID = pacienteDTO.pacienteID;
            
            retorno = tratamientoNEG.create(tratamientoDTOIN);

            if (retorno == 1)
            {
                //Mensaje OK
                divok.Visible = true;
            }
            else
            {
                //Mensaje OK
                diverror.Visible = true;
            }



        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PacienteDTO pacienteDTOIN = new PacienteDTO();
            PacienteDTO pacienteDTOOUT = new PacienteDTO();
            
            PacienteNEG pacienteNEG = new PacienteNEG();

            pacienteDTOIN.rut = txtBuscar.Text;

            pacienteDTOOUT = pacienteNEG.BuscarPacienteRut(pacienteDTOIN);

            if (pacienteDTOOUT != null)
            {

                Session["paciente_ADM_DTO"] = pacienteDTOOUT;

                IngresoDTO ingresoDTO = new IngresoDTO();
                IngresoNEG ingresoNEG = new IngresoNEG();

                ingresoDTO.pacienteID = pacienteDTOOUT.pacienteID;

                ingresoDTO = ingresoNEG.readxPaciente(ingresoDTO);

                if (ingresoDTO != null)
                {

                    Session["ingreso_ADM_DTO"] = ingresoDTO;

                    cargardatospaciente();
                }

            }




        }

        public void cargardatospaciente()
        {
            IngresoDTO ingresoDTO = (IngresoDTO)Session["ingreso_ADM_DTO"];
            PacienteDTO pacienteDTO = (PacienteDTO)Session["paciente_ADM_DTO"];

            lblRut.Text = pacienteDTO.rut + "-" + pacienteDTO.digito_verificador;
            lblNombre.Text = pacienteDTO.nombre + " " + pacienteDTO.apellido_paterno + " " + pacienteDTO.apellido_materno;
            lblEdad.Text = pacienteDTO.edad;
            lblEstado.Text = ingresoDTO.estado;
            lblEnfermedad.Text = ingresoDTO.enfermedad;
            lblFechaIngreso.Text = pacienteDTO.fecha_registro.ToString("dd/MM/yyyy");
            lblHoraIngreso.Text = ingresoDTO.hora_ingreso;
            lblUnidad.Text = ingresoDTO.unidad.nombre;
            lblSala.Text = ingresoDTO.sala.numero;
            lblCama.Text = ingresoDTO.cama.descripcion;

            PersonalNEG personalNEG = new PersonalNEG();
            PersonalDTO personalDTOIN = new PersonalDTO();
            PersonalDTO personalDTOOUT = new PersonalDTO();

            personalDTOIN.unidadID = ingresoDTO.unidadID;
            personalDTOOUT = personalNEG.readxUnidad(personalDTOIN);

            PersonaDTO personaDTOIN = new PersonaDTO();
            PersonaDTO personaDTOOUT = new PersonaDTO();

            PersonaNEG personaNEG = new PersonaNEG();
            personaDTOIN.personaID = personalDTOOUT.personaID;
            personaDTOOUT = personaNEG.read(personaDTOIN);
            lblDoctor.Text = personaDTOOUT.nombre + " " + personaDTOOUT.apellido_paterno + " " + personaDTOOUT.apellido_materno;

        }
    }
}