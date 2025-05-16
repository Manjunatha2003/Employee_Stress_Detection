<%@ Page Title="" Language="C#" MasterPageFile="~/EmpMP.Master" AutoEventWireup="true" CodeBehind="_ProfileUpdate.aspx.cs" Inherits="finalyearProject._ProfileUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    
<div class="container">
<br />

<h2>MEMBER PROFILE</h2>
<hr class="colorgraph">


			
			<div class="form-group">
				<asp:Label ID="lblMemberId" runat="server"></asp:Label>
                <br />
                 <br />
				<asp:TextBox class="form-control input-lg" placeholder="Enter Old Password" 
                    tabindex="4" ID="txtName" runat="server" Width=50%></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Enter Name" ControlToValidate="txtName" 
                    CssClass="validation" ToolTip="Enter Name" ValidationGroup="a">Enter Name</asp:RequiredFieldValidator>

			</div>

			<div class="form-group">
				<asp:TextBox class="form-control input-lg" placeholder="Enter New Password" 
                    tabindex="4" ID="txtMobile" runat="server" Width=50%></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Enter Mobile" ControlToValidate="txtMobile" 
                    CssClass="validation" ToolTip="Enter Mobile" ValidationGroup="a">Enter Mobile</asp:RequiredFieldValidator>

			    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ControlToValidate="txtMobile" CssClass="validation" 
                    ErrorMessage="Only 10 digits" ToolTip="Only 10 digits" 
                    ValidationExpression="\d{10}" ValidationGroup="a"></asp:RegularExpressionValidator>

			</div>


            <div class="form-group">
				<asp:TextBox class="form-control input-lg" placeholder="Enter Confirm Password" 
                    tabindex="4" ID="txtEmailId" runat="server" Width=50%></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Enter EmailId" ControlToValidate="txtEmailId" 
                    CssClass="validation" ToolTip="Enter EmailId" ValidationGroup="a">Enter EmailId</asp:RequiredFieldValidator>

			    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                    runat="server" ControlToValidate="txtEmailId" CssClass="validation" 
                    ErrorMessage="Invalid Email Id Format" ToolTip="Invalid Email Id Format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="a"></asp:RegularExpressionValidator>

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
