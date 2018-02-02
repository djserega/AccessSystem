using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.Models.Object
{
    public class RequestRole : IRole
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Synonym { get; set; }
        public int Checked { get; set; }
    }
}
