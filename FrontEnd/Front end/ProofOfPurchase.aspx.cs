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
       
            string userId="";
            string dispBilledTo = "";
            string dispShippedTo = "";
            string dispPayment = "";
            string dispDate = "";
            string dispCart = "";
            if (Session["LoggedUser"] != null)
            {
                userId = Session["LoggedUser"].ToString();


                if (Session["ActiveOrderId"] != null)
                {
                    string oId = Session["ActiveOrderId"].ToString();
                    var order = SRef.FetchOrderSOAP(userId, oId, "071");

                    if (order != null)
                    {
                        orderNumber.InnerText = "Order #" + Convert.ToString(order.OrderId);

                        dispBilledTo += "<address>";
                        dispBilledTo += "<strong> Billed To:</strong><br>";
                        dispBilledTo += "" + order.User.name + " " + order.User.surname + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.streetUnit + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.suburb + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.city + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.country + "<br>";
                        dispBilledTo += "</address>";

                        billedTo.InnerHtml = dispBilledTo;


                        dispShippedTo += "<address>";
                        dispShippedTo += "<strong>Shipped To:</strong><br>";
                        dispShippedTo += "" + order.User.name + " " + order.User.surname + "<br>";
                        dispShippedTo += "" + order.DeliveryAddress.streetUnit + "<br>";
                        dispShippedTo += "" + order.DeliveryAddress.suburb + ",<br>";
                        dispShippedTo += "" + order.DeliveryAddress.city + "," + order.DeliveryAddress.country + "<br>";
                        dispShippedTo += "<abbr title='Phone'> Phone: </abbr>";
                        dispShippedTo += order.User.cellNo;
                        dispShippedTo += "</address>";

                        shippedTo.InnerHtml = dispShippedTo;


                        dispPayment += "<address>";
                        dispPayment += "<strong> Payment Method:</strong><br>";
                        dispPayment += "Visa ending ****" + order.CardNumber + "<br>";
                        dispPayment += "" + order.User.email + "<br>";
                        dispPayment += "</address>";

                        payMethod.InnerHtml = dispPayment;


                        dispDate += "<address>";
                        dispDate += "<strong>Order Date:</strong><br>";
                        dispDate += order.OrderDate;
                        dispDate += "</address>";

                        orderDate.InnerHtml = dispDate;



                        foreach (Component items in order.ListOfComponents)
                        {

                            dispCart += "<div class='product'>";
                            dispCart += "<div class='product-image'>";
                            dispCart += "<img src='Content/images/products/components/" + items.image + "'>";
                            dispCart += "</div>";
                            dispCart += "<div class='product-details'>";
                            dispCart += "<div class='product-title' style='font-weight:bold'>" + items.name + "</div>";
                            dispCart += "<p class='product-description'>" + items.description + "</p>";
                            dispCart += "</div>";
                            dispCart += "<div class='product-price'>R" + items.intPriceFormat + "</div>";
                            dispCart += "<div class='product-quantity'>";
                            dispCart += "<div class='product-price'>1</div>";
                            dispCart += "</div>";
                            dispCart += "<div class='product-line-price'>" + items.intPriceFormat + "</div>";
                            dispCart += "</div>";
                        }

                        cartProd.InnerHtml = dispCart;
                        Osubtotal.InnerText = "R" + order.TotalPrice;
                        Otax.InnerText = "R" + 2300;
                        Oshipping.InnerText = "R60";
                        Ototal.InnerText = Convert.ToString(order.TotalPrice + 60);


                    }

                }
                else if(Request.QueryString["orderId"]!=null)
                {
                    string oId = Request.QueryString["orderId"].ToString();
                    var order = SRef.FetchOrderSOAP(userId, oId, "071");

                    if (order != null)
                    {
                        orderNumber.InnerText = "Order #" + Convert.ToString(order.OrderId);

                        dispBilledTo += "<address>";
                        dispBilledTo += "<strong> Billed To:</strong><br>";
                        dispBilledTo += "" + order.User.name + " " + order.User.surname + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.streetUnit + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.suburb + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.city + "<br>";
                        dispBilledTo += "" + order.DeliveryAddress.country + "<br>";
                        dispBilledTo += "</address>";

                        billedTo.InnerHtml = dispBilledTo;


                        dispShippedTo += "<address>";
                        dispShippedTo += "<strong>Shipped To:</strong><br>";
                        dispShippedTo += "" + order.User.name + " " + order.User.surname + "<br>";
                        dispShippedTo += "" + order.DeliveryAddress.streetUnit + "<br>";
                        dispShippedTo += "" + order.DeliveryAddress.suburb + ",<br>";
                        dispShippedTo += "" + order.DeliveryAddress.city + "," + order.DeliveryAddress.country + "<br>";
                        dispShippedTo += "<abbr title='Phone'> Phone: </abbr>";
                        dispShippedTo += order.User.cellNo;
                        dispShippedTo += "</address>";

                        shippedTo.InnerHtml = dispShippedTo;


                        dispPayment += "<address>";
                        dispPayment += "<strong> Payment Method:</strong><br>";
                        dispPayment += "Visa ending ****" + order.CardNumber + "<br>";
                        dispPayment += "" + order.User.email + "<br>";
                        dispPayment += "</address>";

                        payMethod.InnerHtml = dispPayment;


                        dispDate += "<address>";
                        dispDate += "<strong>Order Date:</strong><br>";
                        dispDate += order.OrderDate;
                        dispDate += "</address>";

                        orderDate.InnerHtml = dispDate;



                        foreach (Component items in order.ListOfComponents)
                        {

                            dispCart += "<div class='product'>";
                            dispCart += "<div class='product-image'>";
                            dispCart += "<img src='Content/images/products/components/" + items.image + "'>";
                            dispCart += "</div>";
                            dispCart += "<div class='product-details'>";
                            dispCart += "<div class='product-title' style='font-weight:bold'>" + items.name + "</div>";
                            dispCart += "<p class='product-description'>" + items.description + "</p>";
                            dispCart += "</div>";
                            dispCart += "<div class='product-price'>R" + items.intPriceFormat + "</div>";
                            dispCart += "<div class='product-quantity'>";
                            dispCart += "<div class='product-price'>1</div>";
                            dispCart += "</div>";
                            dispCart += "<div class='product-line-price'>" + items.intPriceFormat + "</div>";
                            dispCart += "</div>";
                        }

                        cartProd.InnerHtml = dispCart;
                        Osubtotal.InnerText = "R" + order.TotalPrice;
                        Otax.InnerText = "R" + 2300;
                        Oshipping.InnerText = "R60";
                        Ototal.InnerText = Convert.ToString(order.TotalPrice + 60);


                    }

                }




            }





        }
    }
}