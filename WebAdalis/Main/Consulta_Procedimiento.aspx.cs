using HospOnline.DTO;
using HospOnline.NEG;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospOnline.Main
{
    public partial class Consulta_Procedimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargardatospaciente();

            IngresoDTO ingresoDTO = (IngresoDTO)Session["ingresoDTO"];
            PacienteDTO pacienteDTO = (PacienteDTO)Session["pacienteDTO"];
            
            List<ProcedimientoDTO> listProcedimientoDTO = new List<ProcedimientoDTO>();
            ProcedimientoNEG procedimientoNEG = new ProcedimientoNEG();
            ProcedimientoDTO procedimientoDTOIN = new ProcedimientoDTO();

            procedimientoDTOIN.ingresoID = ingresoDTO.ingresoID;

            listProcedimientoDTO = procedimientoNEG.readxIngreso(procedimientoDTOIN);

            gvProcedimientos.DataSource = listProcedimientoDTO;
            gvProcedimientos.DataBind();


        }

        public void cargardatospaciente()
        {
            IngresoDTO ingresoDTO = (IngresoDTO)Session["ingresoDTO"];
            PacienteDTO pacienteDTO = (PacienteDTO)Session["pacienteDTO"];

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

        public void descargarPDF()
        {
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document(PageSize.A4, 50, 50, 15, 15))
                {
                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    string imageURL = Server.MapPath(".") + "/pdf/hospital.gif";

                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                    jpg.ScaleToFit(140f, 120f);
                    jpg.SpacingBefore = 10f;

                    jpg.SpacingAfter = 1f;
                    jpg.Alignment = Element.ALIGN_LEFT;


                    /****************Paciente - Titulo*******************/
                    PdfPTable tableTitulo = new PdfPTable(1);
                    tableTitulo.DefaultCell.Border = 0;
                    tableTitulo.WidthPercentage = 100;

                    PdfPCell cellTitulo = new PdfPCell();
                    cellTitulo.VerticalAlignment = Element.ALIGN_LEFT;
                    cellTitulo.Colspan = 1;
                    cellTitulo.Border = 0;
                    cellTitulo.AddElement(new Paragraph("Datos del Paciente : "));
                    tableTitulo.AddCell(cellTitulo);
                    /**********************************************************/

                    /****************Paciente - Rut - Nombre*******************/

                    PdfPTable tablePaciente = new PdfPTable(2);
                    tablePaciente.DefaultCell.Border = 0;
                    tablePaciente.WidthPercentage = 100;


                    PdfPCell cellRut = new PdfPCell();
                    cellRut.VerticalAlignment = Element.ALIGN_LEFT;
                    cellRut.Colspan = 1;
                    cellRut.Border = 0;
                    cellRut.AddElement(new Paragraph("Rut: " + lblRut.Text));

                    PdfPCell cellNombre = new PdfPCell();
                    cellNombre.Colspan = 1;
                    cellNombre.Border = 0;
                    cellNombre.VerticalAlignment = Element.ALIGN_CENTER;
                    cellNombre.AddElement(new Paragraph("Nombre : " + lblNombre.Text));

                    tablePaciente.AddCell(cellRut);
                    tablePaciente.AddCell(cellNombre);

                    /*********************************************************/

                    /****************Paciente Edad - Estado*******************/
                    PdfPTable tableEdad = new PdfPTable(2);
                    tableEdad.DefaultCell.Border = 0;
                    tableEdad.WidthPercentage = 100;

                    PdfPCell cellEdad = new PdfPCell();
                    cellEdad.Colspan = 1;
                    cellEdad.Border = 0;
                    cellEdad.VerticalAlignment = Element.ALIGN_LEFT;
                    cellEdad.AddElement(new Paragraph("Edad: " + lblEdad.Text));

                    PdfPCell cellEstado = new PdfPCell();
                    cellEstado.Colspan = 1;
                    cellEstado.Border = 0;
                    cellEstado.VerticalAlignment = Element.ALIGN_CENTER;
                    cellEstado.AddElement(new Paragraph("Estado: " + lblEstado.Text));

                    tableEdad.AddCell(cellEdad);
                    tableEdad.AddCell(cellEstado);

                    /**********************************/

                    /****************Paciente Enfermedad - Fecha Ingreso*******************/
                    PdfPTable tableEnfermedad = new PdfPTable(2);
                    tableEnfermedad.DefaultCell.Border = 0;
                    tableEnfermedad.WidthPercentage = 100;

                    PdfPCell cellEnfermedad = new PdfPCell();
                    cellEnfermedad.Colspan = 1;
                    cellEnfermedad.Border = 0;
                    cellEnfermedad.VerticalAlignment = Element.ALIGN_LEFT;
                    cellEnfermedad.AddElement(new Paragraph("Enfermedad: " + lblEnfermedad.Text));

                    PdfPCell cellFechaIngreso = new PdfPCell();
                    cellFechaIngreso.Colspan = 1;
                    cellFechaIngreso.Border = 0;
                    cellFechaIngreso.VerticalAlignment = Element.ALIGN_CENTER;
                    cellFechaIngreso.AddElement(new Paragraph("Fecha Ingreso: " + lblFechaIngreso.Text));

                    tableEnfermedad.AddCell(cellEnfermedad);
                    tableEnfermedad.AddCell(cellFechaIngreso);

                    /**********************************/

                    /****************Paciente Hora Ingreso - Fecha Egreso*******************/
                    PdfPTable tableHoraIngreso = new PdfPTable(2);
                    tableHoraIngreso.DefaultCell.Border = 0;
                    tableHoraIngreso.WidthPercentage = 100;

                    PdfPCell cellHoraIngreso = new PdfPCell();
                    cellHoraIngreso.Colspan = 1;
                    cellHoraIngreso.Border = 0;
                    cellHoraIngreso.VerticalAlignment = Element.ALIGN_LEFT;
                    cellHoraIngreso.AddElement(new Paragraph("Hora de Ingreso: " + lblHoraIngreso.Text));

                    PdfPCell cellFechaEgreso = new PdfPCell();
                    cellFechaEgreso.Colspan = 1;
                    cellFechaEgreso.Border = 0;
                    cellFechaEgreso.VerticalAlignment = Element.ALIGN_CENTER;
                    cellFechaEgreso.AddElement(new Paragraph("Fecha Egreso: " + lblFechaEgreso.Text));

                    tableHoraIngreso.AddCell(cellHoraIngreso);
                    tableHoraIngreso.AddCell(cellFechaEgreso);

                    /**********************************/

                    /****************Paciente Hora Ingreso - Fecha Egreso*******************/
                    PdfPTable tableUnidad = new PdfPTable(2);
                    tableUnidad.DefaultCell.Border = 0;
                    tableUnidad.WidthPercentage = 100;

                    PdfPCell cellUnidad = new PdfPCell();
                    cellUnidad.Colspan = 1;
                    cellUnidad.Border = 0;
                    cellUnidad.VerticalAlignment = Element.ALIGN_LEFT;
                    cellUnidad.AddElement(new Paragraph("Unidad: " + lblHoraIngreso.Text));

                    PdfPCell cellNSala = new PdfPCell();
                    cellNSala.Colspan = 1;
                    cellNSala.Border = 0;
                    cellNSala.VerticalAlignment = Element.ALIGN_CENTER;
                    cellNSala.AddElement(new Paragraph("Sala: " + lblFechaEgreso.Text));

                    tableUnidad.AddCell(cellUnidad);
                    tableUnidad.AddCell(cellNSala);

                    /**********************************/

                    /****************Paciente Hora Ingreso - Fecha Egreso*******************/
                    PdfPTable tableCama = new PdfPTable(1);
                    tableCama.DefaultCell.Border = 0;
                    tableCama.WidthPercentage = 100;

                    PdfPCell cellCama = new PdfPCell();
                    cellCama.Colspan = 1;
                    cellCama.Border = 0;
                    cellCama.VerticalAlignment = Element.ALIGN_LEFT;
                    cellCama.AddElement(new Paragraph("Nº Cama: " + lblCama.Text));


                    tableCama.AddCell(cellCama);

                    /**********************************/

                    /****************Paciente Descripcion*******************/
                    PdfPTable tableDescripcion = new PdfPTable(1);
                    tableDescripcion.DefaultCell.Border = 0;
                    tableDescripcion.WidthPercentage = 100;

                    PdfPCell cellDescripcion = new PdfPCell();
                    cellDescripcion.Colspan = 1;
                    cellDescripcion.Border = 0;
                    cellDescripcion.VerticalAlignment = Element.ALIGN_LEFT;
                    cellDescripcion.AddElement(new Paragraph("Descripción: " + lblDescripcion.Text));


                    tableDescripcion.AddCell(cellDescripcion);

                    /**********************************/

                    /****************Paciente Doctor*******************/
                    PdfPTable tableDoctor = new PdfPTable(1);
                    tableDoctor.DefaultCell.Border = 0;
                    tableDoctor.WidthPercentage = 100;

                    PdfPCell cellDoctor = new PdfPCell();
                    cellDoctor.Colspan = 1;
                    cellDoctor.Border = 0;
                    cellDoctor.VerticalAlignment = Element.ALIGN_LEFT;
                    cellDoctor.AddElement(new Paragraph("Doctor: " + lblDoctor.Text));


                    tableDoctor.AddCell(cellDoctor);

                    /**********************************/
                    doc.Add(jpg);
                    doc.Add(tableTitulo);
                    doc.Add(tablePaciente);
                    doc.Add(tableEdad);
                    doc.Add(tableEnfermedad);
                    doc.Add(tableHoraIngreso);
                    doc.Add(tableUnidad);
                    doc.Add(tableCama);
                    doc.Add(tableDescripcion);

                    Paragraph saltoDeLinea = new Paragraph("                                                   ");
                    doc.Add(saltoDeLinea);

                    doc.Add(tableDoctor);

                    doc.Add(saltoDeLinea);

                    Paragraph TituloMedicamentos = new Paragraph("Medicamentos Suministrados");
                    doc.Add(TituloMedicamentos);

                    doc.Add(saltoDeLinea);

                    /*****************Tabla de Examenes*****************/
                    PdfPTable tableDetalle = null;
                    tableDetalle = new PdfPTable(2);
                    tableDetalle.DefaultCell.Border = 0;
                    tableDetalle.WidthPercentage = 100;

                    PdfPTable tableTituloDetalle = null;
                    tableTituloDetalle = new PdfPTable(2);
                    tableTituloDetalle.DefaultCell.Border = 0;
                    tableTituloDetalle.WidthPercentage = 100;

                    PdfPCell cellNombreProc = null;
                    PdfPCell fechaInicio = null;

                    PdfPCell TituloNombreProc = null;
                    PdfPCell TituloFechaInicio = null;

                    TituloNombreProc = new PdfPCell();
                    TituloNombreProc.Colspan = 1;
                    TituloNombreProc.VerticalAlignment = Element.ALIGN_CENTER;
                    TituloNombreProc.AddElement(new Paragraph("Nombre"));
                    TituloNombreProc.BackgroundColor = BaseColor.GRAY;

                    tableTituloDetalle.AddCell(TituloNombreProc);

                    TituloFechaInicio = new PdfPCell();
                    TituloFechaInicio.Colspan = 1;
                    TituloFechaInicio.VerticalAlignment = Element.ALIGN_CENTER;
                    TituloFechaInicio.AddElement(new Paragraph("Fecha Inicio Proc."));
                    TituloFechaInicio.BackgroundColor = BaseColor.GRAY;

                    tableTituloDetalle.AddCell(TituloFechaInicio);

                    doc.Add(tableTituloDetalle);

                    Int64 cantidadExamenes = gvProcedimientos.Rows.Count;

                    if (cantidadExamenes > 0)
                    {
                        foreach (GridViewRow row in gvProcedimientos.Rows)
                        {

                            cellNombreProc = new PdfPCell();
                            cellNombreProc.Colspan = 1;
                            cellNombreProc.VerticalAlignment = Element.ALIGN_CENTER;
                            cellNombreProc.AddElement(new Paragraph(row.Cells[0].Text));
                            tableDetalle.AddCell(cellNombreProc);

                            fechaInicio = new PdfPCell();
                            fechaInicio.Colspan = 1;
                            fechaInicio.VerticalAlignment = Element.ALIGN_CENTER;
                            fechaInicio.AddElement(new Paragraph(row.Cells[1].Text));
                            tableDetalle.AddCell(fechaInicio);

                        }
                    }
                    else
                    {
                        cellNombreProc = new PdfPCell();
                        cellNombreProc.Colspan = 2;
                        cellNombreProc.VerticalAlignment = Element.ALIGN_CENTER;
                        cellNombreProc.AddElement(new Paragraph("No existen datos registrados."));
                        tableDetalle.AddCell(cellNombreProc);
                    }

                    doc.Add(tableDetalle);

                    /*******************************************************************/

                    doc.Close();
                }
                Response.Clear();
                //Response.ContentType = "application/pdf";
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= Informe.pdf");
                Response.Buffer = true;
                Response.Clear();
                var bytes = ms.ToArray();
                Response.OutputStream.Write(bytes, 0, bytes.Length);
                Response.OutputStream.Flush();
            }


        }

        protected void lkDescargarPDF_Click(object sender, EventArgs e)
        {
            descargarPDF();
        }    
    
    }
}