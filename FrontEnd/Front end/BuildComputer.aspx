<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BuildComputer.aspx.cs" Inherits="Front_end.BuildComputer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content_wrapper">


        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Build Computer</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                        <li>Build Computer</li>
                    </ul>
                </div>
            </div>
        </div>

        <div id="team" class="team">
            <div class="container">
                <div class="head_part" style="text-align: left">
                    <h2 style="text-align: left">Do not know what to build?</h2>
                    <p>
                        Do not worry, we've got you. The guide will make use of few series of questions to better understand and recommend the type of computer you need.
                    </p>

                    <div class="course_to_search_wrapp">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="course_to_search_inner">
                                <div class="course_to_search" style="display: block; width: 90%">
                                    <div class="search_pannel">

                                        <select class="selectpicker" style="display: block">
                                            <option disabled selected hidden>Computer Type</option>
                                            <option>Desktop PC</option>
                                            <option>Laptop</option>
                                        </select>

                                        <select class="selectpicker" style="display: none">
                                            <option disabled selected hidden>Purpose</option>
                                            <option>Work laptop</option>
                                            <option>Gaming & Video rendaring</option>
                                            <option>Basic computer uses</option>
                                            <option>High-end user</option>
                                        </select>

                                        <select class="selectpicker" style="display: none;">
                                            <option disabled hidden selected>OS Type</option>
                                            <option>Apple Mac</option>
                                            <option>Microsoft Windows</option>

                                        </select>

                                        <select class="selectpicker" style="display: none">
                                            <option disabled selected hidden>Budget</option>
                                            <option>R4000 - R6000</option>
                                            <option>R6000 - R20 000</option>
                                            <option>R20 000+</option>
                                        </select>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <a class="btn" href="teachers.html">Guide me</a>
                <%--             <asp:Button ID="Button2" runat="server" Text="Guide Me" class="btn find_course_form_btn" Style="float: right; text-align: right" />--%>
                <%--                <asp:Button ID="btnDoneBuild" runat="server" Text="Done Building" style="width:fit-content" class="btn find_course_form_btn" />--%>
            </div>




            <div class="container">
                <div class="o-lecturers">
                    <div id="showPartsDet" runat="server" class="o-lecturers-bg" style="background: url(Content/images/border_bg.png) no-repeat; background-size: 100% 100%;">
                    </div>
                </div>

            </div>

            <div class="container">


                <div id="overview" class="overview">

                    <div class="overview_inner col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin-top: 30px">
                        <h2>Summary of your build</h2>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 overview_m_padd" id="shBuild" runat="server">
                        </div>
                        <asp:Button ID="btnDoneBuild" runat="server" Text="Done Building" Style="width:100%" class="btn find_course_form_btn" OnClick="btnBuildComputer_Click" />


                    </div>

                </div>


            </div>

        </div>
    </div>


</asp:Content>
