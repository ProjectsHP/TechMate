using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class SingleProduct : System.Web.UI.Page
    {
        bool vis;
        ServiceClient SRef = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] != null)
            {
                string id = Session["LoggedUser"].ToString();
                string disp = "";
               
                var activeUser = SRef.FetchActiveUserSOAP(id);
                if(activeUser != null)
                {
                    disp ="<li><span class='tutor_info'><i class='fa fa-envelope'></i>"+activeUser.email+"</span></li>";
                    disp += "<li><span class='tutor_info'><i class='fa fa-phone'></i>+27 "+activeUser.cellNo+"</span></li>";
                    disp += "<li><span class='tutor_info'><i class='fa fa-skype'></i>leonardo.bonucci</span></li>";
                    disp += "<li><span class='tutor_info'><i class='fa fa-link'></i>www.learnmate.com</span></li>";
                    disp += "<li><span class='tutor_info'><i class='fa fa-map-marker'></i>Atlanta</span></li>";
                    disp += "<li><span class='tutor_info'><i class='fa fa-language'></i>English</span></li>";

                    viewBox.InnerHtml=disp;
                }


            }

            if (vis == true)
            {
                editBox.Visible = true;
                viewBox.Visible = false;
            }
            else
            {
                editBox.Visible = false;
                viewBox.Visible = true;
            }
          
        }

        protected void btnShowUpdate_Click(object sender, EventArgs e)
        {
            vis = true;
            //editBox.Visible = true;
            //viewBox.Visible = false;


            if (vis == true)
            {
                editBox.Visible = true;
                viewBox.Visible = false;
                btnShowUpdate.Enabled = false;
                vis = false;
            }
            else
            {
                editBox.Visible = false;
                viewBox.Visible = true;
                vis = true;
            }
        }

        protected void btnEditSubmit_Click(object sender, EventArgs e)
        {
            vis = false;
            if (Session["LoggedUser"] != null)
            {
                string cell = editContacts.Value;
                string id=Session["LoggedUser"].ToString();
                int editUser = SRef.EditUserSOAP(editName.Value, editSurname.Value, cell,editGender.Value, editEmail.Value, id);

                switch (editUser)
                {
                    case 1:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Profile Updated Successfully')", true);
                        break;
                    case -1:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Internal error: Failed to update profile, please try again')", true);
                        break;
                    case 0:
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: User cannot be found, please login')", true);
                        break;
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error: Please login')", true);

            }

            if (vis == true)
            {
                editBox.Visible = true;
                viewBox.Visible = false;
                vis = false;
            }
            else
            {
                editBox.Visible = false;
                viewBox.Visible = true;
                btnShowUpdate.Enabled=true;
               // vis = true;
            }
        }
    }
}