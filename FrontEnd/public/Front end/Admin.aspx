<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Front_end.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="content_wrapper">
    <div class="breadcrumb_wrap" data-stellar-background-ratio="0.3" style="background: url(Content/images/bg_blue_abstract.png) no-repeat; background-attachment: fixed; background-position: top left; background-size: cover;">
            <div class="breadcrumb_wrap_inner">
                <div class="container">
                    <h1>Manage Components</h1>
                    <ul class="breadcrumbs">
                        <li><a href="Home.aspx">Home </a>/</li>
                        <li>Manage Components</li>
                    </ul>
                </div>
            </div>
        </div>


         <div class="comments-form-wrapper clearfix">
<h5>Leave A reply</h5>
<form class="comment-form" method="post" id="postComment">
<div class="field">
<label>Name <em class="required">*</em></label>
<input type="text" class="input-text" title="Name" id="user" placeholder="Full Name ..." name="user_name" required="">
</div>
<div class="field">
<label>Email <em class="required">*</em></label>
<input type="text" class="input-text" title="Email" id="email" placeholder="Email ..." name="user_email" required="">
</div>
<div class="input-box">
<label for="input-payment-url" class="control-label">URL</label>
<input type="text" class="input-text" id="input-payment-url" placeholder="URL ..." value="" name="url" required="">
</div>
<div class="field aw-blog-comment-area">
<label for="comment">Comment <em class="required">*</em></label>
<textarea rows="5" cols="50" class="input-text" title="Comment" placeholder="Leave Comments ..." id="comment" name="comment" required=""></textarea>
</div>
<div class="mt_5">
<input type="hidden" value="1" name="blog_id">
<button type="submit" class="button continue">Add Comment</button>
</div>
</form>
</div>
         </div>


</asp:Content>
