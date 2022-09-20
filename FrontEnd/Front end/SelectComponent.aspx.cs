using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class SelectComponent : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string filterCategory="";
            dynamic comps = null;
            if (Request.QueryString["category"] != null)
            {
                filterCategory = Request.QueryString["category"].ToString();
                comps = SRef.FetchComponentsByCategorySOAP(filterCategory);

            }

            string dispComp = "";
            if (comps != null)
            {
                foreach (Component comp in comps)
                {
                    dispComp += "<div class='col-lg-4 col-md-4 col-sm-6 col-xs-12'>";
                    dispComp += "<div class='course_block'>";
                    dispComp += "<div class='img_wrap'>";
                    dispComp += "<img alt='Science' src='Content/images/products/components/" + comp.image + "' style='width:335px; height:180px'>";
                    dispComp += "<div class='course_img_hoverlay_btn'><a href='SingleProduct.aspx?pId="+comp.Id+"' title='View More' class='fa fa-eye'></a></div>";
                    dispComp += "</div>";
                    dispComp += "<div class='science'>";
                    dispComp += "<div class='icon'><a href='BuildComputer.aspx?" + comp.category + "_build=" + comp.Id + "' title='Add to cart' class='fa fa-shopping-cart'></a></div>";
                    // dispComp += "<div class='icon'><i class='fas fa-shopping-cart' title='Add to cart'></i></div>";
                    dispComp += "<div class='course_info'>";
                    dispComp += "<h4>" + comp.name + "</h4>";
                    dispComp += "<p>" + comp.description + "</p>";
                    dispComp += "</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='science course_count_wrap'>";
                    dispComp += "<div class='course_count'>";
                    if (comp.availability == "0")
                    {
                        dispComp += "Out of Stock: <span>" + comp.availability + "</span>";
                    }
                    else
                    {
                        dispComp += "In Stock: <span>" + comp.availability + "</span>";
                    }
                    dispComp += "</div>";
                    dispComp += "<div class='course_price'>";
                    dispComp += "Price: <span>R" + comp.price + "</span>";
                    dispComp += "</div>";
                    dispComp += "</div>";
                    dispComp += "</div>";
                    dispComp += "</div>";


                }


            }


            headerProd.InnerText = "Popular "+filterCategory;
            listComps.InnerHtml = dispComp;
        }
    }
}