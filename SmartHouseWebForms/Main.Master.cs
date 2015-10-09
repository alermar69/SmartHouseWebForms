using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ControlLibrary;
using SmartHouseDll;

namespace SmartHouseWebForms
{
    public partial class Main : MasterPage, IWriter
    {
        public House Home { get; private set; }
        public bool IsRedact;

        protected void Page_Init(object sender, EventArgs e)
        {
            Home = SerDesHouse.Read();
            WebReader wbReader = new WebReader(Home);
            Home.Remote = new RemoteControl(wbReader, new List<IWriter> { this });
            Home.Remote.AddCommand(new SetLightCommand());

            IsRedact = false;

            RunSensor();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Home.Remote.Write();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (IsRedact)
            {
                Home.Remote.Write();
                IsRedact = false;
            }
            Page.MaintainScrollPositionOnPostBack = true;    
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Home.Remote.ClearDataCommand();
            SerDesHouse.Save(Home);
        }

        private void RunSensor()
        {
            foreach (Room room in Home.Rooms.Values)
            {
                foreach (ClimatControl climat in room.Devices.Values.Where(p => p is ClimatControl))
                {
                    Random random = new Random();

                    climat.SensorTemperat.CurrentTemperature =
                        random.Next(climat.Temperature - 3, climat.Temperature + 3);
                    climat.SensorHumid.CurrentHumidity =
                        random.Next(climat.Humidity - 3, climat.Humidity + 3);
                }
            }
        }

        public void Write(IDataCommand dataCommand)
        {
            panHouse.Controls.Clear();
            foreach (Room room in Home.Rooms.Values)
            {
                RoomControl roomControl = new RoomControl(Home, room);

                panHouse.Controls.Add(roomControl);
                panHouse.Controls.Add(new LiteralControl("<br />"));
                panHouse.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
}