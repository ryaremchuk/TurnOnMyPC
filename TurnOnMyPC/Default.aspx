<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="Site.Master" Inherits="TurnOnMyPC.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="Body">
    <div class="Title">
        Enter your PC Name:
    </div>
    <div class="Description">
        <asp:TextBox runat="server" ID="txtPcName" Width="250px" ></asp:TextBox>
        <br/>
        <asp:Button runat="server" ID="btnCheckName" Text="Next" Width="100px" OnClick="btnCheckName_OnClick"/>
    </div>
    <asp:Panel runat="server" ID="pnlError" CssClass="Error" Width="250px" Visible="False">
        Can not find such PC.<br/>
        Please try another one.
    </asp:Panel>
</asp:Content>
