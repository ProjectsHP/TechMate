<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserProfileDemo.aspx.cs" Inherits="Front_end.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--            <link rel="stylesheet" type="text/css" href="Content/css/userProfile.css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--     <link rel="stylesheet" type="text/css" href="Content/css/userProfile.css" />--%>

    <div class="content_wrapper">



        <div id="slider" class="main_slider">
            <div class="example">
                <div class="content">
                    <div id="rev_slider_104_1_wrapper" class="rev_slider_wrapper fullscreen-container" data-alias="scroll-effect76" style="padding: 0px;">

                        <div id="rev_slider_104_1" class="rev_slider fullscreenbanner" style="display: none;" data-version="5.0.7">
                            <ul>

                                <li data-index="rs-309" data-transition="slideoverhorizontal" data-slotamount="default" data-easein="Power4.easeInOut" data-easeout="Power4.easeInOut" data-masterspeed="1000" data-thumb="images/slider_classroom.jpg" data-rotate="0" data-fstransition="fade" data-fsmasterspeed="1500" data-fsslotamount="7" data-saveperformance="off" data-title="Education" data-description="">

                                    <img src="Content/images/bg_blue_abstract.png" alt="" data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="10" class="rev-slidebg" data-no-retina>


                                    <div class="tp-caption tp-shape tp-shapewrapper rs-parallaxlevel-0" id="slide-309-layer-11" data-x="['center','center','center','center']" data-hoffset="['0','0','0','0']" data-start="0" data-y="['bottom','bottom','bottom','bottom']" data-voffset="['0','0','0','0']" data-width="full" data-height="['725','725','725','875']" data-whitespace="nowrap" data-responsive="off" data-transform_idle="o:1;" data-style_hover="cursor:default;" data-transform_in="opacity:0;s:1500;e:Power2.easeInOut;" data-transform_out="opacity:0;s:1000;s:1000;" data-basealign="slide" data-responsive_offset="off" style="z-index: 5; background-color: rgba(0, 0, 0, 0.50); border-color: rgba(0, 0, 0, 0); background: rgba(0,0,0,0.45);">
                                    </div>

                                    <div class="tp-caption BigBold-Title tp-resizeme rs-parallaxlevel-0" id="slide-309-layer-1" data-x="['center','center','center','center']" data-hoffset="['50','50','30','17']" data-height="none" data-y="['top','top','top','top']" data-voffset="['100','110','180','160']" data-fontsize="['110','100','70','60']" data-lineheight="['100','90','60','60']" data-width="['none','none','none','400']" data-whitespace="['nowrap','nowrap','nowrap','normal']" data-transform_idle="o:1;" data-mask_in="x:0px;y:[100%];" data-start="500" data-transform_in="y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;s:1500;e:Power3.easeInOut;" data-mask_out="x:inherit;y:inherit;" data-splitin="none" data-splitout="none" data-transform_out="y:[100%];s:1000;e:Power2.easeInOut;s:1000;e:Power2.easeInOut;" data-basealign="slide" data-responsive_offset="off" style="z-index: 6; white-space: nowrap;">
                                        A Better Education
                                    </div>

                                    <div class="tp-caption BigBold-SubTitle rs-parallaxlevel-0" id="slide-309-layer-4" data-x="['center','center','center','center']" data-hoffset="['55','55','33','20']" data-whitespace="normal" data-y="['25','25','25','25']" data-voffset="['40','1','74','58']" data-fontsize="['19','19','19','16']" data-lineheight="['27','27','27','22']" data-width="['410','410','410','280']" data-height="['60','100','100','100']" data-transform_idle="o:1;" data-start="650" data-splitin="none" data-splitout="none" data-transform_in="y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;s:1500;e:Power3.easeInOut;" data-basealign="slide" data-responsive_offset="off" data-transform_out="y:50px;opacity:0;s:1000;e:Power2.easeInOut;s:1000;e:Power2.easeInOut;" data-responsive="off" style="z-index: 7; min-width: 410px; max-width: 410px; max-width: 60px; white-space: normal;">
                                        A Better Education for a Better World, Learn something new today.
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

        <div class="main-content">
            <div class="container-fluid mt--7">
                <div class="row2">
                    <div class="col-xl-8 order-xl-1">
                        <div class="course_block2"   >
                            <div class="card-header bg-white border-0" >
                                <div class="row2 align-items-center">
                                    <div class="col-4 text-right" style="margin-top:-15px">
                                        <asp:Button ID="btnEditProfile" runat="server" Text="Edit profile"  class="btn btn-sm btn-primary"/>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body" style="background-color:ghostwhite">
                                    <h3 class="heading-small text-muted mb-4">User information</h3>
                                    <div class="pl-lg-4">
                                        <div class="row2">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-username">Username</label>
                                                    <input type="text" id="input-username" class="form-control" placeholder="Username" value="lucky.jesse">
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-email">Email address</label>
                                                    <input type="email" id="input-email" class="form-control" placeholder="jesse@example.com">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row2">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-first-name">First name</label>
                                                    <input type="text" id="input-first-name" class="form-control" placeholder="First name" value="Lucky">
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-last-name">Last name</label>
                                                    <input type="text" id="input-last-name" class="form-control" placeholder="Last name" value="Jesse">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-4">
                                    <!-- Address -->
                                    <h3 class="heading-small text-muted mb-4">Contact information</h3>
                                    <div class="pl-lg-4">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-address">Address</label>
                                                    <input id="input-address" class="form-control" placeholder="Home Address" value="Bld Mihail Kogalniceanu, nr. 8 Bl 1, Sc 1, Ap 09" type="text">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row2">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-city">City</label>
                                                    <input type="text" id="input-city" class="form-control" placeholder="City" value="New York">
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-country">Country</label>
                                                    <input type="text" id="input-country" class="form-control" placeholder="Country" value="United States">
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="input-country">Postal code</label>
                                                    <input type="number" id="input-postal-code" class="form-control" placeholder="Postal code">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>
                        </div>

                    </div>

                    <div class="col-xl-4 order-xl-2 mb-5 mb-xl-0">
                        <div class="shadow course_block2">
                            <div class="row2 justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <a href="#">
                                            <img src="https://demos.creative-tim.com/argon-dashboard/assets-old/img/theme/team-4.jpg" class="rounded-circle">
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                               
                            </div>
                            <div class="card-body pt-0 pt-md-4">
                                
              <div class="row">
                <div class="col">
                  <div class="card-profile-stats d-flex justify-content-center mt-md-5">
                    <div>
                      <span class="heading">22</span>
                      <span class="description">Friends</span>
                    </div>
                    <div>
                      <span class="heading">10</span>
                      <span class="description">Photos</span>
                    </div>
                    <div>
                      <span class="heading">89</span>
                      <span class="description">Comments</span>
                    </div>
                  </div>
                </div>
              </div>
              <div class="text-center">
                <h3>
                  Jessica Jones<span class="font-weight-light">, 27</span>
                </h3>
                <div class="h5 font-weight-300">
                  <i class="ni location_pin mr-2"></i>Bucharest, Romania
                </div>
                <div class="h5 mt-4">
                  <i class="ni business_briefcase-24 mr-2"></i>Solution Manager - Creative Tim Officer
                </div>
                <div>
                  <i class="ni education_hat mr-2"></i>University of Computer Science
                </div>
                <hr class="my-4">
                <p>Ryan — the name taken by Melbourne-raised, Brooklyn-based Nick Murphy — writes, performs and records all of his own music.</p>
                <a href="#">Show more</a>
              </div>
            </div>
                          
                        
                        </div>
                        <%--<div class="clearfix"></div>--%>
                    </div>
                </div>

            </div>

            </div>
        </div>
   
</asp:Content>
