<%@ Page Title="" Language="C#" MasterPageFile="~/EmpMP.Master" AutoEventWireup="true" CodeBehind="PostQuery.aspx.cs" Inherits="finalyearProject.PostQuery" %>
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
            
                      <table align="center" style="width: 79%;">
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style2">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: center; " class="style1">
                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                    ImageUrl="~/img/folder-down-icon.jpg" onclick="ImageButton1_Click" />
                            </td>
                            <td style="text-align: center; " class="style2">
                                <asp:ImageButton ID="ImageButton2" runat="server" 
                                    ImageUrl="~/img/folder-edit-icon.jpg" onclick="ImageButton2_Click" />
                            </td>
                            <td style="text-align: center">
                                <asp:ImageButton ID="ImageButton3" runat="server" 
                                    ImageUrl="~/img/folder-process-icon.jpg" onclick="ImageButton3_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; font-size: small; " class="style1">
                                <b>Pending</b></td>
                            <td style="text-align: center; font-size: small; " class="style2">
                                <b>Post New Question</b></td>
                            <td style="text-align: center; font-size: small;">
                                <b>Answered</b></td>
                        </tr>
                    </table>
                    <br />
                    
                    <asp:Panel ID="Panel8" runat="server" HorizontalAlign="Center">
                        <br />
                        <asp:Table ID="Table1" runat="server" Font-Size="Small" 
                            HorizontalAlign="Center">
                        </asp:Table>
                        <br />
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel9" runat="server" Visible="False">
                        <br />
                        <table align="center">
                            <tr>
                                <td align="center" 
                                    style="width: 387px; background-image: url('images/Post_Question.JPG'); height: 207px;" 
                                    valign="middle">
                                    <br />
                                    <table align="center" style="width:88%; text-align: center;">
                                        <tr>
                                            <td style="text-align: left; font-size: small; width: 86px;">
                                                <b>Question</b></td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txt_postQuestion" runat="server" Height="80px" 
                                                    TextMode="MultiLine" Width="250px" Font-Size="Small"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 86px;">
                                                &nbsp;</td>
                                            <td style="text-align: left">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ControlToValidate="txt_postQuestion" ErrorMessage="Enter Query" 
                                                    Font-Size="Small" ForeColor="#FF3300" ToolTip="filed required" 
                                                    ValidationGroup="postquestions"></asp:RequiredFieldValidator>
                                            </td>
                                            <td style="text-align: left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 86px;">
                                                &nbsp;</td>
                                            <td align="right">
                                                <asp:Button ID="btnUpdate" runat="server" class="btn btn-theme pull-left" 
                                                    onclick="btnUpdate_Click" Text="Post Query" 
                                                    ValidationGroup="postquestions" />
                                            </td>
                                            <td style="text-align: left">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        
                    </asp:Panel>
               

               
               
            <div>           
               </div><marquee scrolldelay="150" behavior="alternate">
          <img src="../img/slider/ed7.jpg" width="460" height="200" alt="" /> &nbsp
          <img src="../img/slider/ed8.jpg" width="460" height="200" alt="" /> &nbsp
         <img src="../img/slider/ed9.jpg" width="460" height="200" alt="" /> &nbsp
          </marquee>
             
</div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>

</asp:Content>
