using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using HTPSSystem.JMont.BLL;
using HTPSSystem.JMont.Data.Entities;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
#endregion

namespace BigPrintWebsite.ExercisePages
{
    public partial class ProductCRUD : System.Web.UI.Page
    {
        //a data collection to hold multipe strings
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

            MessageList.DataSource = null;
            MessageList.DataBind();
            //MessageList.Text = "";
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

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            MessageList.CssClass = cssclass;
            MessageList.DataSource = errormsglist;
            MessageList.DataBind();
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
                errormsgs.Add("Select a product to search.");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
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
                        errormsgs.Add("Product not found. Try again");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");

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
                    errormsgs.Add(GetInnerException(ex).ToString()); // why converrted to string
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
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

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                Product item = new Product();
                item.Name = Name.Text;
                item.ModelNumber = ModelNumber.Text;

                item.Discontinued = Discontinued.Checked;
                ProductController sysmgr = new ProductController();

                int pkey = sysmgr.Product_Add(item);


                ProductID.Text = pkey.ToString();
                errormsgs.Add("Product was added");
                LoadMessageDisplay(errormsgs, "alert alert-success");

                ProductsDataBind();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                if (updateException.InnerException != null)
                {
                    errormsgs.Add(updateException.InnerException.Message.ToString());
                }
                else
                {
                    errormsgs.Add(updateException.Message);
                }
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        errormsgs.Add(validationError.ErrorMessage);
                    }
                }
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
           
            if (Page.IsValid)
            {
                if (string.IsNullOrEmpty(ProductID.Text))
                {
                    errormsgs.Add("Update requires you to search for the product first.");
                }
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(ProductID.Text, out temp))
                {
                    errormsgs.Add("Invalid Product ID");
                }
            }
            try
            {
                ProductController sysmgr = new ProductController();

                Product item = new Product();
                item.ProductID = int.Parse(ProductID.Text);
                item.Name = Name.Text;
                item.ModelNumber = ModelNumber.Text;

                item.Discontinued = Discontinued.Checked;
                if (Discontinued.Checked)
                {
                    //if(!string.IsNullOrEmpty(DiscontinuedDate.Text))
                        item.DiscontinuedDate = DateTime.Now;
                }
         
                int rowsaffect = sysmgr.Product_Update(item);
                //    or if no rows were changed
                if (rowsaffect > 0)
                {
                    errormsgs.Add("Product was updated");
                    LoadMessageDisplay(errormsgs, "alert alert-success");

                    //remember to refresh any other necessary associated controls
                    ProductsDataBind();
                    ProductList.SelectedValue = ProductID.Text;
                }
                else
                {
                    errormsgs.Add("Product does not appear to be on file. Look up the product again.");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                    ProductsDataBind();
                }
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                if (updateException.InnerException != null)
                {
                    errormsgs.Add(updateException.InnerException.Message.ToString());
                }
                else
                {
                    errormsgs.Add(updateException.Message);
                }
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        errormsgs.Add(validationError.ErrorMessage);
                    }
                }
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductID.Text))
            {
                errormsgs.Add("Delete requires you to search for the product first.");
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(ProductID.Text, out temp))
                {
                    errormsgs.Add("Product ID is invalid");
                }
            }
            if (errormsgs.Count() > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {


                try
                {
                    ProductController sysmgr = new ProductController();

                    //method call returns the number of rows affected
                    int rowsaffect = sysmgr.Product_Delete(int.Parse(ProductID.Text));

                    //if the call was successful and changed rows
                    //    or if no rows were changed
                    if (rowsaffect > 0)
                    {
                        errormsgs.Add("Product is discontinued");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        ProductsDataBind();
                        //reposition
                        ProductList.SelectedValue = ProductID.Text;
                        
                        Discontinued.Checked = true;
                    }
                    else
                    {
                        errormsgs.Add("Product does not appear to be on file. Look up the product again.");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                        ProductsDataBind();
                    }
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }

        }

    }
}