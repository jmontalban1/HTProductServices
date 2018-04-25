<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODS.aspx.cs" Inherits="BigPrintWebsite.ExercisePages.ODS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



        <div class="row">
    
        <asp:ObjectDataSource ID="CustomerListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Customers_List" TypeName="HTPSSystem.JMont.BLL.CustomerController"></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ProductListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Product_List" TypeName="HTPSSystem.JMont.BLL.ProductController"></asp:ObjectDataSource>

            </div>

    <hr style="width:5px" />
    <div class ="row">
        <div class="col-md-2">
            <asp:Label ID="Label3" runat="server" Text="Enter part Model Number"></asp:Label><br />
            <asp:TextBox ID="SearchModelNumber" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="SearchModel" runat="server" Text="Search" CssClass="btn btn-primary" />
           
        </div>
            

        <div class="col-md-10">

            <asp:GridView ID="RegistrationList" runat="server" AutoGenerateColumns="False"
                CssClass="table" GridLines="Horizontal" DataSourceID="Model" BorderStyle="None" AllowPaging="True">
                <Columns>
                   
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:DropDownList ID="ProductIDList" runat="server"
                                DataSourceID="ProductListODS"
                                DataTextField="FullInfo"
                                DataValueField="ProductID"
                                SelectedValue='<%# Eval("ProductID") %>'>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer">
                        <ItemTemplate>

                            <asp:DropDownList ID="CustumerIDList" runat="server"
                                DataSourceID="CustomerListODS"
                                DataTextField="FullName"
                                DataValueField="CustomerID"
                                SelectedValue='<%# Eval("CustomerID") %>'>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Serial Number">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server"
                                Text='<%# Eval("SerialNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DOP">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server"
                                Text='<%# Eval("DateOfPurchase") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stores">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server"
                                Text='<%# Eval("PurchasedFrom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data available for supplied product search string
                </EmptyDataTemplate>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
            </asp:GridView>
        </div>
                    <asp:ObjectDataSource ID="Model" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Registration_Model" TypeName="HTPSSystem.JMont.BLL.RegistrationController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="SearchModelNumber" PropertyName="Text" DefaultValue="wasdwasd" Name="modelnumber" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
    </div>

</asp:Content>
