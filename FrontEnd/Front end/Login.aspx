<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Front_end.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        function focusRegisterForm() {
            window.scroll({
                top: 0,
                behavior: 'smooth'
            });
            document.getElementById("<%=txtName.ClientID%>").focus();
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content_wrapper">
	

        <div class="find_course">
            <div class="container">
                <div class="find_course_inner">
                    <div class="find_course_txt_wrap col-md-8 col-xs-12">
                        <div class="find_course_txt" style="margin-top:-24px">
                            <div class="head_part" style="margin:-15px 0 15px 0">
                                <h2>Offering exclusive powerful computer builds</h2>
                                <p>Sign-up below to start building.</p>
                            </div>

                            <div id="regForm" class="contact_form" style="margin:-15px 0 15px 0;padding:2%;background-color:whitesmoke">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="txtName" >First name</label>
                                            <input runat="server" id="txtName" class="form-control" placeholder="name" name="name" type="text">
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="txtSurname">Last name</label>
                                            <input runat="server" id="txtSurname" class="form-control" placeholder="surname" name="name" type="text">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="txtEmail">Email</label>
                                            <input runat="server" id="txtEmail" class="form-control" placeholder="email address" name="email" type="email">
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="txtContacts">Contacts</label>
                                            <input runat="server" id="txtContacts" class="form-control" placeholder="contacts numbers" name="name" type="number">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="txtPassword">Password</label>
                                            <input runat="server" id="txtPassword" class="form-control" placeholder="new password" name="name" type="password">
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="form-control-label" for="txtConfPassword">Confirm</label>
                                            <input runat="server" id="txtConfPassword" class="form-control" placeholder="Confirm password" name="name" type="password">
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="find_course_form_btn_wrap">
                                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" class="btn find_course_form_btn" OnClick="btnSignUp_Click" />
                               <p1 id="lblErrorReg" runat="server" style="color: red;margin-top:5px; margin:auto"><strong>Error</strong></p1>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <div class="row find_course_form_inner">
                            <h2>Sign in here</h2>
                            <div class="find_course_form">
                                <div class="contact_form">
                                    <input runat="server" id="txtLoginEmail" class="form-control" placeholder="Email Address" name="email" type="text">
                                    <input runat="server" id="txtLoginPass" class="form-control" placeholder="Password" name="password" type="password">
                                </div>
                                <div class="find_course_form_btn_wrap">
                                    <asp:Button ID="Button2" runat="server" Text="Sign In" class="btn find_course_form_btn" OnClick="btnSignIn_Click" />
                                    <a href="javascript:focusRegisterForm()" style="color: whitesmoke">Not a member? Sign up</a>
                                   <p1 id="lblError" runat="server" style="color: red"><strong>Incorrect credentials! please try again</strong></p1>
                                </div>
                            </div>




                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
