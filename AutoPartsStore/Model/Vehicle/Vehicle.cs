using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.Model.Vehicle
{

    public class Vehicle : BasicModel
    {
        private long id;
        private string brand;
        private ObservableCollection<VehicleModification> vehicleModifications;
        

        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                SetProperty(ref id, value);
            }
        }
        
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                SetProperty(ref brand, value);
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
    }
}
