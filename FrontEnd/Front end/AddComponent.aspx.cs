using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Front_end
{
    public partial class AddComponent : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (imgLoader == null)
            {
                componentImage.Src = "Content/images/fancybox/noImage.png";
            }

        }

        protected void btnAddComp_Click(object sender, EventArgs e)
        {
           
            int result = SRef.CreateComponentSOAP(txtName.Value, txtPrice.Value, txtQuantity.Value, txtDescription.Value, imgLoader.FileName.ToString(), txtType.Value, txtCompatibility.Value);
            if(result == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully added component to stock')", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your build is not complete, please select a base desktop.')", true);

            }


        }

     
    }
}