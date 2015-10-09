<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="AddDevice.aspx.cs" Inherits="SmartHouseWebForms.AddDevice" %>

<%@ MasterType VirtualPath="~/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTools" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panAdd" DefaultButton="btnAddRoom"
        GroupingText="Добавить комнату">
        <asp:TextBox ID="tbAddRoom" runat="server" placeholder="Имя комнаты"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAddRoom" runat="server" Text="Добавить" OnClick="btnAddRoom_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="panAdd" DefaultButton="btAddDev"
        GroupingText="Добавить устройство">
        <asp:DropDownList ID="ddlRoom" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlDevice" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox ID="tbAddDev" runat="server" placeholder="Имя устройства"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btAddDev" runat="server" Text="Добавить" />
    </asp:Panel>
</asp:Content>
