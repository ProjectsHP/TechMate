using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class Login : System.Web.UI.Page
    {

        ServiceClient SRef = new ServiceClient();
        bool isRegError = false;
        bool isLogError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorReg.Visible= false;
            lblError.Visible= false;
            if (!IsPostBack)
            {
                if (isRegError == true)
                {
                    lblErrorReg.Visible = true;
                    lblError.Visible = false;

                }else if (isLogError == true)
                {
                    lblError.Visible = true;
                    lblErrorReg.Visible = false;
                }
          
               
            }
          
         

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            var UserID = SRef.LoginSOAP(txtLoginEmail.Value, txtLoginPass.Value);
            
            if (UserID.Id==-1)
            {
                lblError.Visible = true;
                txtLoginEmail.Value = null;
                txtLoginPass.Value = null;
                txtLoginEmail.Focus();
                isLogError = true;

            }
            else
            {
                Session["LoggedUser"] = UserID.Id;

                switch (UserID.UserType)
                {

                    case "Admin":
                        Session["UserType"] = "Admin";
                        Response.Redirect("Admin.aspx");
                    break;
                    case "Clerk":
                        Session["UserType"] = "Clerk";
                        Response.Redirect("Clerk.aspx");
                    break;
                    case "Manager":
                        Session["UserType"] = "Manager";
                        Response.Redirect("Manager.aspx");
                        break;
                    case "Customer":
                        Session["UserType"] = "Customer";
                        break;


                }


                Response.Redirect("Home.aspx");

            }

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
           
            if (txtPassword.Value == txtConfPassword.Value)
            {
                
                   int reg = SRef.RegisterSOAP(txtName.Value, txtSurname.Value, txtContacts.Value, "", txtEmail.Value, txtPassword.Value, "Customer");
                   if (reg == 1)
                   {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully registered, you may login')", true);
                    txtLoginEmail.Focus();
                 
                   }
                   else if (reg == 0)
                   {
                       lblErrorReg.Visible = true;
                       lblErrorReg.InnerText = "Email already exists. Please use a different Email or continue to login";
                   }
                   else
                   {
                       lblErrorReg.Visible = true;
                       lblErrorReg.InnerText = "Unexpected error encountered! please try again";
                   }

            }
               else
               {
                   lblErrorReg.Visible = true;
                   lblErrorReg.InnerText = "Passwords must match";
                    isRegError = true;
                   txtPassword.Focus();

               }
              
        }
        
    }
}