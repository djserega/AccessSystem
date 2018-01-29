using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.Models.Object
{
    public enum StatusRequest { empty, moderated, approved }
    public enum TypesAccessRights { all, read, create, posted, deletion }
    public enum TypeUser { admin, user, onlyread }
    public enum SortDirection { none, asc, dsc }

    internal static class GetValueEnum
    {
        internal static object Get(Type type, string value)
        {
            if (type == typeof(TypeUser))
                return Get_TypeUser(value);
            else if (type == typeof(StatusRequest))
                return Get_StatusRequest(value);
            else
                return null;
        }

        private static object Get_TypeUser(string value)
        {
            switch (value)
            {
                case "admin":
                    return TypeUser.admin;
                case "user":
                    return TypeUser.user;
                case "onlyread":
                    return TypeUser.onlyread;
                default:
                    return null;
            }
        }

        private static object Get_StatusRequest(string value)
        {
            switch (value)
            {
                case "empty":
                    return StatusRequest.empty;
                case "moderated":
                    return StatusRequest.moderated;
                case "approved":
                    return StatusRequest.approved;
                default:
                    return null;
            }
        }
    }
}
