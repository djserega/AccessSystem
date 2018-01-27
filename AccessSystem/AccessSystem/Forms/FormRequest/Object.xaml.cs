using AccessSystem.Models.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccessSystem.Forms.FormRequest
{
    /// <summary>
    /// Логика взаимодействия для Object.xaml
    /// </summary>
    public partial class Object : Page
    {
        Request Ref = null;

        public Object(Request @ref = null)
        {
            InitializeComponent();

            if (@ref == null)
                Ref = new Request();
            else
                Ref = @ref;

            DataContext = Ref;
        }
    }
}
