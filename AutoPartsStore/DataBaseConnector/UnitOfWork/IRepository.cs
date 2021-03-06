using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.DataBaseConnector
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithCondition(object condition);
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
