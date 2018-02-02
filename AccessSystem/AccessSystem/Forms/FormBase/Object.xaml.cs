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

namespace AccessSystem.Forms.FormBase
{
    /// <summary>
    /// Логика взаимодействия для Object.xaml
    /// </summary>
    public partial class Object : Page
    {
        Regex _regExpCode = new Regex("[^0-9]");

        Base Ref = null;

        private OpenFormEvents _event;

        internal Object(OpenFormEvents openFormEvents = null, Base @ref = null)
        {
            InitializeComponent();

            if (@ref == null)
                Ref = new Base();
            else
                Ref = @ref;

            DataContext = Ref;
            _event = openFormEvents;
        }

        #region Menu

        private void MenuItemSaveClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            Dialog.ShowMessage("База записана");
        }

        #endregion

        #region Elements

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

        #endregion

        private void ObjectBase_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridRole.ItemsSource = Ref.Roles;
        }
    }
}
