<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP.Master" AutoEventWireup="true" CodeBehind="ViewQueries.aspx.cs" Inherits="finalyearProject.ViewQueries" %>
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
            <h2>Employee Queries</h2>
          </div>
        </div>
      </div>
            <br />


            <table align="center" style="width: 77%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="ImageButton1_Pending" runat="server" 
                                    ImageUrl="~/img/folder-down-icon.jpg" 
                                    onclick="ImageButton1_Pending_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td align="center">
                                <asp:ImageButton ID="ImageButton2_Answered" runat="server" 
                                    ImageUrl="~/img/folder-edit-icon.jpg" 
                                    onclick="ImageButton2_Answered_Click" />
                            </td>
                        </tr>
                        <tr style="font-size: small">
                            <td align="center">
                                <b>Pending</b></td>
                            <td>
                                <b></b>
                            </td>
                            <td align="center">
                                <b>Answered</b></td>
                        </tr>
                        <tr style="font-size: small">
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>

                    <br />
             
                        <asp:Table ID="Table3" runat="server"  HorizontalAlign="Center">
                        </asp:Table>

<br />
<br />
 <marquee scrolldelay="150" behavior="alternate">
          <img src="../img/Emp1.jpg"" width="460" height="200" alt="" /> &nbsp
          <img src="../img/Emp2.jpg" width="460" height="200" alt="" /> &nbsp
         <img src="../img/Emp3.jpg" width="460" height="200" alt="" /> &nbsp
          </marquee>

              
</div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>

</asp:Content>
