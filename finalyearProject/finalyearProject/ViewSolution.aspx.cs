using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace finalyearProject
{
    public partial class ViewSolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSolution();
        }

        //function to load all solutions
        private void LoadSolution()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                int serialNo = 1;

                tab = obj.GetSolution();

                if (tab.Rows.Count > 0)
                {
                    tableEmps.Rows.Clear();

                    tableEmps.BorderStyle = BorderStyle.Double;
                    tableEmps.GridLines = GridLines.Both;
                    tableEmps.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;

                    mainrow.BackColor = System.Drawing.Color.DeepSkyBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell21 = new TableCell();
                    cell21.Text = "<b>Level</b>";
                    mainrow.Controls.Add(cell21);

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>Solution</b>";
                    mainrow.Controls.Add(cell2);
                                      
                    tableEmps.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellRegNo = new TableCell();
                        cellRegNo.Width = 150;
                        cellRegNo.Text = tab.Rows[i]["SLevel"].ToString();
                        row.Controls.Add(cellRegNo);

                        TableCell cellName = new TableCell();
                        cellName.Width = 650;
                        cellName.Text = tab.Rows[i]["Solution"].ToString();
                        row.Controls.Add(cellName);


                        
                        tableEmps.Controls.Add(row);
                    }
                }
                else
                {
                    tableEmps.Rows.Clear();

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No Records Found!!!";

                    rno.Controls.Add(cellno);
                    tableEmps.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }
    }
}