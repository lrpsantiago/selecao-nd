using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class DetailsPage : PersonPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.FillMarkerDropDownList(this.ddlMarker);
            this.tbName.Text = this.CurrentPerson.Name;

            if (this.CurrentPerson.Marker != null)
            {
                this.ddlMarker.SelectedValue = this.CurrentPerson.Marker.Id.ToString();
            }

            this.FillAddressesGridView(this.gvAddresses, this.CurrentPerson.Addresses);
            this.FillContactsGridView(this.gvContacts, this.CurrentPerson.Contacts);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string param = Request["id"];

            if (!string.IsNullOrEmpty(param))
            {
                Response.Redirect("EditPerson.aspx?id=" + param);
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected override void NoParameterAction()
        {
            Response.Redirect("Home.aspx");
        }
    }
}