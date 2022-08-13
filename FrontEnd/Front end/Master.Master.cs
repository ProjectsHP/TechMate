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
            liContactUs.Visible = false;
            liProfile.Visible = false;
            liReports.Visible = false;
            if (Session["LoggedUser"] == null)
            {
                liLogout.Visible = false;
                liLogin.Visible = true;
            }
            else
            {
                if (Session["UserType"]=="Admin")
                {
                    liContactUs.Visible = false;
                    liReports.Visible = true;

                }
                liLogout.Visible = true;
                liLogin.Visible=false;
                liProfile.Visible = true;
            }
        }
    }
}