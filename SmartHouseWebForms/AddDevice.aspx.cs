using System;
using System.Linq;
using System.Web.UI;
using SmartHouseDll;

namespace SmartHouseWebForms
{
    public partial class AddDevice : Page
    {
        private House _house;

        protected void Page_Load(object sender, EventArgs e)
        {
            _house = Master.Home;

            btAddDev.Click += btAddDev_Click;            
                                   
            if (!IsPostBack)
            {
                var commands = from c in _house.Remote.Commands.Values
                    where c.Name.StartsWith("add") & !c.Inform.Contains("комнату")
                    select c.Inform.Replace("Добавить ", string.Empty);

                ddlDevice.DataSource = commands;
                ddlDevice.DataBind();

                ddlRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
                ddlRoom.DataBind();
            }
        }

        protected void btAddDev_Click(object sender, EventArgs e)
        {

            _house.Remote.Reader.DeviceData = tbAddDev.Text;
            _house.Remote.Reader.RoomData = ddlRoom.SelectedValue;

            var command = from c in _house.Remote.Commands.Values
                    where c.Inform.Contains("Добавить " + ddlDevice.SelectedValue)
                    select c.Name;

            _house.Remote.Reader.CommandData = command.First();
            _house.Remote.PushButton();


            tbAddDev.Text = "";
            Master.IsRedact = true;
        }

        protected void btnAddRoom_Click(object sender, EventArgs e)
        {
            _house.Remote.Reader.DeviceData = String.Empty;
            _house.Remote.Reader.RoomData = tbAddRoom.Text;
            _house.Remote.Reader.CommandData = "addRom";
            _house.Remote.PushButton();


            tbAddRoom.Text = "";
            Master.IsRedact = true;

            ddlRoom.DataSource = _house.Rooms.Values.Select(c => c.Name);
            ddlRoom.DataBind();
        }   
    }
}