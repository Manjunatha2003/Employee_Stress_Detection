using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace finalyearProject
{
    public partial class AddSolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtSolution.Focus();

                if (Request.QueryString["sId"] == null)
                {

                }
                else
                {
                    LoadSol();
                }
            }
        }

        //function to load Sol details
        private void LoadSol()
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();
            tab = obj.GetSolutionById(int.Parse(Request.QueryString["sId"]));

            Session["sId"] = null;
            Session["sId"] = Request.QueryString["sId"];

            if (tab.Rows.Count > 0)
            {
                txtSolution.Text = tab.Rows[0]["Solution"].ToString();
                string dataTextField = ddlLevels.Items.FindByValue(tab.Rows[0]["SLevel"].ToString()).ToString();

                ListItem item = new ListItem(dataTextField, dataTextField);
                int index = ddlLevels.Items.IndexOf(item);

                if (index != -1)

                    ddlLevels.SelectedIndex = index;       


            }

            btnSubmit.Text = "Update Solution";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (btnSubmit.Text.Equals("Add Solution"))
                {
                    obj.InsertSolution(ddlLevels.SelectedItem.Text, txtSolution.Text);
                    txtSolution.Text = string.Empty;

                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Added Successfully!')</script>");
                }
                else if (btnSubmit.Text.Equals("Update Solution"))
                {
                    obj.UpdateSolution(ddlLevels.SelectedItem.Text, txtSolution.Text, int.Parse(Session["sId"].ToString()));
                    txtSolution.Text = string.Empty;

                    ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Updated Successfully!')</script>");

                    btnSubmit.Text = "Add Solution";
                }
            }
            catch
            {

            }
        }

      

        protected void btnView_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Solution.aspx");
        }
    }
}