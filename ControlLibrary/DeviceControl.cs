using SmartHouseDll;

namespace ControlLibrary
{
    class DeviceControl 
    {
        private DataForControl _data;

        public DeviceControl(DataForControl data)
        {
            _data = data;
        }

        public void Click()
        {
            _data.House.Remote.Reader.DeviceData = _data.Device.NameId;
            _data.House.Remote.Reader.RoomData = _data.Room.NameId;
            if (_data.Device.State == StateOnOff.Off)
            {
                _data.House.Remote.Reader.CommandData = "on";
            }
            else
            {
                _data.House.Remote.Reader.CommandData = "off";
            }

            _data.House.Remote.PushButton();
        }

        public void Click(string command)
        {
            _data.House.Remote.Reader.DeviceData = _data.Device.NameId;
            _data.House.Remote.Reader.RoomData = _data.Room.NameId;
            _data.House.Remote.Reader.CommandData = command;
            _data.House.Remote.PushButton();
        }
        
    }
}
