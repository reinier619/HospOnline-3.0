<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospOnline.LoginADM.Login"%>

<!DOCTYPE html>
<html lang="en">
	<head>
		<meta http-equiv="content-type" content="text/html; charset=UTF-8">
		<meta charset="utf-8">
		<title>Sistema de Hospitalización</title>
		<meta name="generator" content="Bootply" />
		<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
		<link href="css/bootstrap.min.css" rel="stylesheet">
		<!--[if lt IE 9]>
			<script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<![endif]-->
		<link href="css/styles.css" rel="stylesheet">
	</head>
	<body>
        <br />
        <br />
        <br />
<!--login modal-->
<div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
  <div class="modal-content">

      <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
          <h3 class="text-center">Sistema Registro Hospitalización</h3>
          <h3 class="text-left">Login</h3>
      </div>
      <div class="modal-body">
          <form class="form col-md-12 center-block" runat="server" id="frmIngreso">
            <div class="form-group">
              <asp:TextBox ID="txtRut" runat="server" CssClass="form-control input-lg"></asp:TextBox> 
            </div>
            <div class="form-group">
                <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" CssClass="form-control input-lg"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnIngresar_Click1"   />
              
            </div>
          </form>
      </div>
      <div class="modal-footer">
          <div class="col-md-12">

		  </div>	
      </div>
  </div>
  </div>
</div>
	<!-- script references -->
		<script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
		<script src="js/bootstrap.min.js"></script>
	</body>
</html>
