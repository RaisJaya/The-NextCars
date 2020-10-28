using System;
using System.Collections.Generic;
using System.Text;
using The_NextCars.Model;

namespace The_NextCars.Controler
{
    class AccuControler
    {
        private Accu accu;
        private OnPowerChanged callbackOnPowerChanged;

        public AccuControler(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accu = new Accu(12);
        }

        public void turnON()
        {
            this.accu.turnOn();
            this.callbackOnPowerChanged.OnPowerChangedStatus("ON", "power is on");
        }
        public void turnOff()
        {
            this.accu.turnOff();
            this.callbackOnPowerChanged.OnPowerChangedStatus("OFF", "power is off");
        }
        public bool accuIsOn()
        {
            return this.accu.isOn();
        }
    }

    interface OnPowerChanged
    {
        void OnPowerChangedStatus(string value, string massage);
    }
}
