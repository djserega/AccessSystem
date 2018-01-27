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
    /// Логика взаимодействия для Actions.xaml
    /// </summary>
    public partial class Actions : Page
    {
        private OpenFormEvents Event { get; set; }

        internal Actions(OpenFormEvents openFormEvents)
        {
            InitializeComponent();

            Event = openFormEvents;
        }

        private void HyperLinkList_Click(object sender, RoutedEventArgs e)
        {
            Event.PageName = "ListRequest";
            Event.ToOpenForm();
        }

        private void HyperLinlObject_Click(object sender, RoutedEventArgs e)
        {
            Event.PageName = "ObjectRequest";
            Event.ToOpenForm();
        }
    }
}
