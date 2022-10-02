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
    public partial class ConfirmOrder : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();
        int totalPrice = 0;
        List<Component> listOfItems = new List<Component>();
      

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["ListOfItemsToCheckout"] != null)
            {

                string dispList = "";
                string dispSummary = "";
                dynamic itemsList = (List<Component>)Session["ListOfItemsToCheckout"];



                foreach (Component item in itemsList)
                {
                    dispList += "<li>";
                    dispList += "<div class='tutor_img'>";
                    dispList += "<img alt='Alaxander Louise' src='Content/images/products/components/" + item.image + "'>";
                    dispList += "</div>";
                    dispList += "<div class='tutor_info'>";
                    dispList += "<h5>";
                    dispList += "<a href='SingleProduct.aspx?pid=" + item.Id + "'>" + item.name + "</a>";
                    dispList += "<em>R" + item.price + "</em>";
                    dispList += "</h5>";
                    dispList += "</div>";
                    dispList += "</li>";
                    listOfItems.Add(item);
                    totalPrice += item.intPriceFormat.Value;

                }
                showCartList.InnerHtml = dispList;

                double vat = (15 / 100) * totalPrice;
                int orderTotal = (int)(vat + totalPrice + 60);


                dispSummary += "<li><span class='hookup_tag'>Items</span><span class='hookup_duration'>" + listOfItems.Count + "</span></li>";
                dispSummary += "<li><span class='hookup_tag'>Subtotal</span><span class='hookup_duration'>R" + totalPrice + "</span></li>";
                dispSummary += "<li><span class='hookup_tag'>Vat(15%)</span><span class='hookup_duration'>R" + vat + "</span></li>";
                dispSummary += "<li><span class='ookup_tag'>Shipping</span><span class='hookup_duration'>R60</span></li>";
                dispSummary += "<li><span class='hookup_tag'>Grand Total</span><span class='hookup_duration'>R" + orderTotal + "</span></li>";

                dispOrderSummary.InnerHtml = dispSummary;
            }
        }

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (Session["LoggedUser"] != null)
            {
                string user_id = Session["LoggedUser"].ToString();


                if (Session["ListOfItemsToCheckout"] != null)
                {
                  int addressResponse =  SRef.StoreUserAddressSOAP(user_id, txtCountry.Value, txtProvince.Value, txtCity.Value,
                                               txtStreetUnit.Value, txtOrderName.Value, txtOrderSurname.Value,txtOrderContact.Value, txtOrderEmail.Value);
                    if(addressResponse > 0)
                    {


                        string activeCartId = "-1";
                        string AddrId = addressResponse.ToString();
                        if (Session["ActiveCartId"] != null)
                        {
                            activeCartId = Session["ActiveCartId"].ToString();

                           int orderId = SRef.SaveOrderSOAP(activeCartId, AddrId, user_id);
                            if(orderId > 0)
                            {
                                Session["ActiveOrderId"] = orderId.ToString();
                                Session["ActiveContacts"] = txtOrderContact.Value;
                                Session["ActiveEmail"] = txtOrderEmail.Value;
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank you, your order has been placed.')", true);
                                Response.Redirect("ProofOfPurchase.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! internal error please try again')", true);

                            }

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error saving user address, please try again.')", true);

                    }


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cart is empty!')", true);

                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please sign in to continue with your order')", true);

            }


        }

    }
}