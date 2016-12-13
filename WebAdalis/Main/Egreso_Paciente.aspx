<%@ Page Language="C#"  MasterPageFile="~/Main/Admin.Master" AutoEventWireup="true" CodeBehind="Egreso_Paciente.aspx.cs" Inherits="HospOnline.Main.Egreso_Paciente" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <section class="content">
        <div class="row">
             <div class="col-md-10">
                <div class="col-xs-7">
                    <div class="form-group">
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-3">
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-block btn-primary" Text="Buscar" OnClick="btnBuscar_Click" /> 
                    </div>
                </div>

             </div>
        </div>
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
                                            <asp:Label runat="server" ID="lblRut" Text="" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputNombre">Nombre:</label>
                                            <asp:Label runat="server" ID="lblNombre" Text="" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputEdad">Edad:</label>
                                            <asp:Label runat="server" ID="lblEdad" Text="" />
                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputEstado">Estado:</label>
                                            <asp:Label runat="server" ID="lblEstado" Text="" />
                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputEnfermedad">Enfermedad:</label>
                                            <asp:Label runat="server" ID="lblEnfermedad" ></asp:Label>

                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputFechaIngreso">F. Ingreso:</label>
                                            <asp:Label runat="server" ID="lblFechaIngreso" Text="" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputFechaIngreso">Hora de Ingreso:</label>
                                            <asp:Label runat="server" ID="lblHoraIngreso" Text="" />
                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputFechaIngreso">F. Egreso:</label>
                                            <br />
                                            <asp:TextBox runat="server" ID="TextFechaEgreso"/>
                                        </div>
                                    </div>

                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputUnidad">Unidad:</label>
                                            <asp:Label ID="lblUnidad" runat="server" > </asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-xs-5">
                                        <div class="form-group">
                                            <label for="InputSala">Nº Sala:</label>
                                            <asp:Label ID="lblSala" runat="server" Width="30%" ></asp:Label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-xs-10">
                                        <div class="form-group">
                                            <label for="InputCama">Nº Cama:</label>
                                            <asp:Label ID="lblCama" runat="server" Width="15%" ></asp:Label>
                                            
                                        </div>
                                    </div>
                                    <div class="col-xs-10">
                                        <div class="form-group">
                                            <label for="InputDescripcion">Descripción:</label>
                                            <asp:Label runat="server" ID="lblDescripcion"  Width="100%" Height="100%"></asp:Label>
                                           
                                        </div>
                                    </div>
                                    <div class="col-xs-10">
                                        <div class="form-group">
                                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-block btn-primary" Text="Guardar" Width="30%" OnClick="btnGuardar_Click" />
                                        </div>
                                    </div>
                                </div>
                            
                        </div>
                        <b>Doctor:</b> <asp:Label runat="server" id="lblDoctor" Text=""></asp:Label> 
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10">
               <div class="alert alert-success alert-dismissible" runat="server" id="divok" visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4><i class="icon fa fa-check"></i> Mensaje</h4>
                    Datos guardados correctamente.
              </div>
            <div class="alert alert-danger alert-dismissible"  runat="server" id="diverror"  visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-ban"></i> Error</h4>
                Error al momento de guardar los datos. Favor realizar nuevamente.
              </div>
            </div>
        </div>
    </section>
</asp:Content>
