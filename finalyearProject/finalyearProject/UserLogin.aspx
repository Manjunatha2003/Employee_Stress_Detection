<%@ Page Title="" Language="C#" MasterPageFile="~/MainMP.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="finalyearProject.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="Panel1" runat="server">
    <!-- Start contact Area -->  
    <div id="about" class="about-area area-padding">
   <div class="container">
      <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
          <div class="section-headline text-center">
            <h2>Login Form for Users</h2>
          </div>
        </div>
      </div>
      <div class="row">
        <!-- single-well start-->
        <div class="col-md-6 col-sm-6 col-xs-12">
          <div class="well-left">
            <div class="single-well">
              <a href="#">
								  <img src="img/slider/ed9.jpg" alt="">
								</a>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
          </div>
        </div>
        <!-- single-well end-->
        <div class="col-md-6 col-sm-6 col-xs-12">
          <div class="well-middle">
            <div class="single-well">
              <a href="#">
                <h4 class="sec-head">input your credentials to get login</h4>
              </a>
              
             

                <div class="form-group">

                    <asp:DropDownList ID="ddlUsers" runat="server" Height="30px" Width="400px">
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>Employee</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">

        <asp:TextBox ID="txtUserId" runat="server" Width="400px" Height="30px"></asp:TextBox>
                
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUserId" ErrorMessage="Enter UserId" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                
                </div>
                <div class="form-group">

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="400px" 
                        Height="30px"></asp:TextBox>
                 
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Enter Password" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                 
                </div>
     <div>           
    <asp:Button ID="btnLogin" runat="server" Text="Get Login" ValidationGroup="a" 
             onclick="btnLogin_Click" />
               </div>
             


            </div>
          </div>
        </div>
        <!-- End col-->
      </div>
    </div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>
</asp:Content>
