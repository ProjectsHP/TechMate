using Front_end.ServiceReference;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class Cart : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();
        dynamic build = null;
        dynamic getUserBuild = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dispComp = "";
            if(Session["LoggedUser"]!=null && Session["ActiveBuild"] != null)
            {
                string build_id = Session["ActiveBuild"].ToString();
                int tax = 0;
                build = SRef.FetchBuildSOAP(build_id);
                string normalPrice;
                int price=0;
                if (build != null)
                {

                    foreach(Component c in build)
                    {
                    normalPrice = c.price.Replace(" ","");
                        dispComp += "<div class='product'>";
                        dispComp += "<div class='product-image'>";
                        dispComp += "<img src='Content/images/products/components/"+c.image+"'>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-details'>";
                        dispComp += "<div class='product-title' style='font-weight:bold'>" + c.name+"</div>";
                        dispComp += "<p class='product-description'>"+c.description+"</p>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-price'>"+normalPrice+"</div>";
                        dispComp += "<div class='product-quantity'>";
                        dispComp += "<input type='number' value='1' min='1'>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-removal'>";
                        dispComp += "<button class='remove-product'>";
                        dispComp += "Remove";
                        dispComp += "</button>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-line-price'>"+normalPrice+ "</div>";
                        dispComp += "</div>";
                    price += Convert.ToInt32(normalPrice);

                    }
                    tax = (int)(price * 0.05);
                    int totCart = tax + price + 40;
                    dispComp += "<div class='totals'>";
                    dispComp += "<div class='totals-item'>";
                    dispComp += "<label>Subtotal</label>";
                    dispComp += "<div class='totals-value' id='cart-subtotal'>"+price+"</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='totals-item'>";
                    dispComp += "<label>Tax(5%)</label>";
                    dispComp += "<div class='totals-value' id='cart-tax'>"+tax+"</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='totals-item'>";
                    dispComp += "<label>Shipping</label>";
                    dispComp += "<div class='totals-value' id='cart-shipping'>40</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='totals-item totals-item-total'>";
                    dispComp += "<label>Grand Total</label>";
                    dispComp += "<div class='totals-value' id='cart-total'>"+totCart+"</div>";
                    dispComp += "</div>";
                    dispComp += "</div>";

                    cartBuild.InnerHtml = dispComp;

                }

            }
            else if(Session["LoggedUser"]!=null)
            {

                string uId = Session["LoggedUser"].ToString();
                 getUserBuild = SRef.FetchSingleUserBuildSOAP(uId);
                if (getUserBuild != null)
                {
                    int tax = 0;
                    int price = 0;
                    foreach (Component c in getUserBuild)
                    {
                        
                        dispComp += "<div class='product'>";
                        dispComp += "<div class='product-image'>";
                        dispComp += "<img src='Content/images/products/components/" + c.image + "'>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-details'>";
                        dispComp += "<div class='product-title' style='font-weight:bold'>" + c.name + "</div>";
                        dispComp += "<p class='product-description'>" + c.description + "</p>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-price'>" + c.intPriceFormat + "</div>";
                        dispComp += "<div class='product-quantity'>";
                        dispComp += "<input type='number' value='1' min='1'>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-removal'>";
                        dispComp += "<button class='remove-product'>";
                        dispComp += "Remove";
                        dispComp += "</button>";
                        dispComp += "</div>";
                        dispComp += "<div class='product-line-price'>" + c.intPriceFormat + "</div>";
                        dispComp += "</div>";
                        price += Convert.ToInt32(c.intPriceFormat);

                    }
                    tax = (int)(price * 0.05);
                    int totCart = tax + price + 40;
                    dispComp += "<div class='totals'>";
                    dispComp += "<div class='totals-item'>";
                    dispComp += "<label>Subtotal</label>";
                    dispComp += "<div class='totals-value' id='cart-subtotal'>" + price + "</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='totals-item'>";
                    dispComp += "<label>Tax(5%)</label>";
                    dispComp += "<div class='totals-value' id='cart-tax'>" + tax + "</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='totals-item'>";
                    dispComp += "<label>Shipping</label>";
                    dispComp += "<div class='totals-value' id='cart-shipping'>40</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='totals-item totals-item-total'>";
                    dispComp += "<label>Grand Total</label>";
                    dispComp += "<div class='totals-value' id='cart-total'>" + totCart + "</div>";
                    dispComp += "</div>";
                    dispComp += "</div>";

                    cartBuild.InnerHtml = dispComp;
                }
            }
            
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

            if (Session["ActiveBuild"] != null)
            {
                Session["ListOfItemsToCheckout"] = build;
                Response.Redirect("ConfirmOrder.aspx");
            }
            else
            {
                Session["ListOfItemsToCheckout"] = getUserBuild;
                Response.Redirect("ConfirmOrder.aspx");
            }
           

 
        }
    }
}