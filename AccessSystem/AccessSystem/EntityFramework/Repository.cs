using AccessSystem.Models;
using AccessSystem.Models.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.EntityFramework
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllObject();
        T GetObject(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        void Save(T item);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private Context _context;
        Type _typeT = typeof(T);

        public Repository(Context context)
        {
            _context = context;
        }


        public void Create(T item)
        {
            if (_typeT == typeof(Base))
            {
                _context.Base.Add(item as Base);
            }
            else if (_typeT == typeof(Request))
            {
                _context.Request.Add(item as Request);
            }
            else if (_typeT == typeof(User))
            {
                _context.User.Add(item as User);
            }
            else
                throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllObject()
        {
            throw new NotImplementedException();
        }

        public T GetObject(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
