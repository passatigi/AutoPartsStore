using AutoPartsStore.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.DataBaseConnector.UnitOfWork
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        AutoPartsStoreContext db;
        public VehicleRepository(AutoPartsStoreContext db)
        {
            this.db = db;
        }
        public void Add(Vehicle item)
        {
            db.Vehicles.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return db.Vehicles.AsEnumerable();
        }

        public IEnumerable<Vehicle> GetAllWithCondition(object condition)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle item)
        {
            throw new NotImplementedException();
        }
    }
}
