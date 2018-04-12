<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrationCRUD.aspx.cs" Inherits="BigPrintWebsite.ExercisePages.RegistrationCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="col-md-12">
        <asp:Label ID="Label5" runat="server" Text="Select a serial number"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="RegistrationList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
             <asp:Button ID="Search" runat="server" Text="Search"  />&nbsp;&nbsp;
             <asp:Button ID="Clear" runat="server" Text="Clear" Height="26px" Width="63px" />&nbsp;&nbsp;    
        <br /><br />
        <asp:Label ID="Message" runat="server"></asp:Label>
        <br /><br />
    </div>

</asp:Content>
