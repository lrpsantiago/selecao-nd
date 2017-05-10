using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class EditPerson : PersonPage
    {
        private AddressBusiness m_addressBusiness;
        private ContactBusiness m_contactBusiness;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            m_addressBusiness = new AddressBusiness();
            m_contactBusiness = new ContactBusiness();

            if (!this.IsPostBack)
            {
                this.FillMarkerDropDownList(this.ddlMarker);

                if (this.CurrentPerson.Marker != null)
                {
                    this.ddlMarker.SelectedValue = this.CurrentPerson.Marker.Id.ToString();
                }

                this.tbName.Text = this.CurrentPerson.Name;
            }

            this.FillAddressesGridView(this.gvAddresses, this.CurrentPerson.Addresses);
            this.FillContactsGridView(this.gvContacts, this.CurrentPerson.Contacts);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveCurrentPerson();
        }

        private void SaveCurrentPerson()
        {
            if (this.CurrentPerson != null)
            {
                this.CurrentPerson.Name = this.tbName.Text.Trim();

                int markerId = Convert.ToInt32(this.ddlMarker.SelectedValue);
                this.CurrentPerson.Marker = this.MarkerBusiness.Get(markerId);

                if (!string.IsNullOrEmpty(this.CurrentPerson.Name))
                {
                    this.PersonBusiness.Update(this.CurrentPerson);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    this.lblRequired.Visible = true;
                }
            }
        }

        protected void btnNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAddress.aspx?id=" + this.CurrentPerson.Id);
        }

        protected void btnNewContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateContact.aspx?id=" + this.CurrentPerson.Id);
        }

        protected override void NoParameterAction()
        {
            this.CurrentPerson = new Person();
        }

        protected void gvAddresses_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteAddress")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                List<Address> list = (List<Address>)this.gvAddresses.DataSource;

                int personId = list[rowIndex].Id;
                Address address = new Address { Id = personId };

                m_addressBusiness.Remove(address);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void gvContacts_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteContact")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                List<Contact> list = (List<Contact>)this.gvContacts.DataSource;

                int personId = list[rowIndex].Id;
                Contact contact = new Contact { Id = personId };

                m_contactBusiness.Remove(contact);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void gvAddresses_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                int lastIndex = row.Cells.Count - 1;
                LinkButton deleteButton = (LinkButton)row.Cells[lastIndex].Controls[0];

                deleteButton.OnClientClick = string.Format(
                    "return confirm('Deseja mesmo apagar este endereço?');");
            }
        }

        protected void gvContacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                int lastIndex = row.Cells.Count - 1;
                LinkButton deleteButton = (LinkButton)row.Cells[lastIndex].Controls[0];

                deleteButton.OnClientClick = string.Format(
                    "return confirm('Deseja mesmo apagar este contato?');");
            }
        }
    }
}