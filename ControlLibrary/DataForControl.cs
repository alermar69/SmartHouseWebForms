using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHouseDll;

namespace ControlLibrary
{
    public class DataForControl
    {
        private Device _device;
        private House _house;
        private Room _room;

        public DataForControl(House house, Room room, Device device)
        {
            _device = device;
            _house = house;
            _room = room;
        }

        public Device Device
        {
            get { return _device; }
            set { _device = value; }
        }

        public House House
        {
            get { return _house; }
            set { _house = value; }
        }

        public Room Room
        {
            get { return _room; }
            set { _room = value; }
        }
    }
}
