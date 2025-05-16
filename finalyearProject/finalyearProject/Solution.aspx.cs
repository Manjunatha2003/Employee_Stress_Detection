using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace finalyearProject
{
    public partial class Solution : System.Web.UI.Page
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
                                      
                    TableCell cell65 = new TableCell();
                    cell65.Text = "<b>Edit</b>";
                    mainrow.Controls.Add(cell65);

                    TableCell cell66 = new TableCell();
                    cell66.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell66);

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

                        
                        TableCell cell_edit = new TableCell();
                        cell_edit.Width = 100;
                        LinkButton lbtn_edit = new LinkButton();
                        lbtn_edit.ForeColor = System.Drawing.Color.Red;
                        lbtn_edit.Font.Bold = true;
                        lbtn_edit.Text = "Edit";
                        lbtn_edit.ID = "Edit~" + tab.Rows[i]["SolutionId"].ToString();
                        lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                        cell_edit.Controls.Add(lbtn_edit);
                        row.Controls.Add(cell_edit);

                        TableCell cell_delete = new TableCell();
                        cell_delete.Width = 100;
                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.Red;
                        lbtn_delete.Font.Bold = true;
                        lbtn_delete.Text = "Delete";

                        lbtn_delete.ID = "Delete~" + tab.Rows[i]["SolutionId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this Record?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);

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

        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteSolution(int.Parse(s[1]));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Deleted Successfully!!!')</script>");
                LoadSolution();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        void lbtn_edit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                Response.Redirect(string.Format("AddSolution.aspx?sId={0}", s[1]));
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }
    }
}