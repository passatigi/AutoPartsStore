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
    class AutoPartsStoreContext : DbContext
    {
        private static AutoPartsStoreContext autoPartsStoreContext;
        private static object syncRoot = new Object();
        protected AutoPartsStoreContext() : base("DefaultConnection")
        {

        }
        public static AutoPartsStoreContext GetStoreContext()
        {
            if (autoPartsStoreContext == null)
            {
                lock (syncRoot)
                {
                    if (autoPartsStoreContext == null)
                        autoPartsStoreContext = new AutoPartsStoreContext();
                }
            }
            return autoPartsStoreContext;
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
