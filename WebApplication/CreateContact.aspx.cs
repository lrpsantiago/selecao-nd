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
    public partial class CreateContact : System.Web.UI.Page
    {
        private ContactBusiness m_contactBusiness;
        private int m_personId;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_contactBusiness = new ContactBusiness();
            m_personId = Convert.ToInt32(Request["id"]);

            if (!this.IsPostBack)
            {
                this.FillDropDownList();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPerson.aspx?id=" + m_personId);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string value = this.tbValue.Text.Trim();

            if (!string.IsNullOrEmpty(value))
            {
                Contact contact = new Contact();
                contact.PersonId = m_personId;
                contact.Type = (ContactType)Convert.ToInt32(this.ddlType.SelectedValue);
                contact.Value = value;

                m_contactBusiness.Add(contact);
                Response.Redirect("EditPerson.aspx?id=" + m_personId);
            }
            else
            {
                this.lblRequired.Visible = true;
            }
        }

        private void FillDropDownList()
        {
            for (int i = 0; i < (int)ContactType.Count; i++)
            {
                string name = ((ContactType)i).ToString();

                ListItem item = new ListItem(name, i.ToString());
                this.ddlType.Items.Add(item);
            }
        }
    }
}