<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerCRUD.aspx.cs" Inherits="BigPrintWebsite.ExercisePages.CustomerCRUD"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12">
        <asp:Label ID="Label5" runat="server" Text="Select a customer"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="CustomerList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
             <asp:Button ID="Search" runat="server" Text="Search"  />&nbsp;&nbsp;
             <asp:Button ID="Clear" runat="server" Text="Clear" Height="26px" Width="63px" />&nbsp;&nbsp;    
        <br /><br />
        <asp:Label ID="Message" runat="server"></asp:Label>
        <br /><br />
    </div>

    <div class ="col-md-12">
        <fieldset class="form-horizontal">
        <legend>Customer Information</legend>

            <asp:Label ID="Label1" runat="server" Text="Customer ID"
                 AssociatedControlID="CustomerID"></asp:Label>
            <asp:Label ID="CustomerID" runat="server" ></asp:Label> 

             <asp:Label ID="Label2" runat="server" Text="First Name"
                  AssociatedControlID="FirstName"></asp:Label>
             <asp:TextBox ID="FirstName" runat="server" ></asp:TextBox> 


        </fieldset>



    </div>

</asp:Content>
