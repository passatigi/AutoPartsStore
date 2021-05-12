using AutoPartsStore.BusinessLayer;
using AutoPartsStore.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.ViewModel
{
    class ChooseCarViewModel : BaseViewModel
    {
        VehicleAccess vehicleAccess;
        MainViewModel mainViewModel;
        public ChooseCarViewModel()
        {
            vehicleAccess = new VehicleAccess();


            mainViewModel = MainViewModel.GetMainViewModel();
            mainViewModel.ChooseCarViewModel = this;


            selectedVehicleBrand = new Vehicle();
            selectedVehicleModification = new VehicleModification();
            selectedVehicleEngine = new VehicleEngine();

            vehicleBrands = new ObservableCollection<Vehicle>();
            vehicleModifications = new ObservableCollection<VehicleModification>();
            vehicleEngines = new ObservableCollection<VehicleEngine>();

            FillVehicleBrands();
        }

        void FillVehicleBrands()
        {
            vehicleBrands.Clear();
            foreach(Vehicle vehicle in vehicleAccess.GetAllVehicleBrands())
            {
                vehicleBrands.Add(vehicle);
            }
            NotifyPropertyChanged(nameof(VehicleBrands));
        }
        void FillVehicleModifications()
        {
            vehicleModifications.Clear();
            foreach (VehicleModification vehicle in vehicleAccess.GetAllVehicleBrandModifications(SelectedVehicleBrand))
            {
                vehicleModifications.Add(vehicle);
            }
            NotifyPropertyChanged(nameof(VehicleModifications));
        }

        void FillVehicleEngines()
        {
            vehicleEngines.Clear();
            foreach (VehicleEngine vehicle in vehicleAccess.GetAllVehicleModelEngines(SelectedVehicleModification))
            {
                vehicleEngines.Add(vehicle);
            }
            NotifyPropertyChanged(nameof(vehicleEngines));
        }

        private Vehicle selectedVehicleBrand;
        private VehicleModification selectedVehicleModification;
        private VehicleEngine selectedVehicleEngine;

        #region CurrentVehicleProperties
        public Vehicle SelectedVehicleBrand
        {
            get
            {
                return selectedVehicleBrand;
            }
            set
            {
                SetProperty(ref selectedVehicleBrand, value);
                if (value != null)
                {
                    FillVehicleModifications();
                }
            }
        }

        public VehicleModification SelectedVehicleModification
        {
            get
            {
                return selectedVehicleModification;
            }
            set
            {
                SetProperty(ref selectedVehicleModification, value);
                if(value != null)
                {
                    FillVehicleEngines();
                }
            }
        }
        public VehicleEngine SelectedVehicleEngine
        {
            get
            {
                return selectedVehicleEngine;
            }
            set
            {
                SetProperty(ref selectedVehicleEngine, value);
            }
        }

        

        
        #endregion

        private ObservableCollection<VehicleEngine> vehicleEngines;

        private ObservableCollection<VehicleModification> vehicleModifications;

        private ObservableCollection<Vehicle> vehicleBrands;

        #region ComboboxCollections 
        public ObservableCollection<VehicleEngine> VehicleEngines
        {
            get
            {
                return vehicleEngines;
            }
            set
            {
                SetProperty(ref vehicleEngines, value);
            }
        }
        public ObservableCollection<VehicleModification> VehicleModifications
        {
            get
            {
                return vehicleModifications;
            }
            set
            {
                SetProperty(ref vehicleModifications, value);
            }
        }

        public ObservableCollection<Vehicle> VehicleBrands
        {
            get
            {
                return vehicleBrands;
            }
            set
            {
                SetProperty(ref vehicleBrands, value);
            }
        }
        #endregion
    }
}
