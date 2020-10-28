using System;
using System.Collections.Generic;
using System.Text;

namespace The_NextCars.Model
{
    class Accu
    {
        private int voltage;
        private bool stateOn = false;

        public Accu(int voltage)
        {
            this.voltage = voltage;
        }
        public void turnOn()
        {
            this.stateOn = true;
        }
        public void turnOff()
        {
            this.stateOn = false;
        }
        public bool isOn()
        {
            return this.stateOn;
        }
    }
}
