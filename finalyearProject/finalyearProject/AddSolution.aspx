<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP.Master" AutoEventWireup="true" CodeBehind="AddSolution.aspx.cs" Inherits="finalyearProject.AddSolution" %>
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
            <h2>Add Solution</h2>
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
                <h4 class="sec-head">Solution Module</h4>
              </a>
              
             

               

                <div class="form-group">
                 <p>Select Level</p>
         
                   <asp:DropDownList ID="ddlLevels" runat="server">
                       <asp:ListItem>25% Stress</asp:ListItem>
                       <asp:ListItem>50% Stress</asp:ListItem>
                       <asp:ListItem>100% Stress</asp:ListItem>
                    </asp:DropDownList>
                </div>

                 <div class="form-group">
                  <p>Enter Solution</p>
                  <asp:TextBox ID="txtSolution" runat="server" Width="650px" Height="150px" 
                         TextMode="MultiLine"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtSolution" ErrorMessage="Enter Solution" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                </div>

                 
     <div>           
    <asp:Button ID="btnSubmit" runat="server" Text="Add Solution" ValidationGroup="a" onclick="btnSubmit_Click" 
              />
               <br />
         <br />
         <asp:Button ID="btnView" runat="server" Height="50px" Text="View Solution" 
             Width="450px" onclick="btnView_Click1" />
               </div>
             


            </div>
          </div>
        </div>
        <!-- End col-->
          <br />
      </div>
    </div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>

</asp:Content>
