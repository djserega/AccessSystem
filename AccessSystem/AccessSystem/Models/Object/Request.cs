using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.Models.Object
{
    public class Request : IBaseRefClassDate
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
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Комментарий")]
        public string Comment { get; set; }
        public bool Deletion { get; set; }
        [DisplayName("Статус")]
        public StatusRequest Status { get; set; }
        [DisplayName("Пользователь")]
        public User User { get; set; }
        public ICollection<Role> Roles { get; set; }

        public Request()
        {
            Roles = new List<Role>();
        }
    }
}
