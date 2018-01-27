using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.Models
{
    public interface IBaseRefClassDate
    {
        string this[string columnName] { get; }

        int Code { get; set; }
        string Comment { get; set; }
        DateTime Date { get; set; }
        bool Deletion { get; set; }
        string Error { get; }
    }

    public abstract class BaseRefClassDate : IBaseRefClass, IBaseRefClassDate
    {
        public abstract string this[string columnName] { get; }

        public abstract DateTime Date { get; set; }
        public abstract int Code { get; set; }
        public abstract string Comment { get; set; }
        public abstract bool Deletion { get; set; }
        public abstract string Error { get; }
    }
}
