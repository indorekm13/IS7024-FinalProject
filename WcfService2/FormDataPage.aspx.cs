using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace WcfService2
{

    public partial class FormDataPage : System.Web.UI.Page
    {

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            UserForm details = new UserForm();
            details.FirstName = firstName.Text.ToLower();
            details.LastName = lastName.Text.ToLower();

            //Convert to json
            string displayData = JsonConvert.SerializeObject(details);

            DisplayData.Text = displayData;

        }
    }

}
