using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class tryUser : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

          
            updtStock.Visible = false;
            string dispComp = "";
            string dispD = "";
            string dispRec = "";
            string product_id = "";
            if (Request.QueryString["pId"] != null)
            {
                product_id = Request.QueryString["pId"].ToString();
                var component = SRef.FetchComponentSOAP(product_id);
                dynamic recommended = SRef.FetchTopComponentsSOAP(component.category, "4");
                if (component != null)
                {
                    dispD = component.description;
                    dispComp += "<div class='col-md-5 col-xs-12 text-center'>";
                    dispComp += "<img alt='Leonardo Bonucci' src='Content/images/products/components/" + component.image + "'>";
                    dispComp += "</div>";
                    dispComp += "<div class='teacher_info col-md-7 col-xs-12'>";
                    dispComp += "<h4>" + component.name + "<em>R" + component.price + "</em></h4>";
                    dispComp += "<p>" + component.availability + " items left</p>";
                    dispComp += "<div class='teach_sumarry'>";
                    dispComp += "<h5>Description:</h5>";
                    dispComp += "<p>" + component.description + "</p>";
                    dispComp += "</div>";
                    dispComp += "<div class='course_tags'>";
                    dispComp += "<ul>";
                    dispComp += "<li>";
                    dispComp += "<a href='Cart.aspx?pId=" + component.Id + "'>Add to cart</a>";
                    dispComp += "<a href='BuildComputer.aspx?" + component.category + "_build=" + component.Id + "'>Add to build</a>";
                    if (Session["UserType"] != null)
                    {
                       if (Session["UserType"].ToString() =="Admin")
                       {
                        dispComp += "<a href='EditComponent.aspx?compId="+component.Id+"'>Update component </a>";
                       }
                       /* if (Session["UserType"].ToString() == "Manager")
                        {
                            dispComp += "<a href='javascript:controlStockUpdateVisibility();'>Update stock </a>";

                        }*/
                    }
                    dispComp += "</li>";
                    dispComp += "</ul>";
                    dispComp += "</div>";
                    dispComp += "</div>";
                }

                if (recommended != null)
                {

                    foreach (Component rec in recommended)
                    {

                        //displaying 5 recommended items
                        dispRec += "<li>";
                        dispRec += "<div class='tutor_img'>";
                        dispRec += "<img alt='Alaxander Louise' src='Content/images/products/components/" + rec.image + "'>";
                        dispRec += "</div>";
                        dispRec += "<div class='tutor_info'>";
                        dispRec += "<h5>";
                        dispRec += "<a href='SingleProduct.aspx?pid=" + rec.Id + "'>" + rec.name + "</a>";
                        dispRec += "<em>R" + rec.price + "</em>";
                        dispRec += "</h5>";
                        dispRec += "</div>";
                        dispRec += "</li>";

                    }
                    recList.InnerHtml = dispRec;
                }




            }


            dispProduct.InnerHtml = dispComp;
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "Manager")
                {
                    updtStock.Visible = true;
                }

            }


                //dispDescr.InnerText = dispD;

            }

        }

        protected void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["pId"] != null)
            {
                string pId = Request.QueryString["pId"].ToString();

                int response = SRef.UpdateStockSOAP(pId, selectType.Value, stockCount.Value);
                if(response == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully updated component stock count')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! could not update stock')", true);

                }

            }
        }
    }

}