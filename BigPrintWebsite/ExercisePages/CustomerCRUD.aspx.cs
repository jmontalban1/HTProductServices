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
    public partial class CustomerCRUD : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                CustomerDataBind();
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
        protected void CustomerDataBind()
        {
            //the web page needs to access the BLL class method
            //   to obtain its data
            CustomerController sysmgr = new CustomerController();
            //get the actual data
            List<Customer> info = sysmgr.Customers_List();

            //inform control of the data source
            CustomerList.DataSource = info;
            //set the DisplayText and ValueText fields to the
            //    appropriate Property names in the Entity
            CustomerList.DataTextField = "FullName";
            CustomerList.DataValueField = "CustomerID";
            //CustomerList.DataTextField = "Email";
            //CustomerList.DataTextField = "ContactNumber";
            //physically attach data to control
            CustomerList.DataBind();
        }
    }
}