using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using The_NextCars.Controler;

namespace The_NextCars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , OnPowerChanged , OnDoorChanged, OnCarEngineStateChanged
    {
        private Car nextCar;

        public MainWindow()
        {
            InitializeComponent();
            AccuControler accuControler = new AccuControler(this);
            DoorControler doorControler = new DoorControler(this);

            nextCar = new Car(doorControler, accuControler, this);
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.startEngine();
        }

        private void OnDoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheOpenDoorButton();
        }

        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheLockDoorButton();
        }

        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.togglePowerButton();
        }

        public void OnPowerChangedStatus(string value, string massage)
        {
            Accustate.Content = massage;
            AccuButton.Content = value;
        }

        public void onLockDoorStateChanged(string value, string massage)
        {
            LockDoorState.Content = massage;
            LockDoorButton.Content = value;
        }

        public void onDoorOpenStateChanged(string value, string massage)
        {
            DoorOpenState.Content = massage;
            DoorOpenButton.Content = value;
        }

        public void OnCarEngineStateChanged(string value, string massage)
        {
            status.Content = massage;
            startButton.Content = value;
        }
    }
}
