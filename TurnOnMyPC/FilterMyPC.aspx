<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilterMyPC.aspx.cs" MasterPageFile="Site.Master" Inherits="TurnOnMyPC.FilerMyPC" %>

<asp:Content runat="server" ContentPlaceHolderID="Body">
    <div class="Title">
        Enter your domain login:
    </div>
    <div class="Description">
        <asp:TextBox runat="server" ID="txtLogin" Width="250px" ></asp:TextBox>
        <br/>
        <asp:Button runat="server" ID="btnEnterLogin" Text="Next" Width="25%" Style="max-width: 100px" OnClick="btnEnterLogin_OnClick"/>
    </div>
    <asp:Panel runat="server" ID="pnlError" CssClass="Error" Width="250px" Visible="False">
        Can not find such user.<br/>
        Please try another one.
    </asp:Panel>
</asp:Content>
