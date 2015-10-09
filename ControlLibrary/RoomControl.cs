using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseDll;

namespace ControlLibrary
{
    public class RoomControl : CompositeControl
    {
        private House _house;
        private Room _room;
        
        private Panel _panel;
        private Label _label;

        public RoomControl(House house, Room room)
        {
            _room = room;
            _house = house;
            _panel = new Panel();
        }

        protected override void CreateChildControls()
        {
            if (DesignMode) // Если дизайнер Visual Studio
            {
                Label label = new Label {Text = "[RoomControl]"};
                Controls.Add(label);
            }
            else // Если проект выполняется
            {
                CreateControls();
            }

            base.CreateChildControls();
        }

        private void Add(Control control)
        {
            if (control != null)
                _panel.Controls.Add(control);
        }
        private void CreateControls()
        {
            _label = new Label();
            _label.Text = _room.Name;
            _label.CssClass = "labelRoom";
            _panel.Controls.AddAt(0, _label);

            foreach (Device device in _room.Devices.Values.OrderBy(p => p.GetType().FullName))
            {
                Add(CreateControl(device));
            }
          
            Controls.Add(_panel);
        }

        private Control CreateControl(Device device)
        {
            DataForControl data = new DataForControl(_house, _room, device);

            if (device is Lamp)
            {
                return new LampControl(data);
            }
            if (device is ClimatControl)
            {
                return new ClimatControlControl(data);
            }
            if (device is Tv)
            {
                return new TvControl(data);
            }
            return null;
        } 
    }
}
