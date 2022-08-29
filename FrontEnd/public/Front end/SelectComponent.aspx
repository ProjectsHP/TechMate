<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SelectComponent.aspx.cs" Inherits="Front_end.SelectComponent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="content_wrapper">


        <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Select Component</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                         <li><a href="BuildComputer.aspx">Build Computer </a>/</li>
                        <li>Component</li>
                    </ul>
                </div>
            </div>
        </div>

            <div id="courses" class="courses">
            <div class="container">
                <div class="head_part">
                    <h2 id="headerProd" runat="server"></h2>
                    <p>latest trending technogies are available with us</p>
                </div>
                <div id="listComps" runat="server" class="course_wrapper">
                    
                </div>
            </div>
        </div>

          </div>
</asp:Content>
