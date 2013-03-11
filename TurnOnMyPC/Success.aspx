<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs"  MasterPageFile="Site.Master" Inherits="TurnOnMyPC.Success" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <style>
        body
        {
            background-color: #66CC66;
        }
    </style>
    
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="Body">
    <div class="Title">
        Your PC will be turned on in a while.
    </div>
    <div class="Description">
        <a href="Default.aspx">Turn on one more PC?</a>
    </div>
</asp:Content>
