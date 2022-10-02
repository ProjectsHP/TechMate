<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="Front_end.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content_wrapper">
        
        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>My orders</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                        <li>My orders</li>
                    </ul>
                </div>
            </div>
        </div>


         <div id="dtl_wrap" class="dtl_wrap">

            <div class="container">

     

                <div class="column-labels">
                   
                   
                        <label class="product-price">#</label>
                        <label class="product-price">Order Id</label>
                        <label class="product-price">Order Type</label>
                        <label class="product-price">Date Created</label>
                        <label class="product-price">Total Price</label>
                        <label class="product-price">Total Items</label>
                        <label class="product-price">Status</label>
                     <label class="product-price"></label>
                 
                </div>

                <div id="orderHistory" runat="server">

                     
                   
                </div>

                
                

            </div>
        </div>


    </div>

</asp:Content>
