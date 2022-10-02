using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  liContactUs.Visible = false;
      //      liProfile.Visible = false;
            liReports.Visible = false;
            liManager.Visible = false;
            liClerk.Visible = false;
            liAdmin.Visible = false;
            if (Session["LoggedUser"] == null)
            {
                liLogout.Visible = false;
                liLogin.Visible = true;
            }
            else
            {
                string userType = Session["UserType"].ToString();
                switch (userType)
                {
                    case "Manager":
                        liReports.Visible = true;
                        liManager.Visible = true;
                        break;

                    case "Admin":
                        liAdmin.Visible = true;
                        break;

                    case "Clerk":
                        liClerk.Visible=true;
                        break;

                        default:
                        break;
                }
              
                liLogout.Visible = true;
                liLogin.Visible=false;
               // liProfile.Visible = true;
            }
        }
    }
}