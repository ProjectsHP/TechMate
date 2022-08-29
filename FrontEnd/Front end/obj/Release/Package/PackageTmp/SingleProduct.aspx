<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SingleProduct.aspx.cs" Inherits="Front_end.tryUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

       <%-- function showDisc() {

            var showD = document.getElementById("<%=descrProduct.ClientID%>");
            showD.style.display = 'block';
            showD.focus();
        }--%>

    </script>

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
                                        <div class="info_head">
                                            <h4>Description</h4>
                                            <p id="dispDescr" runat="server">
                                            </p>

                                           
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
