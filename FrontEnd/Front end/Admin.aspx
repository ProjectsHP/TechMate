<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Front_end.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content_wrapper">


        <div id="slider" class="main_slider">
            <div class="example">
                <div class="content">
                    <div id="rev_slider_104_1_wrapper" class="rev_slider_wrapper fullscreen-container" data-alias="scroll-effect76" style="background-color: #111; padding: 0px;">

                        <div id="rev_slider_104_1" class="rev_slider fullscreenbanner" style="display: none;" data-version="5.0.7">
                            <ul>

                                <li data-index="rs-309" data-transition="slideoverhorizontal" data-slotamount="default" data-easein="Power4.easeInOut" data-easeout="Power4.easeInOut" data-masterspeed="1000" data-thumb="images/slider_classroom.jpg" data-rotate="0" data-fstransition="fade" data-fsmasterspeed="1500" data-fsslotamount="7" data-saveperformance="off" data-title="Education" data-description="">

                                    <img src="Content/images/products/laptops/corei9.jpg" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="10" class="rev-slidebg" data-no-retina>


                                    <div id="features" class="features" style="margin-top: 158px">
                                        <div class="container">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" onclick="location.href='AddComponent.aspx';" style="cursor: pointer;">
                                                <div class="feature_block_wrap">
                                                    <div class="teacher" style="height: 200px">
                                                        <div class="feature_block">
                                                            <div class="feature_icon"><i class="icon-group"></i></div>
                                                            <div class="feature_txt">
                                                                <h4>Add Component</h4>
                                                                <p>Create a new component and add to stock                                                                         </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" onclick="location.href='EditComponent.aspx';" style="cursor: pointer;">
                                                <div class="feature_block_wrap">
                                                    <div class="certificate" style="height: 200px">
                                                        <div class="feature_block">
                                                            <div class="feature_icon"><i class="icon-certificate"></i></div>
                                                            <div class="feature_txt">
                                                                <h4>Edit Component</h4>
                                                                <p>Search and update existing component</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" onclick="location.href='EditComponent.aspx';" style="cursor: pointer;">
                                                <div class="feature_block_wrap">
                                                    <div class="courses" style="height: 200px">
                                                        <div class="feature_block">
                                                            <div class="feature_icon"><i class="icon-earth"></i></div>
                                                            <div class="feature_txt">
                                                                <h4>Remove Component</h4>
                                                                <p>Search and remove component in stock</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" onclick="location.href='Home.aspx';" style="cursor: pointer;">
                                                <div class="feature_block_wrap">
                                                    <div class="library" style="height: 200px">
                                                        <div class="feature_block">
                                                            <div class="feature_icon"><i class="icon-fav-book"></i></div>
                                                            <div class="feature_txt">
                                                                <h4>Manage Compatibility</h4>
                                                                <p>Update component compatibility</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </li>

                            </ul>
                            <div class="tp-static-layers"></div>
                            <div class="tp-bannertimer tp-bottom" style="visibility: hidden !important;"></div>
                        </div>
                    </div>

                </div>
            </div>
        </div>




        <div id="count" class="count" data-stellar-background-ratio="0.3" style="background-color: dimgray; background-attachment: fixed; background-position: 50% 50%;">
            <div class="count_wrapper">
                <div class="container">
                    <div class="head_part">
                        <h2>Happy Milistones</h2>
                        <p>We Have Powerful Milistones With Fun Fact Effects.</p>
                    </div>
                    <div class="row">
                        <div class="col-sm-3 col-md-3 col-xs-6">
                            <div class="funfact expert text-center mb-sm-30">
                                <div class="icon"><i class="fa fa-user"></i></div>
                                <div class="counts">
                                    <h2 class="animate-number" data-animation-duration="2000" data-value="730">0</h2>
                                    <h4 class="title">Fulfilled orders</h4>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-xs-6">
                            <div class="funfact online text-center mb-sm-30">
                                <div class="icon"><i class="fa fa-book"></i></div>
                                <div class="counts">
                                    <h2 class="animate-number" data-animation-duration="2000" data-value="3565">0</h2>
                                    <h4 class="title">Pending orders</h4>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-xs-6">
                            <div class="funfact placed last text-center mb-sm-30">
                                <div class="icon"><i class="fa fa-map-marker"></i></div>
                                <div class="counts">
                                    <h2 class="animate-number" data-animation-duration="2000" data-value="4253">0</h2>
                                    <h4 class="title">Regected orders</h4>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-xs-6">
                            <div class="funfact student second_one text-center mb-sm-30">
                                <div class="icon"><i class="fa fa-users"></i></div>
                                <div class="counts">
                                    <h2 class="animate-number" data-animation-duration="2000" data-value="7644">0</h2>
                                    <h4 class="title">Not paid</h4>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>









    </div>






</asp:Content>
