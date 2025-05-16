using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace finalyearProject
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!this.IsPostBack)

                    txtOldPassword.Focus();
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();
                tab.Rows.Clear();

                tab = obj.GetEmpById(Session["EmpId"].ToString());
                string oldPassword = tab.Rows[0]["Password"].ToString();

                if (txtOldPassword.Text.Equals(oldPassword))
                {
                    obj.UpdateEmpPassword(txtNewPassword.Text, Session["EmpId"].ToString());
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Employee Password changed Successfully!!!')</script>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Employee Old password Incorrect!!!')</script>");
                }
            }
            catch
            {

            }
        }

      
    }
}