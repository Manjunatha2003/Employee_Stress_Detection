<%@ Page Title="" Language="C#" MasterPageFile="~/EmpMP.Master" AutoEventWireup="true" CodeBehind="EmpStress.aspx.cs" Inherits="finalyearProject.EmpStress" %>
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
            <h2>Stress Prediction - Enter Parameters</h2>
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
                <h4 class="sec-head">Employee Parameters</h4>
              </a>
              
             

               

                <div class="form-group">
                <p>Enter Gender</p>

            <asp:TextBox ID="txtGender" runat="server" Width="400px" Height="30px"></asp:TextBox>
                
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtGender" ErrorMessage="Enter Gender" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                <h6>Gender: 1- male , 2 - female</h6>
                </div>

                
                <div class="form-group">
                <p>Enter Age</p>

            <asp:TextBox ID="txtAge" runat="server" Width="400px" Height="30px"></asp:TextBox>
                
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                        ControlToValidate="txtAge" ErrorMessage="Enter Age" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                <h6>Age: numerical</h6>
                </div>

                <div class="form-group">
                 <p>Enter Financial_Issues</p>
            <asp:TextBox ID="txtFinancial_Issues" runat="server" Width="400px" 
                        Height="30px"></asp:TextBox>
                 <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtFinancial_Issues" ErrorMessage="Enter Financial_Issues" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                 <h6>Financial_Issues: 0- No , 1 - Yes</h6>
                </div>

                 <div class="form-group">
                  <p>Enter Family_Issues</p>
                  <asp:TextBox ID="txtFamily_Issues" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtFamily_Issues" ErrorMessage="Enter Family_Issues" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>

                         <h6>Family_Issues: 0- No , 1 - Yes</h6>
                </div>

                 <div class="form-group">
                  <p>Enter Working Hrs</p>
                  <asp:TextBox ID="txtworking_Hours" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtworking_Hours" ErrorMessage="Enter working_Hours" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                         <h6>Working Hours: Numeric 6,7,8, 9. 10 ....</h6>
                </div>

                 <div class="form-group">
                  <p>Enter Learning_Method</p>
                  <asp:TextBox ID="txtLearning_Method" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtLearning_Method" ErrorMessage="Enter Learning_Method" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>

                        <h6>Learning_Method: 1- Fair / 2 - Not Good.</h6>
                </div>

                 <div class="form-group">
                  <p>Enter Health_Issues</p>
                  <asp:TextBox ID="txtHealth_Issues" runat="server" Width="400px" Height="30px"></asp:TextBox>
                <br />
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtHealth_Issues" ErrorMessage="Enter Health_Issues" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>

                        <h6>Health_Issues: 1- No , 2 - Yes</h6>
                </div>

                 <div class="form-group">
                  <p>Enter Partiality_Fix</p>
                  <asp:TextBox ID="txtPartiality_Fix" runat="server" Width="400px" Height="30px"></asp:TextBox>
                 <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtPartiality_Fix" ErrorMessage="Enter Partiality_Fix" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>

                        <h6>Partiality_Fix: 0- No , 1 - Yes</h6>
                </div>

                <div class="form-group">
                  <p>Enter Collegues_Issue</p>
                  <asp:TextBox ID="txtColleguesIssue" runat="server" Width="400px" Height="30px"></asp:TextBox>
                 <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtColleguesIssue" ErrorMessage="Enter Collegues_Issue" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>

                        <h6>Collegues_Issue: 0- No , 1 - Yes/</h6>
                </div>

               

                <div class="form-group">
                  <p>Enter Pressure</p>
                  <asp:TextBox ID="txtPressure" runat="server" Width="400px" Height="30px"></asp:TextBox>
                 <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtPressure" ErrorMessage="Enter Pressure" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                        <h6>Pressure: 0- No , 1 - Yes</h6>
                </div>

                <div class="form-group">
                  <p>Enter Regular</p>
                  <asp:TextBox ID="txtRegular" runat="server" Width="400px" Height="30px"></asp:TextBox>
                 <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="txtRegular" ErrorMessage="Enter Regular" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                         <h6>Regular: 1- No , 2 - Yes</h6>
                </div>

                <div class="form-group">
                  <p>Enter Interaction</p>
                  <asp:TextBox ID="txtInteraction" runat="server" Width="400px" Height="30px"></asp:TextBox>
                 <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ControlToValidate="txtInteraction" ErrorMessage="Enter Interaction" 
                        ValidationGroup="a" CssClass="error"></asp:RequiredFieldValidator>
                          <h6>Interaction: 1- Excellent , 2 - Good, 3 - Average, 4 - Poor</h6>
                </div>

     <div>           
    <asp:Button ID="btnSubmit" runat="server" Text="Predict Stress Level" 
             ValidationGroup="a" onclick="btnSubmit_Click" Height="50px" 
              />
               <br />
         <br />
         <h4>
             Outcome: 0 - Normal, 1 - 25% Stress Level, <br />
             2 - 50% Stress level, 3 - 100% Stress 
             Level</h4>
         <br />
         <asp:Label ID="lblResult" runat="server"></asp:Label>
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
