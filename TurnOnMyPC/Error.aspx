<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" MasterPageFile="Site.Master" Inherits="TurnOnMyPC.Error" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style>
        body
        {
            background-color: #ee6666;
        }
    </style>
    
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Body">
    <div class="Title">
        Oooops....<br/>
        Some troubles happend. Please contact system administrator :)
    </div>
    <div class="Description">
        <a href="Default.aspx">Try to turn one more time?</a>
    </div>
</asp:Content>
