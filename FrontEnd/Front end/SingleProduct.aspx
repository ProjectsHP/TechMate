<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SingleProduct.aspx.cs" Inherits="Front_end.tryUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function controlStockUpdateVisibility() {

            var updateVis = document.getElementById("<%=updtStock.ClientID%>");
            updateVis.style.display = "block";
             document.getElementById("<%=stockCount.ClientID%>").focus();


        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <%-- <script type="text/javascript">

      function showDisc() {

            var showD = document.getElementById("<%=descrProduct.ClientID%>");
            showD.style.display = 'block';
            showD.focus();
        }

            </script>
    --%>

     

    <div class="content_wrapper">

        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Details</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                        <li><a href="SelectComponent.aspx">Component </a>/</li>
                        <li>Details</li>
                    </ul>
                </div>
            </div>
        </div>

        <div id="dtl_wrap" class="dtl_wrap">

            <div class="container">

                <div class="dtl_wrapper col-lg-9 col-md-8 col-sm-12 col-xs-12">

                    <div class="dtl_inner_wrap">

                        <div class="dtl_inner last">
                            <div class="dtl_block teach_sin_block">
                                <div id="dispProduct" runat="server" class="dtl_img teach_sin_img">
                                </div>
                                <div class="detail_text_wrap">
                                    <div class="info_wrapper">
                                        <div class="info_head" id="updtStock" runat="server" visible="false"> 
                                            <h4>Update Stock</h4>
                                            <div class="form-group">
                                                <label class="form-control-label" for="selectType">Update type</label>
                                                <select class="form-control" name="selectType" runat="server" id="selectType">
                                                    <option value="Increase">Add Stock</option>
                                                    <option>Reduce Stock</option>
                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-control-label" for="stockCount">Stock count</label>
                                                <input runat="server" id="stockCount" class="form-control" min="1" step="1" placeholder="1" name="name" type="number">
                                            </div>
                                            



                                            <asp:Button ID="btnUpdateStock" runat="server" Text="Submit" OnClick="btnUpdateStock_Click" />

                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>

                    </div>

                    <div class="clearfix"></div>
                </div>




                <div class="aside_wrapper col-lg-3 col-md-4 col-sm-12 col-xs-12">
                    <div class="course_tutor">
                        <h4>Also Recommended</h4>
                        <ul id="recList" runat="server">
                    


                                </ul>
                    </div>

                </div>

            </div>

        </div>

    </div>


</asp:Content>
