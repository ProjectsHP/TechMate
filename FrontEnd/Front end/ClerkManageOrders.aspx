<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ClerkManageOrders.aspx.cs" Inherits="Front_end.ClerkManageOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_wrapper">

        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Manage Order</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                        <li><a href="Clerk.aspx">Clerk </a>/</li>
                        <li><a href="ClerkViewOrders.aspx">View orders </a>/</li>
                        <li>Manage order</li>
                    </ul>
                </div>
            </div>
        </div>



        <div id="contact_wrap" class="contact_wrap">

            <div class="container">
                <div id="duplicateSearch" runat="server">
                    <h2>Pending order</h2>
                    This order is compatible with no issues. Ready to be finalized
                    <br />
                    <br />
                    <div class="column-labels">


                        <label class="product-price">#</label>
                        <label class="product-price">Component Id</label>
                        <label class="product-price">Category</label>
                        <label class="product-price">Price</label>
                        <label class="product-price">Compatibility</label>
                        <label class="product-price">Status</label>
                        <label class="product-price" style="width: 27%">Name</label>


                    </div>

                    <div id="compsLabels" runat="server">
                    </div>

                    <br />
                    <br />

                    <div class="form-group">
                        <label class="form-control-label" for="OReject">Fill ONLY IF order will be rejected</label>
                        <textarea class="form-control" id="txtRejectReason" name="OReject" type="text" rows="4" runat="server" placeholder="Summary of why order is rejected..."></textarea>
                    </div>

                    <asp:Button ID="btnFulfilOrder" runat="server" Text="Fulfil" OnClick="btnFulfilOrder_Click" />
                    <asp:Button ID="btnRejectOrder" runat="server" Text="Reject" OnClick="btnRejectOrder_Click" />
                    


                </div>

            </div>
        </div>

    </div>
</asp:Content>
