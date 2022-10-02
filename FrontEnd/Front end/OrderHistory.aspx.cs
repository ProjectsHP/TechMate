using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string dispOrder = "";
            if (Session["LoggedUser"] != null)
            {
                string userId = Session["LoggedUser"].ToString();
                dynamic orders = SRef.FetchAllUserOrdersSOAP(userId);
                var loggedUser = SRef.FetchActiveUserSOAP(userId);
       
            
                
                if(orders != null)
                {
                    int count = 1;
                    foreach (Order o in orders)
                    {
                        dispOrder += "<div class='product'>";
                        dispOrder += "<div class='product-price'>"+count+"</div>";
                        dispOrder += "<div class='product-price''>"+o.Id+"</div>";
                        dispOrder += "<div class='product-price'>mmm</div>";
                        dispOrder += "<div class='product-price'>"+o.dateCreated+"</div>";
                        dispOrder += "<div class='product-price'>R23000</div>";
                        dispOrder += "<div class='product-price'>5</div>";
                        dispOrder += "<div class='product-price'>Confirmed</div>";
                        dispOrder += "<div class='product-price'>";
                        dispOrder += "<a href='ProofOfPurchase.aspx?orderId=" + o.Id + "'>View order</a>";
                        dispOrder += "</div>";
                        dispOrder += "</div>";
                        count++;

                    }
                    orderHistory.InnerHtml = dispOrder;
                }
               
            }

        }
    }
}