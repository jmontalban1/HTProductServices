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
    public partial class RegistrationCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sende, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                RegistrationDataBind();
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

        protected void RegistrationDataBind()
        {
            RegistrationController sysmgr = new RegistrationController();

                List<Registration> info = sysmgr.Registration_List();

            //inform control of the data source
            RegistrationList.DataSource = info;
            //set the DisplayText and ValueText fields to the
            //    appropriate Property names in the Entity
            RegistrationList.DataTextField = "SerialNumber";
            //CustomerList.DataTextField = "Email";
            //CustomerList.DataTextField = "ContactNumber";
            //physically attach data to control
            RegistrationList.DataBind();

        }

    }
}