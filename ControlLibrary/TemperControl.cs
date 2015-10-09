using System;
using System.Web.UI.WebControls;
using SmartHouseDll;

namespace ControlLibrary
{
    class TemperControl : CompositeControl
    {
        private Panel _panel;
        private Label _temperLabel;

        private ImageButton _imBtAdd;
        private ImageButton _imBtDel;
        private Image _image;

        private DataForControl _data;
        private DeviceControl _device;

        public TemperControl(DataForControl data)
        {
            _data = data;
            _device = new DeviceControl(_data);
        }

        protected override void CreateChildControls()
        {
            if (DesignMode) // Если дизайнер Visual Studio
            {
                Label label = new Label();
                label.Text = "[TemperContol]";
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
            _panel.CssClass = "panTemper";

            _image = new Image();
            _image.ImageUrl = "~/Images/Temper1.png";
            _image.CssClass = "imgBt";
            _panel.Controls.Add(_image);


            _imBtAdd = new ImageButton();
            _imBtAdd.ImageUrl = "~/Images/up_plus.png";
            _imBtAdd.CssClass = "imgBtV";
            _imBtAdd.Click += _imBtAdd_Click;
            _panel.Controls.Add(_imBtAdd);

            _temperLabel = new Label();
            _temperLabel.Text = ((ITemperature)_data.Device).Temperature.ToString();
            _temperLabel.CssClass = "labelTemperat";
            _panel.Controls.Add(_temperLabel);

            _imBtDel = new ImageButton();
            _imBtDel.ImageUrl = "~/Images/down_minus.png";
            _imBtDel.CssClass = "imgBt imgBtV";
            _imBtDel.Click += _imBtDel_Click;
            _panel.Controls.Add(_imBtDel);

            Controls.Add(_panel);
        }

        private void _imBtAdd_Click(object sender, EventArgs e)
        {
            _device.Click("t+");

            _temperLabel.Text = ((ITemperature)_data.Device).Temperature.ToString();
        }
        private void _imBtDel_Click(object sender, EventArgs e)
        {
            _device.Click("t-");

            _temperLabel.Text = ((ITemperature)_data.Device).Temperature.ToString();
        } 
    }
}
