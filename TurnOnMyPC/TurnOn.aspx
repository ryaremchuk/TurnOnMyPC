<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnOn.aspx.cs" Inherits="TurnOnMyPC.TurnOn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="Title">
            PC: <asp:Label runat="server" ID="lblPCName"></asp:Label>
        </div>
        <div class="Description">
            <asp:Label Font-Bold="True" runat="server" ID="lblStatusMessage"></asp:Label>
        </div>
</asp:Content>
