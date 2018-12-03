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
            details.Character = charName.Text.ToLower();
            details.Actor = actorName.Text.ToLower();
            details.House = houseName.Text.ToLower();
            details.DOA = DOA.Text.ToLower();

            //Convert to json
            string displayData = JsonConvert.SerializeObject(details);
            DisplayData.Text = displayData;

        }
    }

}
