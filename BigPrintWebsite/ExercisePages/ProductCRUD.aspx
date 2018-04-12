<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCRUD.aspx.cs" Inherits="BigPrintWebsite.ExercisePages.ProductCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12">
        <asp:Label ID="Label5" runat="server" Text="Select a product"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="ProductList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
             <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click"  />&nbsp;&nbsp;
             <asp:Button ID="Clear" runat="server" Text="Clear" Height="26px" Width="63px" OnClick="Clear_Click" />&nbsp;&nbsp;    
        <br /><br />
        <asp:Label ID="Message" runat="server"></asp:Label>
        <br /><br />
    </div>


     <div class ="col-md-12">
        <fieldset class="form-horizontal">
        <legend>Product Information</legend>

            <asp:Label ID="Label1" runat="server" Text="Product ID"
                 AssociatedControlID="ProductID"></asp:Label>
            <asp:Label ID="ProductID" runat="server" ></asp:Label> 

             <asp:Label ID="Label2" runat="server" Text="Name"
                  AssociatedControlID="Name"></asp:Label>
             <asp:TextBox ID="Name" runat="server" ></asp:TextBox> 

               <asp:Label ID="Label3" runat="server" Text="Model Number"
                  AssociatedControlID="ModelNumber"></asp:Label>
             <asp:TextBox ID="ModelNumber" runat="server" ></asp:TextBox> 

              <asp:Label ID="Label4" runat="server" Text="Status"
                  AssociatedControlID="Discontinued"></asp:Label>
            <asp:CheckBox ID="Discontinued" runat="server" Text="Discontinued" ></asp:CheckBox> 

        </fieldset>
         </div>
        <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
