using AccessSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.EntityFramework
{
    interface IRepository<T> where T : BaseRefClass
    {
        IEnumerable<T> GetAllObject();
        T GetObject(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(T item);
        bool Save(T item);
    }
}
