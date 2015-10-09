<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="RedactDevice.aspx.cs" Inherits="SmartHouseWebForms.RedactDevice" %>

<%@ MasterType VirtualPath="~/Main.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTools" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="panAdd" DefaultButton="btnRedactRoom"
        GroupingText="Редактировать комнату">
        <asp:DropDownList ID="ddlRedactRoom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRedactRoom_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox ID="tbNewRoom" runat="server" placeholder="Новое имя комнаты"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnRedactRoom" runat="server" Text="Изменить" OnClick="btnRedactRoom_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="panAdd" DefaultButton="btnRedactDev"
        GroupingText="Редактировать устройство">
        <asp:DropDownList ID="ddlRoom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoom_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlDevice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDevice_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox ID="tbNewDev" runat="server" placeholder="Новое имя устройства"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnRedactDev" runat="server" Text="Изменить" />
    </asp:Panel>
</asp:Content>
