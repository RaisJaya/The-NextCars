using System;
using System.Collections.Generic;
using System.Text;

namespace The_NextCars.Controler
{
    class Car
    {
        private DoorControler doorControler;
        private AccuControler accuControler;
        private OnCarEngineStateChanged callback;

        public Car(DoorControler doorControler, AccuControler accuControler, OnCarEngineStateChanged callback)
        {
            this.doorControler = doorControler;
            this.accuControler = accuControler;
            this.callback = callback;
        }
        private bool doorIsClosed()
        {
            return this.doorControler.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorControler.isLocked();
        }
        private bool powerIsReady()
        {
            return this.accuControler.accuIsOn();
        }
        public void startEngine()
        {
            if(!doorIsClosed())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "Close the door");
                return;
            }
            if(!doorIsLocked())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }
            if(!powerIsReady())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "no power available");
            }
            this.callback.OnCarEngineStateChanged("STARTED", "Engine Started");
        }
        public void toggleTheLockDoorButton()
        {
            
           if(!doorIsLocked())
            {
                this.doorControler.activateLock();
            }
           else
            {
                this.doorControler.unlock();
            }
        }
        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorControler.close();
            }
            else
            {
                this.doorControler.open();
            }
        }
        public void togglePowerButton()
        {
            if(!powerIsReady())
            {
                this.accuControler.turnON();
            }
            else
            {
                this.accuControler.turnOff();
            }
        }
    }
    interface OnCarEngineStateChanged
    {
        void OnCarEngineStateChanged(string value, string massage);
    }
}
