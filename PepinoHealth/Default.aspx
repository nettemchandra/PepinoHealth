<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PepinoHealth._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="container login-form">
	<h2 class="login-title"> Login </h2>
	<div class="panel panel-default">
		<div class="panel-body">
			<form>
				<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
				<div class="input-group login-userinput">
					<span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
					<asp:TextBox ID="txtUser" runat="server" type="text" class="form-control" name="username" placeholder="Username"></asp:TextBox>
				</div>
				<div class="input-group">
					<span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
					<asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control" name="password" placeholder="Password"></asp:TextBox>
					<span id="showPassword" class="input-group-btn">
            <button class="btn btn-default reveal" type="button"><i class="glyphicon glyphicon-eye-open"></i></button>
          </span>  
				</div>
				<asp:Button onclick="btnLogin_Click" ID="btnLogin" class="btn btn-primary btn-block login-button" runat="server" Text="Login"/>
				
				<div class="checkbox login-options">
					<%--<label><input type="checkbox"/> Remember Me</label>--%>
					<a href="#" class="login-forgot">Forgot Username/Password?</a>
				</div>		
			</form>			
		</div>
	</div>
</div>

</asp:Content>
