using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.Model.Vehicle
{
    public class VehicleEngine : BasicModel
    {

        private long id;
        private float volume;
        // бенз не бенз
        private string modification;
        private short power;
        private string modelCode;
        private string releaseStart;
        private string releaseEnd;

        public override string ToString()
        {
            return $"{volume} ({power} л.с.) ({releaseStart} - {releaseEnd}) ({modelCode})";
        }

        public VehicleModification VehicleModification { get; set; }

        #region Properties
        
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

        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                SetProperty(ref volume, value);
            }
        }


        public string Modification
        {
            get
            {
                return modification;
            }
            set
            {
                SetProperty(ref modification, value);
            }
        }


        public short Power
        {
            get
            {
                return power;
            }
            set
            {
                SetProperty(ref power, value);
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

        public string ReleaseStart
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

        public string ReleaseEnd
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
        #endregion
    }
}
