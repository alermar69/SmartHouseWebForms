namespace SmartHouseDll
{
    public interface IReader : IDataCommand  // ��������� ��� ���������� ������
    {
        void Read(); // ����� ��� ���������� ������
        void Help(RemoteControl remote, string message);
    }
}