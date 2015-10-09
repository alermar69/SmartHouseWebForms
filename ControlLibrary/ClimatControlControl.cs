using System;
using System.Web.UI.WebControls;
using SmartHouseDll;

namespace ControlLibrary
{
    public class ClimatControlControl : CompositeControl
    {
        private Panel _panel;
        private Label _label;
        private Label _labelTemper;
        private ImageButton _imBt;
        private ImageButton _imBtAuto;
        private ImageButton _imBtHot;
        private ImageButton _imBtCond;
        private Image _image;

        private TemperControl _temperControl;

        private DataForControl _data;
        private DeviceControl _device;

        public ClimatControlControl(DataForControl data)
        {
            _data = data;
            _device = new DeviceControl(_data);
        }

        protected override void CreateChildControls()
        {
            if (DesignMode) // Если дизайнер Visual Studio
            {
                Label label = new Label();
                label.Text = "[ClimatControl]";
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
            _panel.CssClass = "panLamp";

            _label = new Label();
            _label.Text = _data.Device.Name;
            _label.CssClass = "nameDevice";
            _panel.Controls.Add(_label);

            _image = new Image();
            _image.ImageUrl = "~/Images/hot.png";
            _image.CssClass = "imgBt";
            _panel.Controls.Add(_image);

            _imBt = new ImageButton();
            _imBt.CssClass = "imgBt";
            _imBt.Click += imBt_Click;
            _panel.Controls.Add(_imBt);           

            _labelTemper = new Label();
            _labelTemper.CssClass = "labelTemper";
            _labelTemper.Text = ((ClimatControl)_data.Device).SensorTemperat.CurrentTemperature + "°C";
            _panel.Controls.Add(_labelTemper);

            _imBtAuto = new ImageButton();
            _imBtAuto.CssClass = "imgBt";
            _imBtAuto.Click += imBtAuto_Click;
            _panel.Controls.Add(_imBtAuto);

            _imBtHot = new ImageButton();
            _imBtHot.ImageUrl = "~/Images/hot1.png";
            _imBtHot.Click += _imBtHot_Click;
            _panel.Controls.Add(_imBtHot);

            _imBtCond = new ImageButton();
            _imBtCond.ImageUrl = "~/Images/ice2.png";
            _imBtCond.Click += _imBtCond_Click;
            _panel.Controls.Add(_imBtCond);

            _temperControl = new TemperControl(_data);
            _panel.Controls.Add(_temperControl);

            SetImageUrl();

            Controls.Add(_panel);
        }

        private void imBt_Click(object sender, EventArgs e)
        {
            _device.Click();           

            SetImageUrl();
        }
        private void imBtAuto_Click(object sender, EventArgs e)
        {
            _device.Click("cl-Auto");

            SetImageUrl();
        }
        private void _imBtHot_Click(object sender, EventArgs e)
        {
            _device.Click("cl-heat");

            SetImageUrl();
        }
        private void _imBtCond_Click(object sender, EventArgs e)
        {
            _device.Click("cl-cond");

            SetImageUrl();
        }

        private void SetImageUrl()
        {
            ClimatControl climat = _data.Device as ClimatControl;
            if (_data.Device.State == StateOnOff.Off)
            {
                _imBt.ImageUrl = "~/Images/control_power.png";
            }
            else
            {
                _imBt.ImageUrl = "~/Images/control_power_blue.png";
            }



            if (climat != null && climat.Auto)
            {
                _imBtAuto.ImageUrl = "~/Images/AutoOn.png";
            }
            else
            {
                _imBtAuto.ImageUrl = "~/Images/AutoOff.png";
            }



            if (climat != null && climat.Heat.State == StateOnOff.Off)
            {
                _imBtHot.CssClass = "imgBt";
            }
            else
            {
                _imBtHot.CssClass = "imgBt imgColor";
            }



            if (climat != null && climat.Cond.State == StateOnOff.Off)
            {
                
                _imBtCond.CssClass = "imgBt";
            }
            else
            {

                _imBtCond.CssClass = "imgBt imgColor";
            }
        }
    }
}
