using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class ClerkManageOrders : System.Web.UI.Page
    {

        ServiceClient SRef = new ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string dispOrder = "";
            if (Request.QueryString["mngOrderId"] != null)
            {

                string oId = Request.QueryString["mngOrderId"].ToString();
                var activeOrder = SRef.FetchOrderByIdSOAP(oId);
                if(activeOrder != null)
                {
                    string userId = activeOrder.userId.ToString();
                    string orderId  =activeOrder.Id.ToString();
                    var orderDet = SRef.FetchOrderSOAP(userId, orderId, "-1");
                                     
                    if (orderDet != null)
                    {
                        int count = 1;


                        foreach (Component item in orderDet.ListOfComponents)
                        {
                            dispOrder += "<div class='product'>";
                            dispOrder += "<div class='product-price'>" + count + "</div>";
                            dispOrder += "<div class='product-price'>" + item.Id + "</div>";
                            dispOrder += "<div class='product-price''>" + item.category + "</div>";
                            dispOrder += "<div class='product-price'>R"+item.price+"</div>";
                            dispOrder += "<div class='product-price'>" + item.compatibility + "</div>";
                            if (item.availability == "0")
                            {
                                dispOrder += "<div class='product-price'>Out of stock</div>";
                            }
                            else
                            {
                                dispOrder += "<div class='product-price'>In stock</div>";
                            }
                            dispOrder += "<div class='product-price'>"+item.name+"</div>";
                            dispOrder += "</div>";

                            count++;
                        }

                        compsLabels.InnerHtml = dispOrder;
                    }

                }
             
               

            }

        }

        protected void btnFulfilOrder_Click(object sender, EventArgs e)
        {
            bool isRunning = true;
            if (Request.QueryString["mngOrderId"] != null)
            {
                string orderId = Request.QueryString["mngOrderId"].ToString();
                int orderResponse = SRef.FulfilOrderSOAP(orderId);
                if(orderResponse == 1 && Session["LoggedUser"]!=null)
                {

                    //Update stock levels here
                    string uId = Session["LoggedUser"].ToString();
                    var myOrder =  SRef.FetchOrderSOAP(uId,orderId,"223");

                    if(myOrder != null)
                    {
                        foreach(Component c in myOrder.ListOfComponents)
                        {
                           int update = SRef.UpdateStockSOAP(c.Id.ToString(), "Decrease", "1");
                            if(update != 1)
                            {
                                isRunning = false;
                            }
                        }
                    }
                    if (isRunning)
                    {
                        Response.Redirect("ClerkViewOrders.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! could not find order')", true);

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! could not fulfil order please try again ')", true);

            }
        }

        protected void btnRejectOrder_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["mngOrderId"] != null)
            {
                string orderId = Request.QueryString["mngOrderId"].ToString();
                int orderResponse = SRef.RejectOrderSOAP(orderId, txtRejectReason.Value);
                if (orderResponse == 1)
                {
                    Response.Redirect("ClerkViewOrders.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! could not reject order please try again ')", true);

            }
        }

       
    }
}