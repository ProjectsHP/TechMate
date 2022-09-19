using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class ProofOfPurchase : System.Web.UI.Page
    {

        ServiceClient SRef = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string dispBilledTo = "";
            string shippedTo = "";
            string dispPayment = "";
            string dispDate = "";
            string dispCart = "";
            var order = SRef.FetchOrderSOAP("2", "1", "10101010");

            if (order != null)
            {
                orderNumber.InnerText = "Order #" + Convert.ToString(order.OrderId);



                dispBilledTo += "<address>";
                dispBilledTo += "<strong> Billed To:</strong><br>";
                dispBilledTo += "Twitter, Inc.<br>";
                dispBilledTo += "795 Folsom Ave, Suite 600 <br>";
                dispBilledTo += "San Francisco, CA 94107 <br>";
                dispBilledTo += "<abbr title='Phone'> P:</abbr>";
                dispBilledTo += "(123) 456 - 7890";
                dispBilledTo += "</address>";
            }





        }
    }
}