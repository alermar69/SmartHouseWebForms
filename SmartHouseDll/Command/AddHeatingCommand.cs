namespace SmartHouseDll
{
    public class AddHeatingCommand : ICommand
    {
        public AddHeatingCommand()
        {
            Name = "addHeat";
            Inform = "�������� ���������� ���������";
        }

        public string Name { get; private set; }
        public string Inform { get; private set; }

        public void Execute(IDataCommand dataCommand)
        {
            Room room = dataCommand.GetRoom();
            if (room != null)
            {
                room.AddDevice(new Heating(dataCommand.DeviceData));
            }

        }
        public void Undo(IDataCommand dataCommand)
        {
            dataCommand.Home.DeleteDevice(dataCommand.RoomData, dataCommand.DeviceData);
        }
    }
}