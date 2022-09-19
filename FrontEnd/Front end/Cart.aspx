<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Front_end.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link rel="stylesheet" type="text/css" href="Content/css/cartCSS.scss" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content_wrapper">
          <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Cart</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a> /</li>
                        <li>Cart</li>
                    </ul>
                </div>
            </div>
        </div>


        <div id="dtl_wrap" class="dtl_wrap">

            <div class="container">

     

                <div class="column-labels">
                    <label class="product-image">Image</label>
                    <label class="product-details">Product</label>
                    <label class="product-price">Price</label>
                    <label class="product-quantity">Quantity</label>
                    <label class="product-removal">Remove</label>
                    <label class="product-line-price">Total</label>
                </div>

                <div id="cartBuild" runat="server">

               

                </div>
                

                <%-- <button class="checkout">Checkout</button>--%>
               <asp:Button ID="btnCheckout" class="btn find_course_form_btn" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
             <%--   <a class="btn find_course_form_btn" href="Home.aspx">Checkout</a>--%>
            </div>
        </div>
    </div>
    <%--</div>--%>
</asp:Content>
