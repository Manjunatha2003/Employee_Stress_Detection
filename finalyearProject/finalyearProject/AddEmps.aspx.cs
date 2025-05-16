using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace finalyearProject
{
    public partial class AddEmps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    txtEmpId.Focus();

                    if (Request.QueryString["empId"] == null)
                    {

                    }
                    else
                    {
                        LoadEmp();
                    }
                }


            }
        }

        //function to load emp details
        private void LoadEmp()
        {
            BLL obj = new BLL();
            DataTable tab = new DataTable();
            tab = obj.GetEmpById(Request.QueryString["empId"]);

            Session["empId"] = null;
            Session["empId"] = Request.QueryString["empId"];

            if (tab.Rows.Count > 0)
            {
                txtEmpId.Text = tab.Rows[0]["EmpId"].ToString();
                //txtPassword.Text = tab.Rows[0]["Password"].ToString();
                txtName.Text = tab.Rows[0]["Name"].ToString();
                txtMobile.Text = tab.Rows[0]["Mobile"].ToString();
                txtEmailId.Text = tab.Rows[0]["EmailId"].ToString();
                txtDept.Text = tab.Rows[0]["DeptName"].ToString();
                txtDesig.Text = tab.Rows[0]["Designation"].ToString();
            }

            btnSubmit.Text = "Update Employee";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (btnSubmit.Text.Equals("Add Employee"))
            {
                try
                {
                    if (obj.CheckEmpId(txtEmpId.Text))
                    {
                        obj.InsertEmp(txtEmpId.Text, txtPassword.Text, txtName.Text, txtMobile.Text, txtEmailId.Text, txtDept.Text, txtDesig.Text);
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('New Employee Added Successfully!!!')</script>");
                        ClearTxts();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('EmpId Exists!!!')</script>");
                    }
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                }
            }
            else if (btnSubmit.Text.Equals("Update Employee"))
            {
                if (txtEmpId.Text.Equals(Session["empId"].ToString()))
                {
                    try
                    {
                        obj.UpdateEmp(txtEmpId.Text, txtPassword.Text, txtName.Text, txtMobile.Text, txtEmailId.Text, txtDept.Text, txtDesig.Text);

                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Employee Updated Successfully!!!')</script>");
                        ClearTxts();

                        btnSubmit.Text = "Add Employee";

                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                    }
                }
                else
                {
                    if (obj.CheckEmpId(txtEmpId.Text))
                    {
                        try
                        {
                            obj.UpdateEmp(txtEmpId.Text, txtPassword.Text, txtName.Text, txtMobile.Text, txtEmailId.Text, txtDept.Text, txtDesig.Text);

                            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Employee Updated Successfully!!!')</script>");
                            ClearTxts();

                            btnSubmit.Text = "Add Employee";

                        }
                        catch
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('EmpId Exists!!!')</script>");
                    }
                }
            }
        }

        //function to clear text box contents
        private void ClearTxts()
        {
            txtMobile.Text = txtEmailId.Text = txtName.Text = txtEmpId.Text = txtDesig.Text = txtDept.Text = string.Empty;

        }
    }
}