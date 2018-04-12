using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using HTPSSystem.JMont.BLL;
using HTPSSystem.JMont.Data.Entities;
#endregion

namespace BigPrintWebsite.ExercisePages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                ProductsDataBind();
            }
        }
        protected Exception GetInnerException(Exception ex)
        {
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void ProductsDataBind()
        {
            //the web page needs to access the BLL class method
            //   to obtain its data
            ProductController sysmgr = new ProductController();
            //get the actual data
            List<Product> info = sysmgr.Product_List();

            //inform control of the data source
            ProductList.DataSource = info;
            //set the DisplayText and ValueText fields to the
            //    appropriate Property names in the Entity
            ProductList.DataTextField = "Name";
            ProductList.DataValueField = "ProductID";
            //physically attach data to control
            ProductList.DataBind();
            ProductList.Items.Insert(0, "select ...");
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            //does my search value exist
            //search values may come from textboxes, dropdownlists,
            //    radiobuttonlists, etc.
            //check to see if you have a search value
            if (ProductList.SelectedIndex == 0)
            {
                //ProductList has a prompt line at index 0
                Message.Text = "Select a product to search.";
            }
            else
            {
                //product was selected

                //check any other requirements that may be part
                //   of your search criteria

                //if all is good, do a standard pattern lookup
                try
                {
                    ProductController sysmgr = new ProductController();
                    //call the desired method
                    Product info = sysmgr.Product_Find(int.Parse(ProductList.SelectedValue));
                    //check the result of the method execution
                    //if the record was not found, the Product instance
                    //     will be null
                    if (info == null)
                    {
                        Message.Text = "Product not found. Try again";
        
                        ProductsDataBind();
                    }
                    else
                    {
                        //record was found
                        //load the web form controls with the data
                        //  that was returned
                        //controls are loaded with datatype string
                        ProductID.Text = info.ProductID.ToString();
                        Name.Text = info.Name;
                        ModelNumber.Text = info.ModelNumber;


                        //Discontinued is a checkbox which is a bool set
                        Discontinued.Checked = info.Discontinued;
                    }
                }
                catch (Exception ex)
                {
                    Message.Text = GetInnerException(ex).Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ProductID.Text = "";
            Name.Text = "";
            ModelNumber.Text = "";

            Discontinued.Checked = false;
        }





    }
}