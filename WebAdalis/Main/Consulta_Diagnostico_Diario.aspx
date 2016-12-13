<%@ Page Language="C#" MasterPageFile="~/Main/Admin.Master" AutoEventWireup="true" CodeBehind="Consulta_Diagnostico_Diario.aspx.cs" Inherits="HospOnline.Main.Consulta_Diagnostico_Diario" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <section class="content">
        <div class="row">

            <div class="col-md-10">
                <div class="box box-warning">
                    <div class="box-header with-border">
                        <h3 class="box-title">Datos del Paciente</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>

                            </button>
                        </div>
                    </div>
                    <div class="box-body" style="display: block;">
                        <div class="box box-primary">
                            
                                <div class="box-body">
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputRut">Rut:</label>
                                            <asp:Label runat="server" ID="lblRut" Text="18.773.312-K" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputNombre">Nombre:</label>
                                            <asp:Label runat="server" ID="lblNombre" Text="Reinier Utreras Lara" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputEdad">Edad:</label>
                                            <asp:Label runat="server" ID="lblEdad" Text="21" />
                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputEstado">Estado:</label>
                                            <asp:Label runat="server" ID="lblEstado" Text="Evaluando" />
                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputEnfermedad">Enfermedad:</label>
                                            <asp:Label runat="server" ID="lblEnfermedad" Text="Fractura Expuesta" />
                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputFechaIngreso">F. Ingreso:</label>
                                            <asp:Label runat="server" ID="lblFechaIngreso" Text="26/11/2015" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputFechaIngreso">Hora de Ingreso:</label>
                                            <asp:Label runat="server" ID="lblHoraIngreso" Text="12:30" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputFechaIngreso">F. Egreso:</label>
                                            <asp:Label runat="server" ID="lblFechaEgreso" Text="" />
                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputUnidad">Unidad:</label>
                                            <asp:Label runat="server" ID="lblUnidad" Text="Traumatologia" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputSala">Nº Sala:</label>
                                            <asp:Label runat="server" ID="lblSala" Text="1" />
                                        </div>
                                    </div>
                                    <div class="col-xs-10">
                                        <div class="form-group">
                                            <label for="InputCama">Nº Cama:</label>
                                            <asp:Label runat="server" ID="lblCama" Text="10" />
                                        </div>
                                    </div>
                                    <div class="col-xs-10">
                                        <div class="form-group">
                                            <label for="InputDescripcion">Descripción:</label>
                                            <asp:Label runat="server" ID="lblDescripcion" Text="" />
                                        </div>
                                    </div>
                                </div>
                            
                        </div>
                        <b>Doctor:</b> <asp:Label runat="server" id="lblDoctor" Text="Alberto Lorca"></asp:Label> 
                        <br />
                        <asp:LinkButton ID="lkDescargarPDF" runat="server" OnClick="lkDescargarPDF_Click" Text="Descargar PDF" ></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-10">
                <div class="box box-warning collapsed-box">
                    <div class="box-header with-border">
                        <h3 class="box-title">Diagnóstico Diario</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-plus"></i>

                            </button>
                        </div>
                    </div>
                    <div class="box-body" style="display: none;">
                        <asp:GridView AutoGenerateColumns="false" runat="server" ID="gvDiagonosticoDiario" CssClass="table table-bordered table-hover dataTable" EmptyDataText="No existen diagnosticos diarios." ShowHeader="true" Visible="true" >
                            <Columns>
                                <asp:BoundField DataField="descripcion" HeaderText="Diagnóstico"  />
                                <asp:BoundField DataField="fecha_diagnostico" HeaderText="Fecha Diagnóstico" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>