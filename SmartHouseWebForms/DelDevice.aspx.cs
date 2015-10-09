using System;
using System.Linq;
using System.Web.UI;
using SmartHouseDll;

namespace SmartHouseWebForms
{
    public partial class DelDevice : Page
    {
        private House _house;

        protected void Page_Load(object sender, EventArgs e)
        {
            _house = Master.Home;              

            if (!IsPostBack)
            {
                ddlDelRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
                ddlDelRoom.DataBind();

                ddlRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
                ddlRoom.DataBind();

                ddlDevice.DataSource = _house.GetRoom(ddlRoom.SelectedValue).Devices.Values.Select(c => c.Name);
                ddlDevice.DataBind();
            }
        }

        protected void btnDelRoom_Click(object sender, EventArgs e)
        {
            _house.Remote.Reader.DeviceData = "";
            _house.Remote.Reader.RoomData = ddlDelRoom.SelectedValue;
            _house.Remote.Reader.CommandData = "delRom";
            _house.Remote.PushButton();

            btnDelRoom.Text = "Удалить";
            btnDelRoom.Enabled = false;

            Master.IsRedact = true;
        }
        protected void btDelDev_Click(object sender, EventArgs e)
        {

            _house.Remote.Reader.DeviceData = ddlDevice.SelectedValue;
            _house.Remote.Reader.RoomData = ddlRoom.SelectedValue;
            _house.Remote.Reader.CommandData = "delDev";
            _house.Remote.PushButton();

            btDelDev.Text = "Удалить";
            btDelDev.Enabled = false;

            Master.IsRedact = true;
        }

        protected void ddlDelRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelRoom.Text = "Удалить комнату " + ddlDelRoom.SelectedValue;
            btnDelRoom.Enabled = true;
        }       

        protected void ddlRoom_SelectedIndexChanged(object sender, EventArgs e)
        {            
            ddlDevice.DataSource = _house.GetRoom(ddlRoom.SelectedValue).Devices.Values.Select(c => c.Name);
            ddlDevice.DataBind();
        }
        protected void ddlDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            btDelDev.Text = "Удалить  " + ddlDevice.SelectedValue + "  из  " + ddlRoom.SelectedValue;
            btDelDev.Enabled = true;
        }


    }
}