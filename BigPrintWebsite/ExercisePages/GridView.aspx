﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="BigPrintWebsite.ExercisePages.GridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="col-md-12">
        <asp:Label ID="Label5" runat="server" Text="Select a product"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="ProductList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
             <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />&nbsp;&nbsp;
               

        <br />
        <br />
        <asp:DataList ID="MessageList" runat="server">
            <ItemTemplate>
                <%# Container.DataItem %>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
     

        <%-- validation --%>
  <%--      <asp:ValidationSummary ID="ProductValidation" runat="server"
            HeaderText="Please correct your input to resolve the following issues." />
        <asp:RequiredFieldValidator ID="RequiredFieldName" runat="server"
            ErrorMessage="Product Name is required."
            Display="None" ControlToValidate="Name" SetFocusOnError="True">
        </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldModelNumber" runat="server"
            ErrorMessage="Model Number is required."
            Display="None" ControlToValidate="ModelNumber" SetFocusOnError="True">s
        </asp:RequiredFieldValidator>--%>

        
        
        <div class="col-md-12">
            <fieldset class="form-horizontal">
                <legend>Product Information</legend>

                <asp:Label ID="Label1" runat="server" Text="Product ID"
                    AssociatedControlID="ProductID"></asp:Label>
                <asp:Label ID="ProductID" runat="server"></asp:Label>

                <asp:Label ID="Label2" runat="server" Text="Name"
                    AssociatedControlID="Name"></asp:Label>
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Model Number"
                    AssociatedControlID="ModelNumber"></asp:Label>
                <asp:TextBox ID="ModelNumber" runat="server"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Status"
                    AssociatedControlID="Discontinued"></asp:Label>
                <asp:CheckBox ID="Discontinued" runat="server" Text="Discontinued"></asp:CheckBox>
          
                 <asp:Label ID="Label6" runat="server" Text="Discontinued Date"
                     AssociatedControlID="DiscontinuedDate"></asp:Label>
                 <asp:TextBox ID="DiscontinuedDate" runat="server" PlaceHolder="dd/mm/year" Enabled="false"></asp:TextBox>

            </fieldset>
        </div>


        <%-- Gridview --%>
        
      <div class="col-md-12">
            <asp:GridView ID="RegistrationList" runat="server"  AutoGenerateColumns="False"
                CssClass="table" GridLines="Horizontal" BorderStyle="None" AllowPaging="True" OnPageIndexChanging="RegistrationList_PageIndexChanging" PageSize="5" >
                <Columns>
                    <asp:TemplateField HeaderText="Serial Number">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" 
                                Text='<%# Eval("SerialNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" 
                                Text='<%# Eval("DateOfPurchase") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sources">
                         <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" 
                                Text='<%# Eval("PurchasedFrom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Province">
                         <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" 
                                Text='<%# Eval("PurchaseProvince") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data available for supplied product search string
                </EmptyDataTemplate>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
            </asp:GridView>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
