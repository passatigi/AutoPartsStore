using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoPartsStore.Model;
using AutoPartsStore.Model.Vehicle;

namespace AutoPartsStore.DataBaseConnector
{
    public class AutoPartsStoreContext : DbContext
    {
        
        public AutoPartsStoreContext() : base("DefaultConnection")
        {

        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<VendorCode> VendorCodes { get; set; }
        public DbSet<VendorCodeOEMNumbers> NumbersOEM { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleModification> VehicleModifications { get; set; }
        public DbSet<VehicleEngine> VehicleEngines { get; set; }
        public DbSet<VehiclePart> VehicleParts { get; set; }
        public DbSet<ConcretVehiclePartOemNumber> OEMNumbers { get; set; }

    }
}
