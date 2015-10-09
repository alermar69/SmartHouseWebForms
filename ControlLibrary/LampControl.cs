using System;
using System.Web.UI.WebControls;
using SmartHouseDll;

namespace ControlLibrary
{
    public class LampControl : CompositeControl
    {
        private Panel _panel;
        private Label _label;
        private ImageButton _imBt;
        private Image _image;
        private LightContol _lightContol;

        private DeviceControl _device;
        private DataForControl _data;
        

        public LampControl(DataForControl data)
        {
            _data = data;
            _device = new DeviceControl(_data);
        }

        protected override void CreateChildControls()
        {
            if (DesignMode) // Если дизайнер Visual Studio
            {
                Label label = new Label();
                label.Text = "[LampControl]";
                Controls.Add(label);
            }
            else // Если проект выполняется
            {
                CreateControls();
            }

            base.CreateChildControls();
        }

        private void CreateControls()
        {
            _panel = new Panel();
            _panel.ID = "panel";
            _panel.CssClass = "panLamp";

            _label = new Label();
            _label.Text = _data.Device.Name;
            _label.CssClass = "nameDevice";
            _panel.Controls.Add(_label);

            _image = new Image();
            _image.CssClass = "imgBt";
            _panel.Controls.Add(_image);

            _imBt = new ImageButton();
            _imBt.CssClass = "imgBt";                     
            _imBt.Click += imBt_Click;
            _panel.Controls.Add(_imBt);

            _lightContol = new LightContol(_data);
            _panel.Controls.Add(_lightContol);

            SetImageUrl();

            Controls.Add(_panel);
        }



        private void imBt_Click(object sender, EventArgs e)
        {
            _device.Click();

            SetImageUrl();
        }

        private void SetImageUrl()
        {
            if (_data.Device.State == StateOnOff.Off)
            {
                _imBt.ImageUrl = "~/Images/control_power.png";
                _image.ImageUrl = "~/Images/lightbulb.png";
            }
            else
            {
                _imBt.ImageUrl = "~/Images/control_power_blue.png";
                _image.ImageUrl = "~/Images/lightbulb_on.png";
            }
        }
    }
}
