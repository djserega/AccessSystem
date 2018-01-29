using System;
using System.Collections.Generic;
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


        public int Code { get; set; }

        public string Comment { get; set; }

        public bool Deletion { get; set; }

        public string Name { get; set; }

        public string ConnectionURI { get; set; }
    }
}
