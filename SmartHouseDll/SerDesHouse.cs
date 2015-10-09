using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmartHouseDll
{
    [Serializable]
    public class SerDesHouse
    {
        private static string pathFile = @"D:\11.dat";

        static public void Save(House house)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream(pathFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, house);
                }
            }
            catch (Exception e)
            {

            }
        }
        static public House Read()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = File.OpenRead(pathFile))
            {
                return binFormat.Deserialize(fStream) as House;
            }
        }

        private static House Initialization()
        {
            House house = new House("���1");
            house.AddRoom(new Room("���"));
            house.AddRoom(new Room("�����"));

            house.AddDevice("���", new ClimatControl("������"));

            HouseCinema cinema = new HouseCinema("���������");

            Tv tv = new Tv("TV1");
            tv.Connection(cinema);

            DVDPlayer dvd = new DVDPlayer("DVD");
            dvd.Connection(cinema);


            house.AddDevice("���", cinema);
            house.AddDevice("���", new DVDPlayer("DVD"));
            house.AddDevice("���", new Tv("TV1"));
            house.AddDevice("���", new Tv("TV2"));
            house.AddDevice("���", new Lamp("�����1"));
            house.AddDevice("���", new Lamp("�����2"));

            house.AddDevice("�����", new Tv("TV"));
            house.AddDevice("�����", new Heating("Heating"));
            house.AddDevice("�����", new Conditioner("Condition"));
            house.AddDevice("�����", new Lamp("�����1"));
            house.AddDevice("�����", new Lamp("�����2"));

            return house;

        }
    }
}