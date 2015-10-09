using System;

namespace SmartHouseDll
{
    [Serializable]
    public class Tv : Device, IVolume, ILight, IHouseCinema
    {
        private int _volume;


        public Tv(string name) : base(name)
        {
            _volume = 10;
            Brightness = LightsState.Medium;
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value >=0 && value < 50)
                {
                    _volume = value;
                }
                
            }
        }

        #region ����� IVolume

        public void IncrementVolume()
        {
            Volume++;
        }

        public void DecrementVolume()
        {
            Volume--;
        }

        #endregion

        #region ����� ILight

        public LightsState Brightness { get; set; }

        public void IncrementLight()
        {
            Brightness++;
        }

        public void DecrementLight()
        {
            Brightness--;
        }

        #endregion

        #region ����� IHouseCinema

        public void Connection(HouseCinema houseCinema)
        {
            if(houseCinema != null)
                houseCinema.AddDevice(this);
        }

        #endregion

        public override string ToString()
        {
            string mode;
            if (Brightness == LightsState.Low)
            {
                mode = "������";
            }
            else if (Brightness == LightsState.Medium)
            {
                mode = "�������";
            }
            else
            {
                mode = "�������";
            }
            return string.Format("{0}; ��������� - {1}; ������� - {2}", base.ToString(), Volume, mode);
        }
    }
}