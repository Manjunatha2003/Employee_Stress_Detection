<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP.Master" AutoEventWireup="true" CodeBehind="_RFAlgorithm.aspx.cs" Inherits="finalyearProject._RFAlgorithm" %>
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
          <h2 class="sec-head">Employee Stress Prediction using RF</h2>            
          </div>
        </div>
      </div>
      <div class="row">
       


       <br />
 <div style="height:250px; width:auto; overflow:auto">

 <h3>Testing Dataset</h3>

<asp:GridView ID="GridView1" runat="server" BackColor="White" 
         BorderColor="#CC9966" BorderWidth="1px" CellPadding="4" BorderStyle="None">

    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
    <PagerStyle ForeColor="#330099" 
        HorizontalAlign="Center" BackColor="#FFFFCC" />
    <RowStyle ForeColor="#330099" BackColor="White" />
    <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />

</asp:GridView>
</div>
          <br />

           <h2><span>STRESS </span> PREDICTION USING Random Forest</h2>
          <hr />

          <br />
          <h2>0 - Stress Free, 1- 25% Stress Level, 2 - 50% Stress Level and 3 - 100 % in Stress</h2>
          <br />
          <asp:Button ID="btnPrediction" runat="server" 
                      Text="Predict Output" 
              onclick="btnPrediction_Click" CssClass="btn" Height="50px" Width="150px" /> &nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnResults" runat="server" CssClass="btn" 
              onclick="btnResults_Click" Text="Result Analysis" Height="50px" 
              Width="150px" />
          <br /><br /><div>
      <asp:Table ID="tablePrediction" runat="server">
      </asp:Table>
      </div>
          <br />
        

     

        <!-- End col-->
      </div>
    </div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>
</asp:Content>
