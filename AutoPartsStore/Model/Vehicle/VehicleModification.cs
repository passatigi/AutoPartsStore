using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.Model.Vehicle
{
    public class VehicleModification : BasicModel
    {
        private long id;
        private string model;
        private string modelCode;
        private short releaseStart;
        private short releaseEnd;
        private ObservableCollection<VehicleEngine> vehicleEngines;

        public Vehicle Vehicle { get; set; }

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

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                SetProperty(ref model, value);
            }
        }

        public string ModelCode
        {
            get
            {
                return modelCode;
            }
            set
            {
                SetProperty(ref modelCode, value);
            }
        }

        public short ReleaseStart
        {
            get
            {
                return releaseStart;
            }
            set
            {
                SetProperty(ref releaseStart, value);
            }
        }

        public short ReleaseEnd
        {
            get
            {
                return releaseEnd;
            }
            set
            {
                SetProperty(ref releaseEnd, value);
            }
        }

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


    }
}
