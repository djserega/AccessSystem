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
            else
                return null;
        }
    }
}
