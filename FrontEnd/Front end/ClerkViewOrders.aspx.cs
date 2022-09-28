using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class ClerkViewOrders : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string dispOrder = "";
            if (Session["LoggedUser"]!=null)
            {

                string userId  = Session["LoggedUser"].ToString();
                dynamic orders = SRef.FetchAllOrdersSOAP("");
                var loggedUser = SRef.FetchActiveUserSOAP(userId);
                if (orders != null)
                {
                    int count = 1;
                    foreach (Order o in orders)
                    {
                        
                        dispOrder += "<div class='product'>";
                        dispOrder += "<div class='product-price'>" + count + "</div>";
                        dispOrder += "<div class='product-price''>" + o.Id + "</div>";
                        dispOrder += "<div class='product-price'>Build</div>";
                        dispOrder += "<div class='product-price'>" + o.dateCreated + "</div>";
                        dispOrder += "<div class='product-price'>" + loggedUser.name + " " + loggedUser.surname + "</div>";
                        dispOrder += "<div class='product-price'>R2300</div>";
                        if (o.orderStatus == "Approved")
                        {
                            dispOrder += "<div class='product-price' style='color:green'>" + o.orderStatus + "</div>";
                        }else if (o.orderStatus == "Rejected")
                        {
                            dispOrder += "<div class='product-price' style='color:orangered'>" + o.orderStatus + "</div>";
                        }
                        else
                        {
                            dispOrder += "<div class='product-price'>" + o.orderStatus + "</div>";

                        }

                        dispOrder += "<div class='product-price'>";
                        dispOrder += "<a href='ClerkManageOrders.aspx?mngOrderId=" + o.Id + "'>Manage order</a>";
                        dispOrder +="</div>";
                        dispOrder += "</div>";

                        count++;

                    }
                    orderClerk.InnerHtml = dispOrder;
                }
              
            }


        }
    }
}