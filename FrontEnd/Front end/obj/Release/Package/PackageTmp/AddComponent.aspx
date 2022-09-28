<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddComponent.aspx.cs" Inherits="Front_end.AddComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">

        function updateImage() {
          
            var imageLoaderr = document.getElementById("<%=imgLoader.ClientID%>");
            var imageView = document.getElementById("<%=componentImage.ClientID%>");
          
            var fileName = imageLoaderr.value;
         
            path_string = 'Content/images/products/components/' + fileName.split("\\").pop();
            imageView.setAttribute('src', path_string);
        }

     </script>

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
                                <img id="componentImage" runat="server" alt="Blog Image" src="Content/images/fancybox/no_Image.png">
                            </div>

                            <div class="form-group">
                                <label class="form-control-label" for="imgLoader">Image</label>
                                <asp:FileUpload ID="imgLoader" runat="server"  ToolTip="Browse component image" onchange="updateImage()" />
                            </div>


                        </div>



                    </div>

                </div>





                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 =">

                    <h3>Details</h3>

                    <div class="contact_info">

                        <div class="form-group">
                            <label class="form-control-label" for="CType">Type</label>
                            <input name="CType" type="text" runat="server" id="txtType" class="form-control" placeholder="Type of component">
                        </div>

                        <div class="form-group">
                            <label class="form-control-label" for="CName">Name</label>
                            <input name="CName" type="text" runat="server" id="txtName" class="form-control" placeholder="Full name">
                        </div>

                        <div class="form-group">
                            <label class="form-control-label" for="CPrice">Price (zar)</label>
                            <input name="CPrice" type="text" runat="server" id="txtPrice" class="form-control" placeholder="49 999">
                        </div>


                        <div class="form-group">
                            <label class="form-control-label" for="CQuantity">Quantity</label>
                            <input name="CQuantity" type="number" runat="server" id="txtQuantity" class="form-control" placeholder="1">
                        </div>


                           <div class="form-group">
                            <label class="form-control-label" for="CCompatibility">Compatibility</label>
                            <input name="CCompatibility" type="text" runat="server" id="txtCompatibility" class="form-control" placeholder="AAX">
                        </div>


                        <div class="form-group">
                            <label class="form-control-label" for="CDescription">Description</label>
                            <textarea class="form-control" id="txtDescription" name="CDescription" type="text" rows="5" runat="server" placeholder="Component Specs in detail"></textarea>
                        </div>


                        <asp:Button ID="btnAddComp" runat="server" Text="Submit" CssClass="btn btn_contact" OnClick="btnAddComp_Click" />
                        <%--                    <button type="submit" OnServerClick="Submit_click" runat="server" class="btn btn_contact">Submit <i class="fa fa-check"></i></button>--%>
                    </div>
                </div>
            </div>
        </div>

        <div class="clearfix"></div>
    </div>



</asp:Content>
