<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Queue.aspx.cs" Inherits="TurnOnMyPC.Queue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="Title">
        Current queue to turn on:
    </div>
        <asp:Repeater runat="server" ID="rptData">
        <ItemTemplate>
            <%# Container.DataItem %><br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
