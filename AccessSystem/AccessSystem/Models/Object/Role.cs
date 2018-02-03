using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Код")]
        public int Code { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Наименование")]
        public string Synonym { get; set; }
    }
}
