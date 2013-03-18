<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPC.aspx.cs" Inherits="TurnOnMyPC.MyPC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
         <div class="Title">
            My PC: <asp:Label runat="server" ID="lblPCName"></asp:Label>
        </div>
        <div class="Description">
            Status: <asp:Label Font-Bold="True" runat="server" ID="lblPCStatus"></asp:Label>
            <br/>
            <asp:Button runat="server" ID="btnTurnOn" Text="Turn it on!" Width="100" OnClick="btnTurnOn_OnClick"/>
        </div>
</asp:Content>
