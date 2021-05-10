﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.Model.Vehicle
{
    

    public class VehiclePart : BasicModel
    {
        public long VehiclePartId { get; set; }

        private Vehicle vehicle;
        private VehicleModification vehicleModification;
        private VehicleEngine vehicleEngine;


        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                SetProperty(ref vehicle, value);
            }
        }
        public VehicleModification VehicleModification
        {
            get
            {
                return vehicleModification;
            }
            set
            {
                SetProperty(ref vehicleModification, value);
            }
        }
        public VehicleEngine VehicleEngine
        {
            get
            {
                return vehicleEngine;
            }
            set
            {
                SetProperty(ref vehicleEngine, value);
            }
        }




        private List<ConcretVehiclePartOemNumber> concretVehiclePartOemNumbers;

      
        public List<ConcretVehiclePartOemNumber> ConcretVehiclePartOemNumbers
        {
            get
            {
                return concretVehiclePartOemNumbers;
            }
            set
            {
                SetProperty(ref concretVehiclePartOemNumbers, value);
            }
        }

        private Category category;
        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                SetProperty(ref category, value);
            }
        }

    }

}
