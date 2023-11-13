using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragonsCutre.Data
{
    public interface IData<T>
    {
        public List<T> GetAll();
        public bool Insert(T data);
        public bool Update(T data);
        public bool Delete(T data);
    }
}
