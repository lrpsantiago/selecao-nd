using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class CreatePerson : System.Web.UI.Page
    {
        private PersonBusiness m_personBusiness;
        private MarkerBusiness m_markerBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_personBusiness = new PersonBusiness();
            m_markerBusiness = new MarkerBusiness();

            if (!this.IsPostBack)
            {
                this.FillMarkerDropDownList(this.ddlMarker);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = this.tbName.Text.Trim();

            if (!string.IsNullOrEmpty(name))
            {
                Person p = new Person();
                p.Name = name;

                int markerId = Convert.ToInt32(this.ddlMarker.SelectedValue);
                p.Marker = markerId > 0 ? m_markerBusiness.Get(markerId) : null;

                m_personBusiness.Add(p);
                Response.Redirect("Home.aspx");
            }
            else
            {
                if (!this.lblRequired.Visible)
                {
                    this.lblRequired.Visible = true;
                }
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

            dropDownList.SelectedIndex = 0;
        }
    }
}