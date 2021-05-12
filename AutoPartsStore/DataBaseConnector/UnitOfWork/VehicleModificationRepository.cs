using AutoPartsStore.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.DataBaseConnector.UnitOfWork
{
    public class VehicleModificationRepository : IRepository<VehicleModification>
    {
        AutoPartsStoreContext db;
        public VehicleModificationRepository(AutoPartsStoreContext db)
        {
            this.db = db;
        }
        public void Add(VehicleModification item)
        {
            db.VehicleModifications.Add(item);
        }

        public void Delete(int id)
        {
            db.VehicleModifications.Remove(GetById(id));
        }

        public IEnumerable<VehicleModification> GetAll()
        {
            return db.VehicleModifications.AsEnumerable();
        }

        public IEnumerable<VehicleModification> GetAllWithCondition(object condition)
        {
            if (condition is Vehicle)
            {
                Vehicle vehicle = condition as Vehicle;
                return db.VehicleModifications.Where(wm => wm.Vehicle.Brand.Equals(vehicle.Brand)).AsEnumerable();
            }
            else
                throw new Exception("Condition should be Vehicle");
            
        }

        public VehicleModification GetById(int id)
        {
            return db.VehicleModifications.Where(vm => vm.Id == id).FirstOrDefault();
        }

        public void Update(VehicleModification item)
        {
            throw new NotImplementedException();
        }
    }
}
