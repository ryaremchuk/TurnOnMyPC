<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllStatuses.aspx.cs" Inherits="TurnOnMyPC.AllStatuses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="Title">
        All Registered PC statuses:
    </div>

    <asp:Repeater runat="server" ID="rptData">
        <ItemTemplate>
            <%# Eval("PCName")%> (<%# Eval("State") %>) <br/>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
