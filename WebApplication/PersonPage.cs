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
    public abstract class PersonPage : System.Web.UI.Page
    {
        private PersonBusiness m_personBusiness;
        private MarkerBusiness m_markerBusiness;

        protected PersonBusiness PersonBusiness
        {
            get { return m_personBusiness; }
        }

        protected MarkerBusiness MarkerBusiness
        {
            get { return m_markerBusiness; }
        }

        protected Person CurrentPerson { get; set; }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            m_personBusiness = new PersonBusiness();
            m_markerBusiness = new MarkerBusiness();
            string param = Request["id"];

            if (!string.IsNullOrEmpty(param))
            {
                int personId = Convert.ToInt32(param);

                try
                {
                    this.CurrentPerson = m_personBusiness.Get(personId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                this.NoParameterAction();
            }
        }

        protected void FillAddressesGridView(GridView gridView, List<Address> addresses)
        {
            if (addresses.Count > 0)
            {
                gridView.DataSource = addresses;
                gridView.DataBind();
            }
        }

        protected void FillContactsGridView(GridView gridView, List<Contact> contacts)
        {
            if (contacts.Count > 0)
            {
                gridView.DataSource = contacts;
                gridView.DataBind();
            }
        }

        protected void FillMarkerDropDownList(DropDownList dropDownList)
        {
            List<Marker> markers = new List<Marker>(m_markerBusiness.GetAll());
            markers.Insert(0, new Marker() { Id = 0, Description = "Nenhum" });

            dropDownList.DataValueField = "Id";
            dropDownList.DataTextField = "Description";
            dropDownList.DataSource = markers;
            dropDownList.DataBind();
        }

        protected abstract void NoParameterAction();
    }
}