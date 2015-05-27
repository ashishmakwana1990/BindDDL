using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Server=f7e81d0d-7324-469a-9aa8-a4a5007542a1.sqlserver.sequelizer.com;Database=dbf7e81d0d7324469a9aa8a4a5007542a1;User ID=csqdfekygpbewqwb;Password=hZqTtC64ouvAWuPvdndGF4pczUE3axiKUwCezCaJUT22W5i34QfNHtDmJntG7c3Y;");


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            FillState();           
        }
    }

    private void FillState()
    {
        SqlCommand cmd = new SqlCommand("select * from State", conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        ddlstate.DataSource = dr;
        ddlstate.DataTextField = "sname";
        ddlstate.DataValueField = "sid";
        ddlstate.DataBind();
        
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "---Select State---";
        ddlstate.Items.Insert(0, li);
        conn.Close();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(ddlstate.SelectedValue);
        SqlCommand cmd = new SqlCommand("select * from city where sid='"+id+"'", conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        ddlcity.DataSource = dr;
        ddlcity.DataTextField = "cname";
        ddlcity.DataValueField = "cid";
        ddlcity.DataBind();

        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "---Select City---";
        ddlcity.Items.Insert(0, li);
        conn.Close();
    }
}