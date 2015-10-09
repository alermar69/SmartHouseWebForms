using System;

namespace SmartHouseDll
{
    [Serializable]
    public abstract class Device : Authentication, IOnOff, IDevice
    {
        protected Device(string name)
            : base(name)
        {
            
        }

        #region ����� IOnOff

        public StateOnOff State { get; set; }

        public virtual void On()
        {
            State = StateOnOff.On;
        }

        public virtual void Off()
        {
            State = StateOnOff.Off;
        }
        #endregion        
      
        public override string ToString()
        {
            string state;
            if (State == StateOnOff.On)
            {
                state = "�������";
            }
            else
            {
                state = "��������";
            }
            return String.Format("��������� - {0}", state);
        }
    }
}