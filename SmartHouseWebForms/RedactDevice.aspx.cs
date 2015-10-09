using System;
using System.Linq;
using System.Web.UI;
using SmartHouseDll;

namespace SmartHouseWebForms
{
    public partial class RedactDevice : Page
    {
        private House _house;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRedactDev.Click += btnRedactDev_Click;

            _house = Master.Home;    

            if (!IsPostBack)
            {
                ddlRedactRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
                ddlRedactRoom.DataBind();

                ddlRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
                ddlRoom.DataBind();

                ddlDevice.DataSource = _house.GetRoom(ddlRoom.SelectedValue).Devices.Values.Select(c => c.Name);
                ddlDevice.DataBind();
            }
        }

        protected void btnRedactRoom_Click(object sender, EventArgs e)
        {
            _house.ChangeNameRoom(ddlRedactRoom.SelectedValue, tbNewRoom.Text);
           
            tbNewRoom.Text = "";
            Master.IsRedact = true;

            ddlRedactRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
            ddlRedactRoom.DataBind();

            ddlRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
            ddlRoom.DataBind();
        }
        protected void btnRedactDev_Click(object sender, EventArgs e)
        {
            _house.ChangeNameDevice(ddlRoom.SelectedValue, ddlDevice.SelectedValue, tbNewDev.Text);

            ddlDevice.DataSource = _house.GetRoom(ddlRoom.SelectedValue).Devices.Values.Select(c => c.Name);
            ddlDevice.DataBind();

            tbNewDev.Text = "";
            Master.IsRedact = true;
        }


        protected void ddlRedactRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNewRoom.Text = ddlRedactRoom.SelectedValue;
        }

        protected void ddlRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDevice.DataSource = _house.GetRoom(ddlRoom.SelectedValue).Devices.Values.Select(c => c.Name);
            ddlDevice.DataBind();
        }
        protected void ddlDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNewDev.Text = ddlDevice.SelectedValue;
        }   
    }
}