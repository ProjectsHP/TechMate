<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConfirmOrder.aspx.cs" Inherits="Front_end.ConfirmOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content_wrapper">

        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Confirm Order</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                        <li><a href="Cart.aspx">Cart </a>/</li>
                        <li>Confirm order</li>
                    </ul>
                </div>
            </div>
        </div>



        <div id="dtl_wrap" class="dtl_wrap">
            <div class="container">
                <div class="dtl_wrapper col-lg-9 col-md-8 col-sm-12 col-xs-12">


                    <div class="dtl_inner_wrap contact_form" style="background-color: whitesmoke; margin-top:0px">
                      

                       
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            <h3>Billing Address</h3>


                            <div class="form-group">
                                <label class="form-control-label" for="OStreet">Street unit</label>
                                <input name="OStreet" type="text" runat="server" id="txtStreetUnit" class="form-control" placeholder="75 Caroline">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="OSurbub">Surbub</label>
                                <input name="OSurbub" type="text" runat="server" id="txtSurbub" class="form-control" placeholder="Brixton">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="OCity">City</label>
                                <input name="OCity" type="text" runat="server" id="txtCity" class="form-control" placeholder="Johannesburg">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="OProvince">Province</label>
                                <input name="OProvince" type="text" runat="server" id="txtProvince" class="form-control" placeholder="Gauteng">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="OCountry">Country</label>
                                <input name="OCountry" runat="server" type="text" id="txtCountry" class="form-control" placeholder="South Africa">
                            </div>


                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="OName" class="form-control-label">Name</label>
                                    <input class="form-control" runat="server" type="text" id="txtOrderName" name="OName" placeholder="Hlulani">
                                </div>
                                <div class="col-lg-6">
                                    <label for="OSurname" class="form-control-label">Surname</label>
                                    <input class="form-control" runat="server" type="text" id="txtOrderSurname" name="OSurname" placeholder="Kubaye">
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="OContact" class="form-control-label">Contact numbers</label>
                                    <input class="form-control" runat="server" type="text" id="txtOrderContact" name="OContact" placeholder="012 555 5555">
                                </div>
                                <div class="col-lg-6">
                                    <label for="OEmail" class="form-control-label">Email</label>
                                    <input class="form-control" type="text" runat="server" id="txtOrderEmail" name="OEmail" placeholder="user@example.com">
                                </div>
                            </div>



                        </div>

                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">

                            <h3>Payment</h3>


                            <div class="form-group">
                                <label for="fname" class="form-control-label">Accepted Cards</label>
                                <div style="margin-bottom: 17px; padding: 7px 0; font-size: 24px">
                                    <i class="fa fa-cc-visa" style="color: navy;"></i>
                                    <i class="fa fa-cc-amex" style="color: blue;"></i>
                                    <i class="fa fa-cc-mastercard" style="color: red;"></i>
                                    <i class="fa fa-cc-discover" style="color: orange;"></i>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="OCardName">Name on card</label>
                                <input name="OCardName" id="txtCardName" type="text" class="form-control" placeholder="HP Kubayi">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="OCardNumber">Card number</label>
                                <input name="OCardNumber"  id="txtCardNumber" type="text" class="form-control" placeholder="**** **** **** ****">
                            </div>




                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="OCardExpDate">Expiration date</label>
                                    <input type="text" name="OCardExpDate"  id="txtCardExpDate" placeholder="05/30">
                                </div>
                                <div class="col-lg-6">
                                    <label for="OCVC">Security code</label>
                                    <input type="text" name="OCVC"  id="txtCardCVC" placeholder="***">
                                </div>
                            </div>


                        </div>


                    </div>
                    

                    </div>
               

                <div class="aside_wrapper col-lg-3 col-md-4 col-sm-12 col-xs-12">

                    <div class="hookup_wrap">
                       
                        <asp:Button ID="btnConfirmOrder" runat="server" Text="Confirm order" class="btn hookup_btn"  OnClick="btnConfirmOrder_Click" />
                        <ul id="dispOrderSummary" runat="server">
                           

                        </ul>
                    </div>
                    <div class="course_tutor contact_form">
                        <h4>Cart Items</h4>
                        <ul id="showCartList" runat="server">
                           
                           
                        </ul>
                    </div>
                </div>
            </div>
        </div>
     </div>
   
</asp:Content>
