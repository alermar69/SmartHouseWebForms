<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="DelDevice.aspx.cs" Inherits="SmartHouseWebForms.DelDevice" %>

<%@ MasterType VirtualPath="~/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTools" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panAdd" DefaultButton="btnDelRoom"
        GroupingText="Удалить комнату">
        <asp:DropDownList ID="ddlDelRoom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDelRoom_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnDelRoom" runat="server" Text="Удалить" Enabled="False" OnClick="btnDelRoom_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="panAdd" DefaultButton="btDelDev"
        GroupingText="Удалить устройство">
        <asp:DropDownList ID="ddlRoom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoom_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlDevice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDevice_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btDelDev" runat="server" Text="Удалить" Enabled="False" OnClick="btDelDev_Click" />
    </asp:Panel>
</asp:Content>
