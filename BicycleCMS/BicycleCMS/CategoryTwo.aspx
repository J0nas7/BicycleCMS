<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOne.Master" AutoEventWireup="true" CodeBehind="~/CategoryOne.aspx.cs" Inherits="BicycleCMS.CategoryOne" Theme="ThemeCategoryTwo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ChildPage CategoryTwo">
        <h1>
            <asp:Label ID="Headline" SkinId="H1Skin" runat="server" Text=""></asp:Label>
        </h1>
        <p><asp:Label ID="CatDescription" runat="server" Text=""></asp:Label></p>
    </div>
</asp:Content>
