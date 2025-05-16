<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMP.Master" AutoEventWireup="true" CodeBehind="_CompareAlgorithms.aspx.cs" Inherits="finalyearProject._CompareAlgorithms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminHome" runat="server">

 <div id="about" class="about-area area-padding">
   <div class="container">
      <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
          <div class="section-headline text-center">
			<h2>COMPARATIVE ANALYSIS OF ALGORITHMS!!</h2>

              </div>
        </div>
      </div>
						   		<span>
                                       <asp:Table ID="Table3" runat="server">
                                       </asp:Table>  </span>
						  </div>
                          <br />

  				                 <asp:Panel ID="panelUpdatePassword" runat="server">

 <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
          <div class="section-headline text-center">
          <h2><span>Graph</span> Representation (Algorithm Vs Accuracy)!!!</h2>
          <hr />
        </div>
        </div>
      </div>
    	
<div style="float:left;width:340px;">
			<div class="box">
				<div class="registration_left">
   <%-- <a href="#"><div class="reg_fb"><i>Select Chart Type</i><div class="clear"></div></div></a>--%>
		 <div class="registration_form">
				<p>
					<asp:DropDownList ID="ddlChartType" runat="server" AutoPostBack="False" 
                        Visible="False">
					</asp:DropDownList>
				</p>
			</div>

			<div class="box">
				<p>
					<asp:RadioButtonList ID="rblValueCount" runat="server" AutoPostBack="False" Visible="False" 
                        >
						<asp:ListItem Value="10">10 Values</asp:ListItem>
						<asp:ListItem Value="20">20 Values</asp:ListItem>
						<asp:ListItem Value="50">50 Values</asp:ListItem>
						<asp:ListItem Value="100">100 Values</asp:ListItem>
						<asp:ListItem Value="500" Selected="True">500 Values</asp:ListItem>
					</asp:RadioButtonList>
				</p>
			</div>
		</div>

		<div class="box">
			<p>
				<asp:CheckBox ID="cbUse3D" runat="server" AutoPostBack="False" 
                    Text="Use 3D Chart" Visible="False" />
			</p>
			<p>
				<asp:RadioButtonList ID="rblInclinationAngle" runat="server" 
                    AutoPostBack="False" Visible="False">
					<asp:ListItem Value="-90">-90°</asp:ListItem>
					<asp:ListItem Value="-50">-50°</asp:ListItem>
					<asp:ListItem Value="-20">-20°</asp:ListItem>
					<asp:ListItem Value="0">0°</asp:ListItem>
					<asp:ListItem Selected="True" Value="20">20°</asp:ListItem>
					<asp:ListItem Value="50">50°</asp:ListItem>
					<asp:ListItem Value="90">90°</asp:ListItem>
				</asp:RadioButtonList>
			</p>
		</div>
		

	</div>

  <div>
      <table style="width: 100%;">
          <tr>
              <td>
                  &nbsp;<asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show" 
                      ValidationGroup="a" Width="125px" Visible="False" />
                  &nbsp;</td>
          </tr>
          </table>
  
  </div>
		
      
    </div><div class="clear"></div>

    <asp:Chart ID="cTestChart" runat="server" Height="400px" Width="600px" 
            Visible="False">
			<Series>
				<asp:Series Name="Testing">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartArea1">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>
        
       

        </div>

          </asp:Panel>
             </div>
 

        <br />
         </asp:Panel>
</asp:Content>
