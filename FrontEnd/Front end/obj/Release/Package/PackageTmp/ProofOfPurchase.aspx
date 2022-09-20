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
                                        <%-- SHOW billled to--%>
                                    </div>

                                    <div class="col-xs-6 text-right" id="shippedTo" runat="server">
                                        <%-- SHOW shipped to--%>
                                    </div>
                                </div>
                                <div class="row">
                                    <div style="margin: 20px 0">
                                        <div class="col-xs-6" id="payMethod" runat="server">
                                                <%-- SHOW payment method to--%>
                                        </div>
                                        <div class="col-xs-6 text-right" id="orderDate" runat="server">
                                             <%-- SHOW date--%>
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
                                              <label class="product-removal">Remove</label>
                                               
                                        </div>

                                        <div id="cartProd" runat="server">

                                      <%--SHOW cart items--%>

                                            </div>
                                      
                                        <div class="totals" id="orderTots" runat="server">
                                            <div class="totals-item">
                                                <label>Subtotal</label>
                                                <div class="totals-value" id="Osubtotal" runat="server">71.97</div>
                                            </div>
                                            <div class="totals-item">
                                                <label>Vat(15%)</label>
                                                <div class="totals-value" id="Otax" runat="server">3.60</div>
                                            </div>
                                            <div class="totals-item">
                                                <label>Shipping</label>
                                                <div class="totals-value" id="Oshipping" runat="server">15.00</div>
                                            </div>
                                            <div class="totals-item totals-item-total">
                                                <label>Grand Total</label>
                                                <div class="totals-value" id="Ototal" runat="server">90.57</div>
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
