using SmartHouseDll;

namespace SmartHouseWebForms
{
    public class WebReader : Storage, IReader 
    {
        public WebReader(House home) : base(home)
        {
        }

        public void Read()
        {
        }

        public void Help(RemoteControl remote, string message)
        {
            
        }
    }
}