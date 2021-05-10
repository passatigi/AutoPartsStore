using AutoPartsStore.DataBaseConnector;
using AutoPartsStore.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.BusinessLayer
{
    class VehicleAccess
    {
        AutoPartsStoreContext db;

        List<Vehicle> categories;

        public VehicleAccess()
        {
            db = AutoPartsStoreContext.GetStoreContext();
        }

        public IEnumerable<Vehicle> GetAllVehicleBrands()
        {
            return db.Vehicles.AsEnumerable();
        }
        public IEnumerable<VehicleModification> GetAllVehicleBrandMofications(Vehicle vehicle)
        {
            return db.VehicleModifications.Where(wm => wm.Vehicle.Brand == vehicle.Brand).AsEnumerable();
        }
        public void AddVehicleBrand(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
            db.SaveChanges();
        }
        public void AddVehicleModification(VehicleModification vehicleModification)
        {
            db.VehicleModifications.Add(vehicleModification);
            db.SaveChanges();
        }

        public void DeleteVehicleModification(VehicleModification vehicleModification)
        {
            // mojet bit oshibka
            db.VehicleModifications.Remove(vehicleModification);
            db.SaveChanges();
        }
    }
}
