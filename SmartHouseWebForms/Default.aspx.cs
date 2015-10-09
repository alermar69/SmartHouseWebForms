using System;
using System.Web.UI;
using SmartHouseDll;

namespace SmartHouseWebForms
{
    public partial class Default : Page
    {
        private House _house;

        protected void Page_Load(object sender, EventArgs e)
        {
            _house = Master.Home;
        }
    }
}