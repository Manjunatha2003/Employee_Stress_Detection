<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP.Master" AutoEventWireup="true" CodeBehind="AddEmps.aspx.cs" Inherits="finalyearProject.AddEmps" %>
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
            <h2>Add Employees and their Details</h2>
          </div>
        </div>
      </div>
      <div class="row">
        <!-- single-well start-->
       
        <!-- single-well end-->
        <div class="col-md-6 col-sm-6 col-xs-12">
          <div class="well-middle">
            <div class="single-well">
              <a href="#">
                <h4 class="sec-head">Register Employee</h4>
              </a>
              
             

               

                <div class="form-group">
                <p>Enter EmpId</p>

            <asp:TextBox ID="txtEmpId" runat="server" Width="400px" Height="30px"></asp:TextBox>
                
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtEmpId" ErrorMessage="Enter EmpId" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                
                </div>
                <div class="form-group">
                 <p>Enter Password</p>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="400px" 
                        Height="30px"></asp:TextBox>
                 <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPassword" ErrorMessage="Enter Password" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                 
                </div>

                 <div class="form-group">
                  <p>Enter Name</p>
                  <asp:TextBox ID="txtName" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="Enter Name" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                 <div class="form-group">
                  <p>Enter Mobile</p>
                  <asp:TextBox ID="txtMobile" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtMobile" ErrorMessage="Enter Mobile" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                 <div class="form-group">
                  <p>Enter EmailId</p>
                  <asp:TextBox ID="txtEmailId" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtEmailId" ErrorMessage="Enter Email Id" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                 <div class="form-group">
                  <p>Enter Dept</p>
                  <asp:TextBox ID="txtDept" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtDept" ErrorMessage="Enter Dept Name" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                 <div class="form-group">
                  <p>Enter Designation</p>
                  <asp:TextBox ID="txtDesig" runat="server" Width="400px" Height="30px"></asp:TextBox>
                 <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtDesig" ErrorMessage="Enter Desig" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                </div>

     <div>           
    <asp:Button ID="btnSubmit" runat="server" Text="Add Employee" ValidationGroup="a" onclick="btnSubmit_Click" 
              />
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
