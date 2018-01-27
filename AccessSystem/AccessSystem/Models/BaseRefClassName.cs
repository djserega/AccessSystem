using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.Models
{
    public abstract class BaseRefClassName : IBaseRefClass
    {
        public abstract string this[string columnName] { get; }

        public abstract string Name { get; set; }
        public abstract int Code { get; set; }
        public abstract string Comment { get; set; }
        public abstract bool Deletion { get; set; }
        public abstract string Error { get; }
    }
}
