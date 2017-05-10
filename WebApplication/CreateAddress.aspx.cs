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
    public partial class CreateAddress : System.Web.UI.Page
    {
        private AddressBusiness m_addressBusiness;
        private int m_personId;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_addressBusiness = new AddressBusiness();
            m_personId = Convert.ToInt32(Request["id"]);

            if(!this.IsPostBack)
            {
                this.FillTypeDropDownList();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPerson.aspx?id=" + m_personId);
        }

        private void FillTypeDropDownList()
        {
            for (int i = 0; i < (int)AddressType.Count; i++)
            {
                string name = ((AddressType)i).ToString();

                ListItem item = new ListItem(name, i.ToString());
                this.ddlType.Items.Add(item);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string streetName = this.tbStreetName.Text.Trim();
            string number = this.tbNumber.Text.Trim();

            if (!string.IsNullOrEmpty(streetName) && !string.IsNullOrEmpty(number))
            {
                Address address = new Address();
                address.PersonId = m_personId;
                address.StreetName = streetName;
                address.Number = Convert.ToInt32(number);
                address.Complement = this.tbComplement.Text.Trim();
                address.District = this.tbDistrict.Text.Trim();
                address.City = this.tbCity.Text.Trim();
                address.State = this.tbState.Text.Trim();

                m_addressBusiness.Add(address);
                Response.Redirect("EditPerson.aspx?id=" + m_personId);
            }
            else
            {
                this.lblRequired.Visible = true;
                this.lblRequiredNum.Visible = true;
            }
        }
    }
}