using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace finalyearProject
{
    public partial class _ProfileUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                GetProfile();
            }
        }

        private void GetProfile()
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();
            tab = obj.GetEmpById(Session["EmpId"].ToString());

            if (tab.Rows.Count > 0)
            {
                lblMemberId.Font.Bold = true;
                lblMemberId.Text = "Employee Id: " + tab.Rows[0]["EmpId"].ToString();

                txtName.Text = tab.Rows[0]["Name"].ToString();
                txtMobile.Text = tab.Rows[0]["Mobile"].ToString();
                txtEmailId.Text = tab.Rows[0]["EmailId"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                obj.UpdateProfile(txtName.Text, txtMobile.Text, txtEmailId.Text, Session["EmpId"].ToString());
                GetProfile();

                ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Profile Updated Successfully')</script>");
            }
            catch
            {

            }
        }
    }
}