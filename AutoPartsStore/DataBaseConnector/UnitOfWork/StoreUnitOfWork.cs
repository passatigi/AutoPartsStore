using AutoPartsStore.DataBaseConnector.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.DataBaseConnector
{
    public class StoreUnitOfWork : IDisposable
    {
        #region singleton
        
        private static StoreUnitOfWork storeUnitOfWork;
        private static object syncRoot = new Object(); public static StoreUnitOfWork GetStoreUnitOfWork()
        {
            if (storeUnitOfWork == null)
            {
                lock (syncRoot)
                {
                    if (storeUnitOfWork == null)
                        storeUnitOfWork = new StoreUnitOfWork();
                }
            }
            return storeUnitOfWork;
        }
        #endregion

        private AutoPartsStoreContext db;
        protected StoreUnitOfWork()
        {
            db = new AutoPartsStoreContext();
        }

        private VehicleRepository vehicleRepository;
        private VehicleModificationRepository vehicleModificationRepository;
        private VehicleEngineRepository vehicleEngineRepository;
        private CategoryRepository categoryRepository;

        #region Properties

        public VehicleRepository VehicleRepository
        {
            get
            {
                if (vehicleRepository == null)
                    vehicleRepository = new VehicleRepository(db);
                return vehicleRepository;
            }
        }
        public VehicleModificationRepository VehicleModificationRepository
        {
            get
            {
                if (vehicleModificationRepository == null)
                    vehicleModificationRepository = new VehicleModificationRepository(db);
                return vehicleModificationRepository;
            }
        }
        public VehicleEngineRepository VehicleEngineRepository
        {
            get
            {
                if (vehicleEngineRepository == null)
                    vehicleEngineRepository = new VehicleEngineRepository(db);
                return vehicleEngineRepository;
            }
        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }
        #endregion

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
