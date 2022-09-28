<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ClerkViewOrders.aspx.cs" Inherits="Front_end.ClerkViewOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content_wrapper">

        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Orders</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                        <li><a href="Clerk.aspx">Home </a>/</li>
                        <li>Orders</li>
                    </ul>
                </div>
            </div>
        </div>



        <div id="contact_wrap" class="contact_wrap">

            <div class="container">
             <h2>All orders</h2>
                    view and manage customers orders till date
                    <br />
                    <br />
            <div class="column-labels">
                   
                   
                        <label class="product-price">#</label>
                        <label class="product-price">Order Id</label>
                        <label class="product-price">Order Type</label>
                        <label class="product-price">Date Created</label>
                        <label class="product-price">Customer</label>
                        <label class="product-price">Total Price</label>
                        <label class="product-price">Status</label>
                        <label class="product-price">Action</label>
                 
                </div>

                <div id="orderClerk" runat="server">

                     
                   
                </div>



            </div>
        </div>


    </div>

</asp:Content>
