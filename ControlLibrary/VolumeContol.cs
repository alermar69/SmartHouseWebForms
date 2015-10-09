using System;
using System.Web.UI.WebControls;
using SmartHouseDll;

namespace ControlLibrary
{
    public class VolumeContol : CompositeControl
    {
        private Panel _panel;
        private Label _volumeLabel;
        private ImageButton _imBtAdd;
        private ImageButton _imBtDel;
        private Image _image;

        private DataForControl _data;
        private DeviceControl _device;

        public VolumeContol(DataForControl data)
        {
            _data = data;
            _device = new DeviceControl(_data);
        }

        protected override void CreateChildControls()
        {
            if (DesignMode) // Если дизайнер Visual Studio
            {
                Label label = new Label();
                label.Text = "[VolumeContol]";
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
            _panel.CssClass = "panVolume";

            _image = new Image();
            _image.ImageUrl = "~/Images/sound_low.png";
            _image.CssClass = "imgBt";
            _panel.Controls.Add(_image);


            _imBtAdd = new ImageButton();
            _imBtAdd.ImageUrl = "~/Images/up_plus.png";
            _imBtAdd.CssClass = "imgBtV";
            _imBtAdd.Click += _imBtAdd_Click;
            _panel.Controls.Add(_imBtAdd);

            _volumeLabel = new Label();
            _volumeLabel.Text = ((IVolume)_data.Device).Volume.ToString();
            _volumeLabel.CssClass = "labelVolume";
            _panel.Controls.Add(_volumeLabel);

            _imBtDel = new ImageButton();
            _imBtDel.ImageUrl = "~/Images/down_minus.png";
            _imBtDel.CssClass = "imgBt imgBtV";
            _imBtDel.Click += _imBtDel_Click;
            _panel.Controls.Add(_imBtDel);

            Controls.Add(_panel);
        }

        private void _imBtAdd_Click(object sender, EventArgs e)
        {
            _device.Click("vol+");

            _volumeLabel.Text = ((IVolume)_data.Device).Volume.ToString();
        }
        private void _imBtDel_Click(object sender, EventArgs e)
        {
            _device.Click("vol-");

            _volumeLabel.Text = ((IVolume) _data.Device).Volume.ToString();
        } 
    }
}
