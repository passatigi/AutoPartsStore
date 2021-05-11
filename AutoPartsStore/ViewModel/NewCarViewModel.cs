using AutoPartsStore.BusinessLayer;
using AutoPartsStore.Command;
using AutoPartsStore.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoPartsStore.ViewModel
{
    class NewCarViewModel : BaseViewModel
    {

        private Vehicle selectedVehicleBrand;

        private VehicleModification selectedVehicleModification;
        private VehicleEngine selectedVehicleEngine;

        #region CurrentVehicleProperties
        public VehicleEngine SelectedVehicleEngine
        {
            get
            {
                return selectedVehicleEngine;
            }
            set
            {
                SetProperty(ref selectedVehicleEngine, value);
                
                if (SelectedVehicleEngine != null)
                {
                    SelectedVehicleEngine.Volume = SelectedVehicleEngine.Volume;
                    SelectedVehicleEngine.Modification = SelectedVehicleEngine.Modification;
                    SelectedVehicleEngine.Power = SelectedVehicleEngine.Power;
                    SelectedVehicleEngine.ModelCode = SelectedVehicleEngine.ModelCode;
                    SelectedVehicleEngine.ReleaseStart = SelectedVehicleEngine.ReleaseStart;
                    SelectedVehicleEngine.ReleaseEnd = SelectedVehicleEngine.ReleaseEnd;
                }
            }
        }

        public Vehicle SelectedVehicleBrand
        {
            get
            {
                return selectedVehicleBrand;
            }
            set
            {
                SetProperty(ref selectedVehicleBrand, value);
                FillVehicleModifications();
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
                if(SelectedVehicleModification != null)
                {
                    SelectedVehicleModification.Model = SelectedVehicleModification.Model;
                    SelectedVehicleModification.ModelCode = SelectedVehicleModification.ModelCode;
                    SelectedVehicleModification.ReleaseStart = SelectedVehicleModification.ReleaseStart;
                    SelectedVehicleModification.ReleaseEnd = SelectedVehicleModification.ReleaseEnd;
                }
                FillVehicleEngine();

            }
        }
        #endregion



        #region commands
        

        private RelayCommand addPropertyCommand;
        public RelayCommand AddPropertyCommand
        {
            get
            {
                return addPropertyCommand ?? (addPropertyCommand = new RelayCommand(action =>
                {
                    ObservableCollection<string> propertiesCollection = (ObservableCollection<string>)action;
                    if(selectedVehicleModification == null)
                    {
                        selectedVehicleModification = new VehicleModification();
                    }
                    if(propertiesCollection == vehicleModificationModels)
                    {
                        propertiesCollection.Add(addTextModificationModel);
                        selectedVehicleModification.Model = addTextModificationModel;
                    }
                    else if (propertiesCollection == vehicleModificationModelCodes)
                    {
                        propertiesCollection.Add(addTextModificationModelCode);
                        selectedVehicleModification.ModelCode = addTextModificationModelCode;
                    }
                    else if (propertiesCollection == vehicleModificationReleaseStarts)
                    {
                            propertiesCollection.Add(addTextModificationReleaseStart);
                            selectedVehicleModification.ReleaseStart = addTextModificationReleaseStart;
                    }
                    else if (propertiesCollection == vehicleModificationReleaseEnds)
                    {
                        propertiesCollection.Add(addTextModificationReleaseEnd);
                        selectedVehicleModification.ReleaseEnd = addTextModificationReleaseEnd;
                    }
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand addVehicleBrandCommnand;
        public RelayCommand AddVehicleBrandCommnand
        {
            get
            {
                return addVehicleBrandCommnand ?? (addVehicleBrandCommnand = new RelayCommand(action =>
                {
                    Vehicle newVehicle = new Vehicle(AddTextVehicleBrand);
                    vehicleAccess.AddVehicleBrand(newVehicle);
                    vehicleBrands.Add(newVehicle);
                    SelectedVehicleBrand = newVehicle;
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand addVehicleModificationCommnand;
        public RelayCommand AddVehicleModificationCommnand
        {
            get
            {
                return addVehicleModificationCommnand ?? (addVehicleModificationCommnand = new RelayCommand(action =>
                {
                    //CheckVehicleModificationFilling();

                    if (SelectedVehicleModification.Model == null)
                    {

                        SelectedVehicleModification.Model = addTextModificationModel;
                    }
                    if (SelectedVehicleModification.ModelCode == null)
                    {

                        SelectedVehicleModification.ModelCode = addTextModificationModelCode;
                    }
                    if (SelectedVehicleModification.ReleaseStart == null)
                    {

                        SelectedVehicleModification.ReleaseStart = addTextModificationReleaseStart;
                    }
                    if (SelectedVehicleModification.ReleaseEnd == null)
                    {

                        SelectedVehicleModification.ReleaseEnd = addTextModificationReleaseEnd;
                    }
                    if (SelectedVehicleModification.Model == null || SelectedVehicleModification.Model == "" ||
                    SelectedVehicleModification.ModelCode == null || SelectedVehicleModification.ModelCode == "" ||
                    SelectedVehicleModification.ReleaseStart == null || SelectedVehicleModification.ReleaseStart == "" ||
                    SelectedVehicleModification.ReleaseEnd == null || SelectedVehicleModification.ReleaseEnd == "")
                    {
                        MessageBox.Show("Заполните модификацию");
                    }
                    else
                    {
                        VehicleModification newVehicleModification = new VehicleModification(
                            SelectedVehicleBrand, SelectedVehicleModification
                            );
                        vehicleAccess.AddVehicleModification(newVehicleModification);
                        VehicleModifications.Add(newVehicleModification);
                        SelectedVehicleModification = newVehicleModification;
                    }
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand deleteModificationCommnand;
        public RelayCommand DeleteModificationCommnand
        {
            get
            {
                return deleteModificationCommnand ?? (deleteModificationCommnand = new RelayCommand(action =>
                {
                        vehicleAccess.DeleteVehicleModification(selectedVehicleModification);
                    vehicleModifications.Remove(selectedVehicleModification);

                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand addEnginePropertyCommand;
        public RelayCommand AddEnginePropertyCommand
        {
            get
            {
                return addEnginePropertyCommand ?? (addEnginePropertyCommand = new RelayCommand(action =>
                {
                    if(selectedVehicleEngine == null)
                    {
                        selectedVehicleEngine = new VehicleEngine();
                    }
                    if (action is ObservableCollection<string>)
                    {
                        ObservableCollection<string> engineProp = (ObservableCollection<string>)action;
                        if(engineProp == vehicleEngineModifications)
                        {
                            engineProp.Add(addTextEngineModification);
                            selectedVehicleEngine.Modification = addTextEngineModification;
                        }
                        else if (engineProp == vehicleEngineModelCodes)
                        {
                            engineProp.Add(addTextEngineModelCode);
                            selectedVehicleEngine.ModelCode = addTextEngineModelCode;
                        }
                        else if (engineProp == vehicleEngineReleaseStarts)
                        {
                            engineProp.Add(addTextEngineReleaseStart);
                            selectedVehicleEngine.ReleaseStart = addTextEngineReleaseStart;
                        }
                        else if (engineProp == vehicleEngineReleaseEnds)
                        {
                            engineProp.Add(addTextEngineReleaseEnd);
                            selectedVehicleEngine.ReleaseEnd = addTextEngineReleaseEnd;
                        }
                    }
                    else if(action is ObservableCollection<float>)
                    {
                        ObservableCollection<float> engineProp = (ObservableCollection<float>)action;
                        if (engineProp == vehicleEngineVolumes)
                        {
                            engineProp.Add(addTextEngineVolume);
                            selectedVehicleEngine.Volume = addTextEngineVolume;
                        }
                    }
                    else if(action is ObservableCollection<short>)
                    {
                        ObservableCollection<short> engineProp = (ObservableCollection<short>)action;
                        if (engineProp == vehicleEnginePowers)
                        {
                            engineProp.Add(addTextEnginePower);
                            selectedVehicleEngine.Power = addTextEnginePower;
                        }
                    }
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand deleteEngineCommnand;
        public RelayCommand DeleteEngineCommnand
        {
            get
            {
                return deleteEngineCommnand ?? (deleteEngineCommnand = new RelayCommand(action =>
                {
                    vehicleAccess.DeleteVehicleModification(selectedVehicleModification);
                    vehicleModifications.Remove(selectedVehicleModification);

                }, func =>
                {
                    return true;
                }));
            }
        }

        
        private RelayCommand addVehicleEngineCommnand;
        public RelayCommand AddVehicleEngineCommnand
        {
            get
            {
                return addVehicleEngineCommnand ?? (addVehicleEngineCommnand = new RelayCommand(action =>
                {

                    //if (SelectedVehicleModification.Model == null)
                    //{
                    //    SelectedVehicleModification.Model = addTextModificationModel;
                    //}
                    //if (SelectedVehicleModification.ModelCode == null)
                    //{

                    //    SelectedVehicleModification.ModelCode = addTextModificationModelCode;
                    //}
                    //if (SelectedVehicleModification.ReleaseStart == null)
                    //{

                    //    SelectedVehicleModification.ReleaseStart = addTextModificationReleaseStart;
                    //}
                    //if (SelectedVehicleModification.ReleaseEnd == null)
                    //{

                    //    SelectedVehicleModification.ReleaseEnd = addTextModificationReleaseEnd;
                    //}

                    if (SelectedVehicleEngine.Volume == 0 || SelectedVehicleEngine.Power == 0 ||
                    SelectedVehicleEngine.Modification == null || SelectedVehicleEngine.Modification == "" ||
                    SelectedVehicleEngine.ModelCode == null || SelectedVehicleEngine.ModelCode == "" ||
                    SelectedVehicleEngine.ReleaseStart == null || SelectedVehicleEngine.ReleaseStart == "" ||
                    SelectedVehicleEngine.ReleaseEnd == null || SelectedVehicleEngine.ReleaseEnd == "")
                    {
                        MessageBox.Show("Заполните двигатель");
                    }
                    else
                    {
                        VehicleEngine newVehicleEngine = new VehicleEngine(
                            SelectedVehicleModification, selectedVehicleEngine
                            );
                        vehicleAccess.AddVehicleEngine(newVehicleEngine);
                        VehicleEngines.Add(newVehicleEngine);
                        selectedVehicleEngine = newVehicleEngine;
                    }
                }, func =>
                {
                    return true;
                }));
            }
        }

        #endregion

        VehicleAccess vehicleAccess;
        MainViewModel mainViewModel;
        public NewCarViewModel()
        {
            vehicleAccess = new VehicleAccess();


            mainViewModel = MainViewModel.GetMainViewModel();
            mainViewModel.NewCarViewModel = this;


            selectedVehicleBrand = new Vehicle();
            selectedVehicleModification = new VehicleModification();
            selectedVehicleEngine = new VehicleEngine();

            vehicleBrands = new ObservableCollection<Vehicle>();
            vehicleModifications = new ObservableCollection<VehicleModification>();
            vehicleEngines = new ObservableCollection<VehicleEngine>();

            vehicleModificationModels = new ObservableCollection<string>();
            vehicleModificationModelCodes = new ObservableCollection<string>();
            vehicleModificationReleaseStarts = new ObservableCollection<string>();
            vehicleModificationReleaseEnds = new ObservableCollection<string>();


            vehicleEngineVolumes = new ObservableCollection<float>();
            vehicleEngineModifications = new ObservableCollection<string>();
            vehicleEnginePowers = new ObservableCollection<short>();
            vehicleEngineModelCodes = new ObservableCollection<string>();
            vehicleEngineReleaseStarts = new ObservableCollection<string>();
            vehicleEngineReleaseEnds = new ObservableCollection<string>();


        //VehicleModification vm1 = new VehicleModification("Sierra", "GBC", "1987", "1990");
        //VehicleModification vm2 = new VehicleModification("Sierra", "GBN", "1990", "1993");
        //vehicleModifications.Add(vm1);
        //vehicleModifications.Add(vm2);

            //VehicleModificationModels.Add(vm1.Model);
            //VehicleModificationModels.Add(vm2.Model);

            FillVehicleBrands();
        }

        private void FillVehicleBrands()
        {
            vehicleBrands.Clear();
            foreach (Vehicle vehicleBrand in vehicleAccess.GetAllVehicleBrands())
            {
                vehicleBrands.Add(vehicleBrand);
            }
        }

        private void FillVehicleModifications()
        {
            
            vehicleModifications.Clear();
            vehicleModificationModels.Clear();
            vehicleModificationModelCodes.Clear();
            vehicleModificationReleaseStarts.Clear();
            vehicleModificationReleaseEnds.Clear(); 
            foreach (VehicleModification vehicleModification in vehicleAccess.GetAllVehicleBrandMofications(selectedVehicleBrand))
            {
                vehicleModifications.Add(vehicleModification);
                vehicleModificationModels.Add(vehicleModification.Model);
                vehicleModificationModelCodes.Add(vehicleModification.ModelCode);
                vehicleModificationReleaseStarts.Add(vehicleModification.ReleaseStart);
                vehicleModificationReleaseEnds.Add(vehicleModification.ReleaseEnd);
            }
            if(vehicleModifications.Count == 0)
            {
                selectedVehicleModification = new VehicleModification();
            }
        }

        private void FillVehicleEngine()
        {
            vehicleEngines.Clear();
            vehicleEngineVolumes.Clear();
            vehicleEngineModifications.Clear();
            vehicleEnginePowers.Clear();
            vehicleEngineModelCodes.Clear();
            vehicleEngineReleaseStarts.Clear();
            vehicleEngineReleaseEnds.Clear();
            if (selectedVehicleModification != null) {
            foreach (VehicleEngine vehicleEngine in vehicleAccess.GetAllVehicleModificationEngines(selectedVehicleModification))
            {
                vehicleEngines.Add(vehicleEngine);
                vehicleEngineVolumes.Add(vehicleEngine.Power);
                vehicleEngineModifications.Add(vehicleEngine.Modification);
                vehicleEnginePowers.Add(vehicleEngine.Power);
                vehicleEngineModelCodes.Add(vehicleEngine.ModelCode);
                vehicleEngineReleaseStarts.Add(vehicleEngine.ReleaseStart);
                vehicleEngineReleaseEnds.Add(vehicleEngine.ReleaseEnd);
            }
            }
            if (vehicleEngines.Count == 0)
            {
                selectedVehicleEngine = new VehicleEngine();
            }
        }




        private string addTextVehicleBrand;

        private string addTextModificationModel;
        private string addTextModificationModelCode;
        private string addTextModificationReleaseStart;
        private string addTextModificationReleaseEnd;

        //private float volume;
        //private string modification;
        //private short power;
        //private string modelCode;
        //private string releaseStart;
        //private string releaseEnd;
        private float addTextEngineVolume;
        private string addTextEngineModification;
        private short addTextEnginePower;
        private string addTextEngineModelCode;
        private string addTextEngineReleaseStart;
        private string addTextEngineReleaseEnd;

        public float AddTextEngineVolume { get => addTextEngineVolume; set => addTextEngineVolume = value; }
        public string AddTextEngineModification { get => addTextEngineModification; set => addTextEngineModification = value; }
        public short AddTextEnginePower { get => addTextEnginePower; set => addTextEnginePower = value; }
        public string AddTextEngineModelCode { get => addTextEngineModelCode; set => addTextEngineModelCode = value; }
        public string AddTextEngineReleaseStart { get => addTextEngineReleaseStart; set => addTextEngineReleaseStart = value; }
        public string AddTextEngineReleaseEnd { get => addTextEngineReleaseEnd; set => addTextEngineReleaseEnd = value; }

        #region addTextModificationProperties
        public string AddTextVehicleBrand
        {
            get
            {
                return addTextVehicleBrand;
            }
            set
            {
                SetProperty(ref addTextVehicleBrand, value);
            }
        }

        public string AddTextModificationModel
        {
            get
            {
                return addTextModificationModel;
            }
            set
            {
                SetProperty(ref addTextModificationModel, value);
            }
        }

    
        public string AddTextModificationModelCode
        {
            get
            {
                return addTextModificationModelCode;
            }
            set
            {
                SetProperty(ref addTextModificationModelCode, value);
            }
        }

        public string AddTextModificationReleaseStart
        {
            get
            {
                return addTextModificationReleaseStart;
            }
            set
            {
                SetProperty(ref addTextModificationReleaseStart, value);
            }
        }

        
        public string AddTextModificationReleaseEnd
        {
            get
            {
                return addTextModificationReleaseEnd;
            }
            set
            {
                SetProperty(ref addTextModificationReleaseEnd, value);
            }
        }
        #endregion

        private ObservableCollection<VehicleEngine> vehicleEngines;

        private ObservableCollection<VehicleModification> vehicleModifications;

        private ObservableCollection<Vehicle> vehicleBrands;


        private ObservableCollection<string> vehicleModificationModels;

        private ObservableCollection<string> vehicleModificationModelCodes;

        private ObservableCollection<string> vehicleModificationReleaseStarts;

        private ObservableCollection<string> vehicleModificationReleaseEnds;



        private ObservableCollection<float> vehicleEngineVolumes;

        private ObservableCollection<string> vehicleEngineModifications;

        private ObservableCollection<short> vehicleEnginePowers;

        private ObservableCollection<string> vehicleEngineModelCodes;

        private ObservableCollection<string> vehicleEngineReleaseStarts;

        private ObservableCollection<string> vehicleEngineReleaseEnds;


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

        public ObservableCollection<string> VehicleModificationModels
        {
            get
            { 
                return vehicleModificationModels;
            }
            set
            {
                SetProperty(ref vehicleModificationModels, value);
            }
        }
        public ObservableCollection<string> VehicleModificationModelCodes
        {
            get
            {
                return vehicleModificationModelCodes;
            }
            set
            {
                SetProperty(ref vehicleModificationModelCodes, value);
            }
        }

        public ObservableCollection<string> VehicleModificationReleaseStarts
        {
            get
            {
                return vehicleModificationReleaseStarts;
            }
            set
            {
                SetProperty(ref vehicleModificationReleaseStarts, value);
            }
        }
        public ObservableCollection<string> VehicleModificationReleaseEnds
        {
            get
            {
                return vehicleModificationReleaseEnds;
            }
            set
            {
                SetProperty(ref vehicleModificationReleaseEnds, value);
            }
        }

        public ObservableCollection<float> VehicleEngineVolumes { get => vehicleEngineVolumes; set => vehicleEngineVolumes = value; }
        public ObservableCollection<string> VehicleEngineModifications { get => vehicleEngineModifications; set => vehicleEngineModifications = value; }
        public ObservableCollection<short> VehicleEnginePowers { get => vehicleEnginePowers; set => vehicleEnginePowers = value; }
        public ObservableCollection<string> VehicleEngineModelCodes { get => vehicleEngineModelCodes; set => vehicleEngineModelCodes = value; }
        public ObservableCollection<string> VehicleEngineReleaseStarts { get => vehicleEngineReleaseStarts; set => vehicleEngineReleaseStarts = value; }
        public ObservableCollection<string> VehicleEngineReleaseEnds { get => vehicleEngineReleaseEnds; set => vehicleEngineReleaseEnds = value; }


        #endregion



    }
}
