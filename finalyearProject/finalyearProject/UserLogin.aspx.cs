using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace finalyearProject
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserId.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();

                if (ddlUsers.SelectedIndex == 0)
                {
                    if (obj.CheckAdminLogin(txtUserId.Text, txtPassword.Text))
                    {
                        Session["AdminId"] = txtUserId.Text;
                        Response.Redirect("~/AdminHome.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Login Failed!!!')</script>");
                    }
                }
                else if (ddlUsers.SelectedIndex == 1)
                {
                    if (obj.CheckEmpLogin(txtUserId.Text, txtPassword.Text))
                    {
                        Session["EmpId"] = txtUserId.Text;
                        Response.Redirect("~/EmpHome.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "key", "<script>alert('Login Failed!!!')</script>");
                    }
                }
            }
            catch
            {

            }
        }
    }
}