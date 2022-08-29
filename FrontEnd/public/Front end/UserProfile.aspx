<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Front_end.SingleProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content_wrapper">

          <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Profile</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a> /</li>
                        <li>Profile</li>
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
                                <div class="dtl_img teach_sin_img">
                                    <div class="col-md-5 col-xs-12 text-center">
                                         <img alt="Leonardo Bonucci" src="Content/images/fal_leonardo_bonucci.jpg">
                                      
                                    </div>
                                    <div class="teacher_info col-md-7 col-xs-12">
                                        <h4>Leonardo Bonucci<em>Science teacher</em></h4>
                                        <div class="teach_profession">
                                            <h5>Skills:</h5>
                                            <em>Physics, Chemistry, Math, Computers and Electronics, Biology, Engineering and Technology, Medicine and Dentistry.
                                            </em>
                                        </div>
                                        <div class="teach_sumarry">
                                            <h5>Summary:</h5>
                                            <p>
                                                He is expert an extensive list of achievements along all the years. Your expertising level is something you don't see easily with a high level education. The expert will
give all the instructions in easy and compreensive way.
                                            </p>
                                        </div>
                                        <ul class="link_social">
                                            <li><a class="fa fa-facebook" href="#"></a></li>
                                            <li><a class="fa fa-instagram" href="#"></a></li>
                                            <li><a class="fa fa-google-plus" href="#"></a></li>
                                            <li><a class="fa fa-twitter" href="#"></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="detail_text_wrap">
                                    <div class="info_wrapper,">
                                        <div class="info_head">
                                            <h4>Description</h4>
                                            <p>
                                                Fusce eleifend donec sapien sed phase lusa. Pellentesque lacus vamus lorem arcu semper duiac. Cras ornare arcu avamus nda leo. Etiam ind arcu morbi justo mauris tempu
                                            </p>
                                        </div>
                                    </div>
                                    <div class="info_wrapper">
                                        <div class="info_head">
                                            <h4>What You will Learn</h4>
                                        </div>

                                        <p>Sed perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque:</p>
                                        <ul class="arr_menu">
                                            <li>vamus nda leo etiam ind arcu morbi justo mauris tempus</li>
                                            <li>Pellentesque lacus vamus lorem arcu semper duiac ras ornare arcu avamus</li>
                                            <li>Cras ornare arcu avamus nda leo etiam ind arcu morjusto mauris tempus pharetra inter</li>
                                        </ul>

                                    </div>



                                </div>
                            </div>
                        </div>



                    </div>

                    <div class="clearfix"></div>
                </div>


                <div class="aside_wrapper col-lg-3 col-md-4 col-sm-12 col-xs-12">

                    <div class="hookup_wrap tutor_info_wrap">
                        <asp:Button ID="btnShowUpdate" runat="server" Text="Update profile" OnClick="btnShowUpdate_Click" Style="width: 100%" />
                        <%--   <a href="Cart.aspx" class="btn hookup_btn">Add to cart <i class="fa fa-shopping-cart"></i></a>--%>
                        <ul runat="server" id="viewBox">
                          
                        </ul>
                        <ul runat="server" id="editBox">



                            <li>
                                <div class="form-group">
                                    <label class="form-control-label" for="editName">Username</label>
                                    <input type="text" id="editName" runat="server" class="form-control" style="border-bottom: groove; border-color: ActiveBorder" placeholder="First name">
                                </div>
                            </li>

                            <li>
                                <div class="form-group">
                                    <label class="form-control-label" for="editSurname">Surname</label>
                                    <input type="text" runat="server" id="editSurname" class="form-control" placeholder="Last name" style="border-bottom: groove; border-color: ActiveBorder">
                                </div>
                            </li>
                            <li>
                                <div class="form-group">
                                    <label class="form-control-label" for="Email">Username</label>
                                    <input type="text" runat="server" id="editEmail" class="form-control" placeholder="Email address" style="border-bottom: groove; border-color: ActiveBorder">
                                </div>
                            </li>

                            <li>
                                <div class="form-group">
                                    <label class="form-control-label" for="editContacts">Contacts</label>
                                    <input type="tel" runat="server" id="editContacts" class="form-control" placeholder="Cellphone numbers" style="border-bottom: groove; border-color: ActiveBorder">
                                </div>
                            </li>

                             <li>
                                <div class="form-group">
                                    <label class="form-control-label" for="editGender">Gender</label>
                                    <input type="text" runat="server" id="editGender" class="form-control" placeholder="Gender" style="border-bottom: groove; border-color: ActiveBorder">
                                </div>
                            </li>

                            <asp:Button ID="btnEditSubmit" runat="server" Text="Submit" OnClick="btnEditSubmit_Click" Style="width: 100%" />



                        </ul>

                    </div>




                </div>

            </div>

        </div>




    </div>


</asp:Content>
