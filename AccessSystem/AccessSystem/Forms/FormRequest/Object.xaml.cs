using AccessSystem.Models.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Regex _regExpCode = new Regex("[^0-9]");

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


        private void TextBoxCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxCode.Text = _regExpCode.Replace(TextBoxCode.Text, "");
        }

        private void TextBoxCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regExpCode.IsMatch(e.Text);
        }

        private void TextBoxCode_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }
    }
}
