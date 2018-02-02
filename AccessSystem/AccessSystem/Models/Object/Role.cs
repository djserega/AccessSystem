using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.Models.Object
{
    public interface IRole
    {
        int Code { get; set; }
        string Name { get; set; }
        string Synonym { get; set; }
    }

    public class Role : IRole
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Synonym { get; set; }
    }
}
