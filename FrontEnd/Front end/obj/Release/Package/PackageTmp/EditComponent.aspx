<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditComponent.aspx.cs" Inherits="Front_end.EditComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content_wrapper">

        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(images/slider_inclass.jpg); background-attachment: fixed; background-position: 50% 50%;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Update Component</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home</a> /</li>
                        <li><a href="Admin.aspx">Admin</a> /</li>
                        <li>Update Component</li>
                    </ul>
                </div>
            </div>
        </div>


        <div id="contact_wrap" class="contact_wrap">

            <div class="container">

                <div class="row">
                    <div class="head_part col-md-6 col-sm-12 col-xs-12">
                        <h2>Search product</h2>
                        <div class="course_to_search_wrapp">
                            <div class="search_course">
                                <div class="form-group">
                                    <label class="form-control-label" for="OCardName">Search product by image</label>
                                    <asp:FileUpload ID="fileUploadImage" runat="server" class="form-control" />
                                </div>
                            </div>

                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        </div>

                    </div>

                </div>


                <div id="duplicateSearch" runat="server" visible="false">
                    <h2>Duplicates found!</h2>
                    These components contains duplicate image display. Search component by Id.
                    <br />
                    <br />
                    <div class="column-labels">


                        <label class="product-price">#</label>
                        <label class="product-price">Id</label>
                        <label class="product-price">Category</label>
                        <label class="product-price">Price</label>
                        <label class="product-price">Quantity</label>
                        <label class="product-price">Compatibility</label>
                        <label class="product-price" style="width: 20%">Name</label>


                    </div>

                    <div id="compsLabels" runat="server">
                    </div>

                    <div class="form-group">
                                <label class="form-control-label" for="SId">Search </label>
                                <input name="SId" type="text" runat="server" id="txtSearchId" class="form-control" style="width:30%" placeholder="Search by Component Id">
                            </div>

                    <asp:Button ID="btnSearchById" runat="server" Text="Search" OnClick="btnSearchById_Click" />
                </div>


                <div style="margin-top: 100px" id="compDet" runat="server" visible="false">


                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <h3>Details</h3>

                        <div class="contact_info">

                            <div class="dtl_block">
                                <div class="dtl_img" id="dispCompImage" runat="server">
                                    <img alt="Blog Image" id="dispImg" runat="server" src="Content/images/fancybox/no_Image.png">
                                </div>

                                <div class="form-group">
                                    <label class="form-control-label" for="imgLoader">Image</label>
                                    <asp:FileUpload ID="imgLoader" runat="server" ToolTip="Browse component image" onchange="updateImage()" />
                                </div>



                            </div>

                        </div>

                    </div>


                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 =">

                        <%--<h3>Details</h3>--%>

                        <div class="contact_info">
                            <div class="form-group">
                                <label class="form-control-label" for="CType">Type</label>
                                <input name="CType" type="text" runat="server" id="txtTypeEDIT" class="form-control" placeholder="Type of component">
                            </div>

                            <div class="form-group">
                                <label class="form-control-label" for="CName">Name</label>
                                <input name="CName" type="text" runat="server" id="txtNameEDIT" class="form-control" placeholder="Full name">
                            </div>

                            <div class="form-group">
                                <label class="form-control-label" for="CPrice">Price (zar)</label>
                                <input name="CPrice" type="text" runat="server" id="txtPriceEDIT" class="form-control" placeholder="49 999">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="CQuantity">Quantity</label>
                                <input name="CQuantity" type="number" runat="server" id="txtQuantityEDIT" class="form-control" placeholder="1">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="CCompatibility">Compatibility</label>
                                <input name="CCompatibility" type="text" runat="server" id="txtCompatibilityEDIT" class="form-control" placeholder="AAX">
                            </div>


                            <div class="form-group">
                                <label class="form-control-label" for="CDescription">Description</label>
                                <textarea class="form-control" id="txtDescription" name="CDescriptionEDIT" type="text" rows="5" runat="server" placeholder="Component Specs in detail"></textarea>
                            </div>

                            <p>
                                Delete component stock from database?
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                            </p>

                            <asp:Button ID="btnEditUser" runat="server" Text="Submit" class="btn btn_contact" OnClick="btnEditUser_Click" />

                        </div>
                    </div>
                </div>

            </div>
        </div>




        <div class="clearfix"></div>
    </div>

</asp:Content>
