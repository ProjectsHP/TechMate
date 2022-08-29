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

                                            <h5>How it Works</h5>
                                            <div class="panel-group" id="accordion2">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading" id="head_One2">
                                                        <h4 class="panel-title">
                                                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion2" href="#ques_eight">
                                                                <i class="fa fa-info"></i><span>/</span>The particulate nature of matter <i class="fa fa-plus"></i>
                                                            </a>
                                                        </h4>
                                                    </div>
                                                    <div id="ques_eight" class="panel-collapse collapse">
                                                        <div class="panel-body">
                                                            <ul>
                                                                <li><span><strong>Core</strong></span>
                                                                    <ul>
                                                                        <li>State the distinguishing properties of solids, liquids and gases</li>
                                                                        <li>Describe the structure of solids, liquids and gases in terms of particle separation, arrangement and types of motion</li>
                                                                        <li>Describe changes of state in terms of melting, boiling, evaporation, freezing, condensation and sublimation</li>
                                                                        <li>Describe qualitatively the pressure and temperature of a gas in terms of the motion of its particles</li>
                                                                        <li>Show an understanding of the random motion of particles in a suspension (sometimes known as Brownian motion) as evidence for the kinetic particle
(atoms, molecules or ions) model of matter</li>
                                                                        <li>Describe and explain diffusion</li>
                                                                    </ul>
                                                                </li>
                                                                <li><span><strong>Supplement</strong></span>
                                                                    <ul>
                                                                        <li>Explain changes of state in terms of the kinetic theory</li>
                                                                        <li>Describe and explain Brownian motion in terms of random molecular bombardment</li>
                                                                        <li>State evidence for Brownian motion</li>
                                                                        <li>Describe and explain dependence of rate of diffusion on molecular mass</li>
                                                                    </ul>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel panel-default">
                                                    <div class="panel-heading" id="head_two2">
                                                        <h4 class="panel-title">
                                                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion2" href="#ques_nine">
                                                                <i class="fa fa-eyedropper"></i><span>/</span>Experimental techniques <i class="fa fa-plus"></i>
                                                            </a>
                                                        </h4>
                                                    </div>
                                                    <div id="ques_nine" class="panel-collapse collapse">
                                                        <div class="panel-body">
                                                            <ul>
                                                                <li><span><strong>Criteria of purity</strong></span>
                                                                    <ul>
                                                                        <li>Name appropriate apparatus for the measurement of time, temperature, mass and volume, including burettes, pipettes and measuring cylinders</li>
                                                                        <li>Demonstrate knowledge and understanding of paper chromatography</li>
                                                                        <li>Interpret simple chromatograms</li>
                                                                        <li>Identify substances and assess their purity from melting point and boiling point information</li>
                                                                        <li>Understand the importance of purity in substances in everyday life, e.g. foodstuffs and drugs</li>
                                                                    </ul>
                                                                </li>
                                                                <li><span><strong>Methods of purification</strong></span>
                                                                    <ul>
                                                                        <li>Describe and explain methods of purification by the use of a suitable solvent, filtration, crystallisation and distillation (including use of
fractionating column). (Refer to the fractional distillation of petroleum in section 14.2 and products of fermentation in section&nbsp;14.6.)</li>
                                                                        <li>Suggest suitable purification techniques, given information about the substances involved</li>
                                                                    </ul>
                                                                </li>
                                                                <li><span><strong>Supplement</strong></span>
                                                                    <ul>
                                                                        <li>Interpret simple chromatograms, including the use of Rf values</li>
                                                                        <li>Outline how chromatography techniques can be applied to colourless substances by exposing chromatograms to substances called locating agents
(Knowledge of specific locating agents is not required.)</li>
                                                                    </ul>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel panel-default">
                                                    <div class="panel-heading" id="head_three2">
                                                        <h4 class="panel-title">
                                                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion2" href="#ques_ten">
                                                                <i class="fa fa-object-group"></i><span>/</span>Atoms, elements and compounds <i class="fa fa-plus"></i>
                                                            </a>
                                                        </h4>
                                                    </div>
                                                    <div id="ques_ten" class="panel-collapse collapse">
                                                        <div class="panel-body">
                                                            <ul>
                                                                <li><span><strong>Core</strong></span>
                                                                    <ul>
                                                                        <li>State the relative charges and approximate relative masses of protons, neutrons and electrons</li>
                                                                        <li>Define proton number (atomic number) as the number of protons in the nucleus of an atom</li>
                                                                        <li>Define nucleon number (mass number) as the total number of protons and neutrons in the nucleus of an atom</li>
                                                                        <li>Define isotopes as atoms of the same element which have the same proton number but a different nucleon number</li>
                                                                        <li>State the two types of isotopes as being radioactive and non-radioactive</li>
                                                                        <li>State one medical and one industrial use of radioactive isotopes</li>
                                                                    </ul>
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
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
