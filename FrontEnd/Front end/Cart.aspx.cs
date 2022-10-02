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
        dynamic getCartList = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

           
            string dispComp = "";
            var cartList = new List<Component>();
            if (Session["LoggedUser"]!=null && Session["ActiveBuild"] != null)
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
                        Session["CartTotalPrice"] = totCart;
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
                    dispComp += "<div class='totals-value' id='cart-shipping'>60</div>";
                    dispComp += "</div>";
                    dispComp += "<div class='totals-item totals-item-total'>";
                    dispComp += "<label>Grand Total</label>";
                    dispComp += "<div class='totals-value' id='cart-total'>"+totCart+"</div>";
                    dispComp += "</div>";
                    dispComp += "</div>";

                    cartBuild.InnerHtml = dispComp;

                }

            }
            else if(Session["LoggedUser"]!=null && Request.QueryString["pId"] != null )
            {
                string uId = Session["LoggedUser"].ToString();
                string pId = Request.QueryString["pId"].ToString();

               
                    if (Session["ActiveCartList"] != null)
                    {
                        cartList  = (List<Component>)Session["ActiveCartList"];
                        var singleComponent = SRef.FetchComponentSOAP(pId);
                        cartList.Add(singleComponent);
                        Session["ActiveCartList"] =cartList;
                    }
                    else
                    {
                        //*********first component. only visit once
                        var singleComponent = SRef.FetchComponentSOAP(pId);
                        cartList.Add(singleComponent);
                        Session["ActiveCartList"] = cartList;
                    }
                 
                    int tax = 0;
                int price = 0;
             
                foreach(Component item in cartList)
                {
                  var c= SRef.FetchComponentSOAP(item.Id.ToString());
                    if (c != null)
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

                }

                tax = (int)(price * 0.05);
                int totCart = tax + price + 40;
                    Session["CartTotalPrice"] = totCart;
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
               
                getCartList = cartList;

                cartBuild.InnerHtml = dispComp;


            
            }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int returnVal = 0;
            if (Session["LoggedUser"] != null)
            {
                string userID = Session["LoggedUser"].ToString();
                string totalPrice = Session["CartTotalPrice"].ToString();
                Session.Remove("CartTotalPrice");

                if (Session["ActiveBuild"] != null)
                {
                    string buildID = Session["ActiveBuild"].ToString();
                    
                    Session["ListOfItemsToCheckout"] = build;
                  int activeCartId = SRef.SaveCartSOAP(userID, buildID, totalPrice, "0");
                    if (activeCartId > 0)
                    {
                        foreach (Component c in build)
                        {
                          returnVal =  SRef.SaveCartItemsSOAP(c.Id.ToString(), activeCartId.ToString(), "1");
                     
                        }
                        if (returnVal == 1)
                        {
                            Session["ActiveCartId"] = activeCartId.ToString();
                            Response.Redirect("ConfirmOrder.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! Failed to save item into cart')", true);

                        }

                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! Failed to save your cart')", true);


                }
                else if(Session["ActiveCartList"] !=null)
                {
                   int activeCartId = SRef.SaveCartSOAP(userID, "-1", totalPrice, "0");
                    if(activeCartId > 0)
                    {
                        getCartList = (List<Component>)Session["ActiveCartList"];
                        Session["ListOfItemsToCheckout"] = getCartList;

                        foreach(Component c in getCartList)
                        {
                            SRef.SaveCartItemsSOAP(c.Id.ToString(), activeCartId.ToString(), "1");

                        }

                        Session["ActiveCartId"] = activeCartId.ToString();
                        Response.Redirect("ConfirmOrder.aspx");

                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! Failed to save your cart')", true);


                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please login to continue')", true);




            }
        }
    }
}