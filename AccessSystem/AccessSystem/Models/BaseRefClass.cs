using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccessSystem.Models
{
    public interface IBaseRefClass
    {
        string this[string columnName] { get; }

        int Code { get; set; }
        string Comment { get; set; }
        bool Deletion { get; set; }
        string Error { get; }
    }

    public abstract class BaseRefClass : IBaseRefClass, IDataErrorInfo
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

        public int Code { get; set; }
        public bool Deletion { get; set; }
        public string Comment { get; set; }

        public string Error
        {
            get
            {
                MessageBox.Show("Ошибка");
                throw new NotImplementedException();
            }
        }
    }

}
