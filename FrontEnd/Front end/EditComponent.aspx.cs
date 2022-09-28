using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class EditComponent : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();
        bool compFound = true;
        bool duplicateFound = false;
     
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (duplicateFound == true)
            {
                duplicateSearch.Visible = true;
                compDet.Visible = false;
            }

            if (Request.QueryString["compId"] != null)
            {
                string id = Request.QueryString["compId"].ToString();
                Session["ActiveComp"] = id;
                duplicateFound = false;
                duplicateSearch.Visible = false;
                compDet.Visible = true;
                var com = SRef.FetchComponentSOAP(id);
                if (com != null)
                {
                    dispImg.Src = "Content/images/products/components/" + com.image;
                    txtNameEDIT.Value = com.name;
                    txtPriceEDIT.Value = com.price;
                    txtTypeEDIT.Value = com.category;
                    txtCompatibilityEDIT.Value = com.compatibility;
                    txtDescription.Value = com.description;
                    txtQuantityEDIT.Value = com.availability;
                    compFound = true;
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Component> compList = new List<Component>();
            dynamic component = SRef.FetchSingleComponentByImageSOAP(fileUploadImage.FileName);
            if (component != null)
            {

               
                    string dispTable = "";
                    int count = 1;
                    foreach (Component c in component)
                    {
                        compList.Add(c);
                        dispTable += "<div class='product'>";
                        dispTable += "<div class='product-price'>" + count + "</div>";
                        dispTable += "<div class='product-price''>" + c.Id + "</div>";
                        dispTable += "<div class='product-price'>" + c.category + "</div>";
                        dispTable += "<div class='product-price'>" + c.price + "</div>";
                        dispTable += "<div class='product-price'>" + c.availability + "</div>";
                        dispTable += "<div class='product-price'>" + c.compatibility + "</div>";
                        dispTable += "<div class='product-price' style='width:20%'>" + c.name + "</div>";
                        dispTable += "</div>";
                        count++;
                   
                    }

                    if (compList.Count <= 1)
                    {

                        duplicateSearch.Visible = false;
                        compDet.Visible = true;
                        Component com = compList.ElementAt(0);

                        dispImg.Src = "Content/images/products/components/" + com.image;
                        txtNameEDIT.Value = com.name;
                        txtPriceEDIT.Value = com.price;
                        txtTypeEDIT.Value = com.category;
                        txtCompatibilityEDIT.Value = com.compatibility;
                        txtDescription.Value = com.description;
                        txtQuantityEDIT.Value = com.availability;
                        compFound = true;
                        Session["ActiveComp"] = com.Id.ToString();
                
                        duplicateFound = false;
                    }
                    else
                    {

                      duplicateFound = true;
                      duplicateSearch.Visible = true;
                      compDet.Visible = false;

                       compsLabels.InnerHtml = dispTable;
                    }
        

            }
            else
            {
                compFound = false;
              
            }
            


        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            if (!CheckBox1.Checked)
            {

          
            if (compFound == true)
            {
                int compResponse = -10;
                string id = "";
               if(Session["ActiveComp"]!=null)
                {
                    id= Session["ActiveComp"].ToString();
                    compResponse = SRef.EditComponentSOAP(id, txtNameEDIT.Value, txtPriceEDIT.Value, txtQuantityEDIT.Value,
                                               txtDescription.Value, fileUploadImage.FileName, txtTypeEDIT.Value,
                                               txtCompatibilityEDIT.Value);
                }
               
               
                if(compResponse == 1)
                {
                    Session.Remove("ActiveComp");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully updated component.')", true);
                    

                }
                else if(compResponse == 0)
                {
                    Session.Remove("ActiveComp");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occured! component not found')", true);

                }
                else
                {
                    Session.Remove("ActiveComp");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occured! please try again')", true);

                }
            }

            }
            else
            {
                if (Session["ActiveComp"] != null)
                {

                string id = Session["ActiveComp"].ToString();
                int resp = SRef.DeleteComponentSOAP(id);
                if(resp == 1)
                {
                    dispImg.Src = "Content/images/fancybox/no_Image.png";
                    txtNameEDIT.Value = "";
                    txtPriceEDIT.Value = "";
                    txtTypeEDIT.Value = "";
                    txtCompatibilityEDIT.Value = "";
                    txtDescription.Value = "";
                    txtQuantityEDIT.Value = "";
                    Session.Remove("ActiveComp");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted successfully')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occured')", true);

                }
                }
            }

        }

        protected void btnSearchById_Click(object sender, EventArgs e)
        {
            var c = SRef.FetchComponentSOAP(txtSearchId.Value);
            if (c != null)
            {
               Session["ActiveComp"] = txtSearchId.Value;
                compDet.Visible = true;
                duplicateSearch.Visible = false;
                dispImg.Src = "Content/images/products/components/" + c.image;
                txtNameEDIT.Value = c.name;
                txtPriceEDIT.Value = c.price;
                txtTypeEDIT.Value = c.category;
                txtCompatibilityEDIT.Value = c.compatibility;
                txtDescription.Value = c.description;
                txtQuantityEDIT.Value = c.availability;
                
            }
        }
    }
}