using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace finalyearProject
{
    public partial class ViewQueries : System.Web.UI.Page
    {
        static string status = "All";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AdminId"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    if (!this.IsPostBack)
                    {
                        status = "All";
                        GetAllQueries();
                    }
                    else
                    {
                        if (status.Equals("Pending"))

                            GetPendingQueries();

                        else if (status.Equals("Answered"))

                            GetAnsweredQuestions();
                    }
                }
            }
            catch
            {

            }
        }

        #region -------- Employee Queries-----------

        public void GetAllQueries()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab.Rows.Clear();
            tab = obj.GetAllQueries();

            if (tab.Rows.Count > 0)
            {
                Table3.Rows.Clear();
                Table3.GridLines = GridLines.Both;

                TableHeaderRow mainrow = new TableHeaderRow();
                mainrow.ForeColor = System.Drawing.Color.Black;
                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableHeaderCell cell1 = new TableHeaderCell();
                cell1.Text = "Emp Id";
                mainrow.Controls.Add(cell1);

                TableHeaderCell cell2 = new TableHeaderCell();
                cell2.Text = "Query";
                mainrow.Controls.Add(cell2);

                TableHeaderCell cell3 = new TableHeaderCell();
                cell3.Text = "Posted Date";
                mainrow.Controls.Add(cell3);

                TableHeaderCell cell4 = new TableHeaderCell();
                cell4.Text = "Response";
                mainrow.Controls.Add(cell4);

                TableHeaderCell cell5 = new TableHeaderCell();
                cell5.Text = "Repy Date";
                mainrow.Controls.Add(cell5);

                Table3.Controls.Add(mainrow);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cell_username = new TableCell();
                    cell_username.Width = 150;
                    cell_username.Text = tab.Rows[i]["EmpId"].ToString();
                    row.Controls.Add(cell_username);

                    TableCell cell_Question = new TableCell();
                    cell_Question.Width = 250;
                    cell_Question.Text = tab.Rows[i]["Query"].ToString();
                    row.Controls.Add(cell_Question);

                    TableCell cell_posteddate = new TableCell();
                    cell_posteddate.Width = 100;
                    cell_posteddate.Text = tab.Rows[i]["PostedDate"].ToString();
                    row.Controls.Add(cell_posteddate);

                    TableCell cell_response = new TableCell();
                    cell_response.Width = 250;
                    cell_response.Text = tab.Rows[i]["Reply"].ToString();
                    row.Controls.Add(cell_response);

                    TableCell cell_replydate = new TableCell();
                    cell_replydate.Width = 100;
                    cell_replydate.Text = tab.Rows[i]["ReplyDate"].ToString();
                    row.Controls.Add(cell_replydate);

                    Table3.Controls.Add(row);
                }
            }

            else
            {
                Table3.Rows.Clear();
                Table3.GridLines = GridLines.None;

                TableRow row = new TableRow();

                TableCell cell1 = new TableCell();
                cell1.ForeColor = System.Drawing.Color.Red;
                cell1.Font.Bold = true;
                cell1.ColumnSpan = 5;
                cell1.Text = "No Queries Found!!!";
                row.Controls.Add(cell1);

                Table3.Controls.Add(row);
            }
        }

        public void GetPendingQueries()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab.Rows.Clear();
            Table3.Rows.Clear();

            tab = obj.GetNewQueries();

            if (tab.Rows.Count > 0)
            {
                Table3.Rows.Clear();
                Table3.GridLines = GridLines.Both;

                TableHeaderRow mainrow = new TableHeaderRow();
                mainrow.ForeColor = System.Drawing.Color.Black;
                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableHeaderCell cell1 = new TableHeaderCell();
                cell1.Text = "EmpId";
                mainrow.Controls.Add(cell1);

                TableHeaderCell cell2 = new TableHeaderCell();
                cell2.Text = "Query";
                mainrow.Controls.Add(cell2);

                TableHeaderCell cell3 = new TableHeaderCell();
                cell3.Text = "Posted Date";
                mainrow.Controls.Add(cell3);

                TableHeaderCell cell4 = new TableHeaderCell();
                cell4.Text = "Send Reply";
                mainrow.Controls.Add(cell4);

                Table3.Controls.Add(mainrow);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cell_username = new TableCell();
                    cell_username.Width = 150;
                    cell_username.Text = tab.Rows[i]["EmpId"].ToString();
                    row.Controls.Add(cell_username);

                    TableCell cell_Question = new TableCell();
                    cell_Question.Width = 250;
                    cell_Question.Text = tab.Rows[i]["Query"].ToString();
                    row.Controls.Add(cell_Question);

                    TableCell cell_date = new TableCell();
                    cell_date.Width = 150;
                    cell_date.Text = tab.Rows[i]["PostedDate"].ToString();
                    row.Controls.Add(cell_date);

                    TableCell cell_FQreply = new TableCell();
                    Button btn_FQreply = new Button();
                    btn_FQreply.Text = "Send Reply";
                    btn_FQreply.CssClass = "btn btn-theme pull-left";
                    btn_FQreply.ID = tab.Rows[i]["QueryId"].ToString();
                    btn_FQreply.Click += new EventHandler(btn_FQreply_Click);
                    cell_FQreply.Controls.Add(btn_FQreply);
                    row.Controls.Add(cell_FQreply);

                    Table3.Controls.Add(row);


                }

            }
            else
            {

                Table3.Rows.Clear();
                Table3.GridLines = GridLines.None;

                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.ForeColor = System.Drawing.Color.Red;
                cell.ColumnSpan = 5;
                cell.Text = "No Pending Queries Found!!!";
                row.Controls.Add(cell);

                Table3.Controls.Add(row);
            }


        }

        void btn_FQreply_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int queryId = int.Parse(btn.ID.ToString());

            Response.Redirect(string.Format("SendReply.aspx?queryId={0}", queryId));
        }

        protected void ImageButton1_Pending_Click(object sender, ImageClickEventArgs e)
        {
            status = "Pending";
            GetPendingQueries();
        }

        protected void ImageButton2_Answered_Click(object sender, ImageClickEventArgs e)
        {
            status = "Answered";
            GetAnsweredQuestions();
        }

        public void GetAnsweredQuestions()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();


            tab.Rows.Clear();

            tab = obj.GetOldQueries();

            if (tab.Rows.Count > 0)
            {
                Table3.Rows.Clear();
                Table3.GridLines = GridLines.Both;

                TableHeaderRow mainrow = new TableHeaderRow();
                mainrow.ForeColor = System.Drawing.Color.Black;
                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableHeaderCell cell1 = new TableHeaderCell();
                cell1.Text = "EmpId";
                mainrow.Controls.Add(cell1);

                TableHeaderCell cell2 = new TableHeaderCell();
                cell2.Text = "Query";
                mainrow.Controls.Add(cell2);

                TableHeaderCell cell3 = new TableHeaderCell();
                cell3.Text = "Posted Date";
                mainrow.Controls.Add(cell3);

                TableHeaderCell cell4 = new TableHeaderCell();
                cell4.Text = "Response";
                mainrow.Controls.Add(cell4);

                TableHeaderCell cell5 = new TableHeaderCell();
                cell5.Text = "Reply Date";
                mainrow.Controls.Add(cell5);

                Table3.Controls.Add(mainrow);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cell_username = new TableCell();
                    cell_username.Width = 150;
                    cell_username.Text = tab.Rows[i]["EmpId"].ToString();
                    row.Controls.Add(cell_username);

                    TableCell cell_Question = new TableCell();
                    cell_Question.Width = 250;
                    cell_Question.Text = tab.Rows[i]["Query"].ToString();
                    row.Controls.Add(cell_Question);

                    TableCell cell_posteddate = new TableCell();
                    cell_posteddate.Width = 100;
                    cell_posteddate.Text = tab.Rows[i]["PostedDate"].ToString();
                    row.Controls.Add(cell_posteddate);

                    TableCell cell_response = new TableCell();
                    cell_response.Width = 250;
                    cell_response.Text = tab.Rows[i]["Reply"].ToString();
                    row.Controls.Add(cell_response);

                    TableCell cell_replydate = new TableCell();
                    cell_replydate.Width = 100;
                    cell_replydate.Text = tab.Rows[i]["ReplyDate"].ToString();
                    row.Controls.Add(cell_replydate);

                    Table3.Controls.Add(row);
                }

            }
            else
            {
                Table3.Rows.Clear();
                Table3.GridLines = GridLines.None;

                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.ForeColor = System.Drawing.Color.Red;
                cell.Font.Bold = true;
                cell.Text = "No Replied Queries Found!!!";
                row.Controls.Add(cell);

                Table3.Controls.Add(row);
            }
        }

        #endregion


    }
}