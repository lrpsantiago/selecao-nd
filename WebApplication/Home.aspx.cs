using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Home : System.Web.UI.Page
    {
        private PersonBusiness m_personBusiness;
        private MarkerBusiness m_markerBusiness;
        private bool m_orderByName;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_orderByName = this.ddlOrderBy.SelectedIndex == 0;

            m_personBusiness = new PersonBusiness();
            m_markerBusiness = new MarkerBusiness();

            try
            {
                this.RefreshGrid();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.RefreshGrid();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        protected void gvPersons_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)this.gvPersons.DataSource;
                GridViewRow row = e.Row;
                string name = dt.Rows[row.RowIndex]["Name"].ToString();
                int lastIndex = row.Cells.Count - 1;
                LinkButton deleteButton = (LinkButton)row.Cells[lastIndex].Controls[0];

                deleteButton.OnClientClick = string.Format(
                    "return confirm('Deseja mesmo apagar {0} da sua lista?');", name);
            }
        }

        private void FillPersonsGridView(List<Person> persons)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Marker", typeof(string)));

            foreach (var person in persons)
            {
                DataRow row = dt.NewRow();
                row["Id"] = person.Id;
                row["Name"] = person.Name;

                if (person.Marker != null)
                {
                    row["Marker"] = person.Marker.Description;
                }
                else
                {
                    row["Marker"] = "-";
                }

                dt.Rows.Add(row);
            }

            this.gvPersons.DataSource = dt;
            this.gvPersons.DataBind();
        }

        protected void gvPersons_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeletePerson")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                DataTable dt = (DataTable)this.gvPersons.DataSource;
                DataRow row = dt.Rows[rowIndex];

                int personId = Convert.ToInt32(row["Id"]);
                Person p = new Person { Id = personId };

                m_personBusiness.Remove(p);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreatePerson.aspx");
        }

        private void RefreshGrid()
        {
            string name = this.tbSearch.Text.Trim();
            List<Person> persons;

            if (!string.IsNullOrEmpty(name))
            {
                if (m_orderByName)
                {
                    persons = m_personBusiness.GetByName(name);
                }
                else
                {
                    persons = m_personBusiness.GetByNameOrderedByMarker(name);
                }
            }
            else
            {
                if (m_orderByName)
                {
                    persons = m_personBusiness.GetAllOrderedByName();
                }
                else
                {
                    persons = m_personBusiness.GetAllOrderedByMarker();
                }
            }

            this.FillPersonsGridView(persons);
        }

        protected void ddlOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_orderByName = this.ddlOrderBy.SelectedIndex == 0;
            this.RefreshGrid();
        }
    }
}