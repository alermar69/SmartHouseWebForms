using System;
using System.Web.UI.WebControls;
using SmartHouseDll;

namespace ControlLibrary
{
    public class LightContol : CompositeControl
    {
        private Panel _panel;
        private DropDownList _radioButtonList;
        private Image _image;

        private DataForControl _data;
        private DeviceControl _device;

        public LightContol(DataForControl data)
        {
            _data = data;
            _device = new DeviceControl(_data);
        }

        protected override void CreateChildControls()
        {
            if (DesignMode) // Если дизайнер Visual Studio
            {
                Label label = new Label();
                label.Text = "[LightControl]";
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
            _panel.CssClass = "panLight";

            _image = new Image();
            _image.ImageUrl = "~/Images/litgh.png";
            _image.CssClass = "imgBt";
            _panel.Controls.Add(_image);

            _radioButtonList = new DropDownList();
            _radioButtonList.CssClass = "enumLight";
            string[] styleNames = Enum.GetNames(typeof(LightsState));
            _radioButtonList.DataSource = styleNames;
            _radioButtonList.SelectedIndexChanged += RadioButtonListOnSelectedIndexChanged;
            _radioButtonList.AutoPostBack = true;
            _radioButtonList.DataBind();
            _radioButtonList.Items[(Int32)(((ILight)_data.Device).Brightness)].Selected = true;
            _panel.Controls.Add(_radioButtonList);

            Controls.Add(_panel);
        }

        private void RadioButtonListOnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            _data.House.Remote.Reader.Value = ((DropDownList)sender).SelectedItem.Text;

            _device.Click("light");

            ((DropDownList)sender).Items[(Int32)(((ILight)_data.Device).Brightness)].Selected = true;
        }
    }
}
