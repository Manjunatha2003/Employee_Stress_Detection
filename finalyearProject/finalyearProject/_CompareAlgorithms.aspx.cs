using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace finalyearProject
{
    public partial class _CompareAlgorithms : System.Web.UI.Page
    {
        Dictionary<string, double> testData = new Dictionary<string, double>();

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                _ComparativeAnalysis();

                base.OnLoad(e);

                if (!IsPostBack)
                {
                    // bind chart type names to ddl
                    ddlChartType.DataSource = Enum.GetNames(typeof(SeriesChartType));
                    ddlChartType.DataBind();

                    //cbUse3D.Checked = true;
                }

                DataBind();

            }
            catch
            {

            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            testData.Clear();


            testData.Add("NB", _percentageNB);           
            testData.Add("RF", _percentageRF);

            cTestChart.Series["Testing"].Points.DataBind(testData, "Key", "Value", string.Empty);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // update chart rendering           
            cTestChart.Series["Testing"].ChartTypeName = "Pie";

            cTestChart.ChartAreas[0].Area3DStyle.Enable3D = cbUse3D.Checked;
            cTestChart.ChartAreas[0].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);

            cTestChart.Visible = true;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            cTestChart.Visible = true;

            OnDataBinding(e);
            OnPreRender(e);
        }

        static double _percentageNB = 0, _percentageRF;
                
        private void _ComparativeAnalysis()
        {
            _percentageNB = double.Parse(Session["NB_Accuracy"].ToString());
            _percentageRF = double.Parse(Session["RF_Accuracy"].ToString());

            BLL obj = new BLL();


            Table3.Rows.Clear();

            Table3.BorderStyle = BorderStyle.Double;
            Table3.GridLines = GridLines.Both;
            Table3.BorderColor = System.Drawing.Color.DarkGray;

            //mainrow
            TableRow mainrow = new TableRow();
            mainrow.Height = 30;
            mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

            mainrow.BackColor = System.Drawing.Color.SteelBlue;

            TableCell cell1 = new TableCell();
            cell1.Width = 350;
            cell1.Text = "<b>Constraint</b>";
            mainrow.Controls.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.Width = 200;
            cell2.Text = "<b>NB Algorithm</b>";
            mainrow.Controls.Add(cell2);

            TableCell cell4 = new TableCell();
            cell4.Width = 200;
            cell4.Text = "<b>RF Algorithm</b>";
            mainrow.Controls.Add(cell4);

            Table3.Controls.Add(mainrow);

            //1st row
            TableRow row1 = new TableRow();

            TableCell cellAcc = new TableCell();
            cellAcc.Text = "<b>Accuracy</b>";
            row1.Controls.Add(cellAcc);

            TableCell cellAccLVQ = new TableCell();
            cellAccLVQ.Text = Session["NB_Accuracy"].ToString() + "%";
            row1.Controls.Add(cellAccLVQ);

            TableCell cellAccBP = new TableCell();
            //cal           
            cellAccBP.Text = Session["RF_Accuracy"].ToString() + "%";
            row1.Controls.Add(cellAccBP);

            Table3.Controls.Add(row1);

            //2nd row           
            TableRow row2 = new TableRow();

            TableCell cellTime = new TableCell();
            cellTime.Text = "<b>Time (milli secs)</b>";
            row2.Controls.Add(cellTime);



            TableCell cellTimeLVQ = new TableCell();
            cellTimeLVQ.Text = Session["NB_Time"].ToString();
            row2.Controls.Add(cellTimeLVQ);


            TableCell cellTimeBP = new TableCell();
            cellTimeBP.Text = Session["RF_Time"].ToString(); ;
            row2.Controls.Add(cellTimeBP);

            Table3.Controls.Add(row2);

            //3rd row           
            TableRow row3 = new TableRow();

            TableCell cellCorrect = new TableCell();
            cellCorrect.Text = "<b>Precision</b>";
            row3.Controls.Add(cellCorrect);



            TableCell cellCorrectLVQ = new TableCell();
            cellCorrectLVQ.Text = Session["NB_Precision"].ToString();
            row3.Controls.Add(cellCorrectLVQ);



            TableCell cellCorrectBP = new TableCell();
            cellCorrectBP.Text = Session["RF_Precision"].ToString();
            row3.Controls.Add(cellCorrectBP);

            Table3.Controls.Add(row3);

            //4th row           
            TableRow row4 = new TableRow();

            TableCell cellInCorrect = new TableCell();
            cellInCorrect.Text = "<b>Recall</b>";
            row4.Controls.Add(cellInCorrect);

            TableCell cellInCorrectLVQ = new TableCell();
            cellInCorrectLVQ.Text = Session["NB_Recall"].ToString();
            row4.Controls.Add(cellInCorrectLVQ);

            TableCell cellInCorrectBP = new TableCell();
            cellInCorrectBP.Text = Session["RF_Recall"].ToString();
            row4.Controls.Add(cellInCorrectBP);            

            Table3.Controls.Add(row4);
        }
    }
}