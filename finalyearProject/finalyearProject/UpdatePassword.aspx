<%@ Page Title="" Language="C#" MasterPageFile="~/EmpMP.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="finalyearProject.UpdatePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    
<div class="container">
<br />

<h2>MEMBER UPDATE PASSWORD</h2>
<hr class="colorgraph">


			
			<div class="form-group">
				<asp:TextBox class="form-control input-lg" placeholder="Enter Old Password" 
                    tabindex="4" ID="txtOldPassword" runat="server" TextMode="Password" Width=50%></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Enter Old Password" ControlToValidate="txtOldPassword" 
                    CssClass="validation" ToolTip="Enter Old Password" ValidationGroup="a">Enter Old Password</asp:RequiredFieldValidator>

			</div>

			<div class="form-group">
				<asp:TextBox class="form-control input-lg" placeholder="Enter New Password" 
                    tabindex="4" ID="txtNewPassword" runat="server" TextMode="Password" Width=50%></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Enter New Password" ControlToValidate="txtNewPassword" 
                    CssClass="validation" ToolTip="Enter New Password" ValidationGroup="a">Enter New Password</asp:RequiredFieldValidator>

			</div>


            <div class="form-group">
				<asp:TextBox class="form-control input-lg" placeholder="Enter Confirm Password" 
                    tabindex="4" ID="txtConfirmPassword" runat="server" TextMode="Password" Width=50%></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Enter Confirm Password" ControlToValidate="txtConfirmPassword" 
                    CssClass="validation" ToolTip="Enter Confirm Password" ValidationGroup="a">Enter Confirm Password</asp:RequiredFieldValidator>

			</div>

			
			
			<div class="row">
				<div class="col-xs-12 col-md-6">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        class="btn btn-primary btn-block btn-lg" Width=50% 
                        ValidationGroup="a" onclick="btnUpdate_Click" /></div>
				
			</div>
		
	

</div>

<br />
<br />

</asp:Panel>



</asp:Content>
