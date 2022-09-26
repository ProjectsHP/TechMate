<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddComponent.aspx.cs" Inherits="Front_end.AddComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content_wrapper">

        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(images/slider_inclass.jpg); background-attachment: fixed; background-position: 50% 50%;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Add Component</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home</a> /</li>
                        <li><a href="Admin.aspx">Admin</a> /</li>
                        <li>Add Component</li>
                    </ul>
                </div>
            </div>
        </div>


        <div id="contact_wrap" class="contact_wrap">
            <div class="container">

                <div class="col-md-6 col-sm-12 col-xs-12">
                    <h3>Component</h3>

                    <div class="contact_info">

                        <div class="dtl_block">
                            <div class="dtl_img">
                                <img alt="Blog Image" src="Content/images/latest_news1.jpg">
                            </div>

                              <div class="form-group">
                        <label class="form-control-label" for="OSurbub">Image</label>
                                   <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                           

                        </div>

                       

                    </div>
            
                    </div>
         




                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 =">

                    <h3>Details</h3>

                     <div class="contact_info">

                    <div class="form-group">
                        <label class="form-control-label" for="OSurbub">Type</label>
                        <input name="OSurbub" type="text" runat="server" id="txtSurbub" class="form-control" placeholder="Type of component">
                    </div>

                    <div class="form-group">
                        <label class="form-control-label" for="OStreet">Name</label>
                        <input name="OStreet" type="text" runat="server" id="txtStreetUnit" class="form-control" placeholder="Full name">
                    </div>

                    <div class="form-group">
                        <label class="form-control-label" for="OCity">Price</label>
                        <input name="OCity" type="text" runat="server" id="txtCity" class="form-control" placeholder="49999">
                    </div>

                    <div class="form-group">
                        <label class="form-control-label" for="OProvince">Description</label>
                        <textarea class="form-control" type="text" rows="6" runat="server" placeholder="Message..." name="message"></textarea>
                    </div>

                   

                    <button type="submit" class="btn btn_contact">Submit <i class="fa fa-check"></i></button>
                         </div>
                </div>
            </div>
        </div>

         <div class="clearfix"></div>
    </div>


   
</asp:Content>
