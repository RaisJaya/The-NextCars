using System;
using System.Collections.Generic;
using System.Text;
using The_NextCars.Model;

namespace The_NextCars.Controler
{
    class DoorControler
    {
        private Door door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorControler(OnDoorChanged callbackOnDoorChanged)
        {
            this.door = new Door();
            this.callbackOnDoorChanged = callbackOnDoorChanged;
          
        }
        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");

        }
        public void open ()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "door opened");

        }
        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("LOCKED", "door unlock");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("UNLOCKED", "door unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void onLockDoorStateChanged(String value, string massage);
        void onDoorOpenStateChanged(String value, string massage);
    }
}
