using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.Models.Object
{
    public class Base : IBaseRefClassName
    {
        public string this[string columnName]
        {
            get
            {
                string error = "";

                switch (columnName)
                {
                    case "Code":
                        if (Code.ToString().Count() > 9)
                            error = "Длина должна быть не больше 9 символов.";
                        else
                        {
                            try
                            {
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                        break;
                }

                return error;
            }
        }
        public string Error { get; }

        [DisplayName("Код")]
        public int Code { get; set; }
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Строка подключения")]
        public string ConnectionURI { get; set; }
        [DisplayName("Комментарий")]
        public string Comment { get; set; }
        public bool Deletion { get; set; }
    }
}
