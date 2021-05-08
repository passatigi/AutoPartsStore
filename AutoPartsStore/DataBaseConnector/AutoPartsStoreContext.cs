using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoPartsStore.Model;

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
        public DbSet<OEMNumber> NumbersOEM { get; set; }

    }
}
