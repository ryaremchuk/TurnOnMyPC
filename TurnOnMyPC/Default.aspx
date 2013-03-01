<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="Site.Master" Inherits="TurnOnMyPC.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="Body">
    <asp:Panel runat="server" ID="pnlLogin">
        <div class="Title">
            Enter your domain login:
        </div>
        <div class="Description">
            <asp:TextBox runat="server" ID="txtLogin" Width="30%" ></asp:TextBox>
            <asp:Button runat="server" ID="btnEnterLogin" Text="Next" Width="100" OnClick="btnEnterLogin_OnClick"/>
        </div>
    </asp:Panel>
        
    <asp:Panel runat="server" ID="pnlPCStatus">
        <div class="Title">
            Your PC: <asp:Label runat="server" ID="lblPCName"></asp:Label>
        </div>
        <div class="Description">
            Status: <asp:Label Font-Bold="True" runat="server" ID="lblPCStatus"></asp:Label>
            <br/>
            <asp:Button runat="server" ID="btnTurnOn" Text="Turn it on!" Width="100" OnClick="btnTurnOn_OnClick"/>
        </div>
    </asp:Panel>
</asp:Content>
