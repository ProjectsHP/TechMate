<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProofOfPurchase.aspx.cs" Inherits="Front_end.ProofOfPurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content_wrapper">
        <div id="dtl_wrap" class="dtl_wrap">

            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="grid invoice">
                            <div class="grid-body">
                                <div class="invoice-title">

                                    <br />
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <h2>invoice<br />
                                                <span class="small" id="orderNumber" runat="server">order #1082</span></h2>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-xs-6" id="billedTo" runat="server">
                                      
                                    </div>
                                    <div class="col-xs-6 text-right">
                                        <address>
                                            <strong>Shipped To:</strong><br>
                                            Elaine Hernandez<br>
                                            P. Sherman 42,<br>
                                            Wallaby Way, Sidney<br>
                                            <abbr title="Phone">P:</abbr>
                                            (123) 345-6789
                                        </address>
                                    </div>
                                </div>
                                <div class="row">
                                    <div style="margin: 20px 0">
                                        <div class="col-xs-6">
                                            <address>
                                                <strong>Payment Method:</strong><br>
                                                Visa ending **** 1234<br>
                                                h.elaine@gmail.com<br>
                                            </address>
                                        </div>
                                        <div class="col-xs-6 text-right">
                                            <address>
                                                <strong>Order Date:</strong><br>
                                                17/06/14
                                            </address>
                                        </div>
    </div>
    </div>
                                <div class="row">
                                    <div class="col-md-12">

                                        <div style="margin-top: 30px">
                                            <h1>ORDER SUMMARY</h1>
                                        </div>


                                        <div class="column-labels">
                                            <label class="product-image">Image</label>
                                            <label class="product-details">Product</label>
                                            <label class="product-price">Price</label>
                                            <label class="product-quantity">Quantity</label>
                                            <label class="product-line-price">Total</label>
                                        </div>

                                        <div class="product">
                                            <div class="product-image">
                                                <img src="https://s.cdpn.io/3/dingo-dog-bones.jpg">
                                            </div>
                                            <div class="product-details">
                                                <div class="product-title">Dingo Dog Bones</div>
                                                <p class="product-description">The best dog bones of all time. Holy crap. Your dog will be begging for these things! I got curious once and ate one myself. I'm a fan.</p>
                                            </div>
                                            <div class="product-price">12.99</div>
                                            <div class="product-quantity">
                                                <div class="product-price">12.99</div>
                                            </div>
                                            <div class="product-line-price">25.98</div>
                                        </div>

                                        <div class="product">
                                            <div class="product-image">
                                                <img src="https://s.cdpn.io/3/large-NutroNaturalChoiceAdultLambMealandRiceDryDogFood.png">
                                            </div>
                                            <div class="product-details">
                                                <div class="product-title">Nutro™ Adult Lamb and Rice Dog Food</div>
                                                <p class="product-description">Who doesn't like lamb and rice? We've all hit the halal cart at 3am while quasi-blackout after a night of binge drinking in Manhattan. Now it's your dog's turn!</p>
                                            </div>
                                            <div class="product-price">45.99</div>
                                            <div class="product-quantity">
                                                <div class="product-price">45.99</div>
                                            </div>

                                            <div class="product-line-price">45.99</div>
                                        </div>

                                        <div class="product">
                                            <div class="product-image">
                                                <img src="https://s.cdpn.io/3/dingo-dog-bones.jpg">
                                            </div>
                                            <div class="product-details">
                                                <div class="product-title">Dingo Dog Bones</div>
                                                <p class="product-description">The best dog bones of all time. Holy crap. Your dog will be begging for these things! I got curious once and ate one myself. I'm a fan.</p>
                                            </div>
                                            <div class="product-price">12.99</div>
                                            <div class="product-quantity">
                                                <div class="product-price">12.99</div>
                                            </div>

                                            <div class="product-line-price">25.98</div>
                                        </div>

                                        <div class="product">
                                            <div class="product-image">
                                                <img src="https://s.cdpn.io/3/large-NutroNaturalChoiceAdultLambMealandRiceDryDogFood.png">
                                            </div>
                                            <div class="product-details">
                                                <div class="product-title">Nutro™ Adult Lamb and Rice Dog Food</div>
                                                <p class="product-description">Who doesn't like lamb and rice? We've all hit the halal cart at 3am while quasi-blackout after a night of binge drinking in Manhattan. Now it's your dog's turn!</p>
                                            </div>
                                            <div class="product-price">45.99</div>
                                            <div class="product-quantity">
                                                <div class="product-price">45.99</div>
                                            </div>

                                            <div class="product-line-price">45.99</div>
                                        </div>

                                        <div class="totals">
                                            <div class="totals-item">
                                                <label>Subtotal</label>
                                                <div class="totals-value" id="cart-subtotal">71.97</div>
                                            </div>
                                            <div class="totals-item">
                                                <label>Vat(15%)</label>
                                                <div class="totals-value" id="cart-tax">3.60</div>
                                            </div>
                                            <div class="totals-item">
                                                <label>Shipping</label>
                                                <div class="totals-value" id="cart-shipping">15.00</div>
                                            </div>
                                            <div class="totals-item totals-item-total">
                                                <label>Grand Total</label>
                                                <div class="totals-value" id="cart-total">90.57</div>
                                            </div>
                                        </div>

                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>






                </div>
            </div>
        </div>


    </div>

</asp:Content>
