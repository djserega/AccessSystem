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

namespace AccessSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFormEvents openFormEvents = new OpenFormEvents();

        #region Private fields

        private Dictionary<string, Page> _listPage;
        private string _lastPage;

        #endregion

        #region Window events

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WorkWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _listPage = new Dictionary<string, Page>();
        }

        #endregion

        #region Main button

        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonExpand_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }


        #endregion

        #region Menu button

        private void ButtonRequest_Click(object sender, RoutedEventArgs e)
        {
            OpenForm("ActionsRequest");
        }

        private void ButtonBase_Click(object sender, RoutedEventArgs e)
        {
        }

        #endregion

        #region Open form (change frame)

        private void OpenForm(string newFormName)
        {
            if (FindPageName(newFormName) == null)
                openFormEvents.OpenForm += OpenOtherForm;

            Page form = null;

            switch (newFormName)
            {
                case "ActionsRequest":
                    form = new Forms.FormRequest.Actions(openFormEvents);
                    break;
                case "ListRequest":
                    form = new Forms.FormRequest.List();
                    break;
                case "ObjectRequest":
                    form = new Forms.FormRequest.Object();
                    break;
                default:
                    return;
            }

            FrameMain.Content = form;
            _lastPage = newFormName;

            AddPageInListPages();
        }

        internal void OpenOtherForm()
        {
            if (String.IsNullOrWhiteSpace(openFormEvents.PageName))
                return;

            DeletePageInListPages();
            OpenForm(openFormEvents.PageName);
        }

        #region List pages

        private Page FindPageName(string currentPageName)
        {
            Page form = null;

            if (!String.IsNullOrWhiteSpace(_lastPage))
            {
                var findedPage = _listPage.FirstOrDefault(f => f.Key == currentPageName);
                if (!String.IsNullOrWhiteSpace(findedPage.Key))
                    form = findedPage.Value;
            }

            return form;
        }

        private void AddPageInListPages()
        {
            var findedPage = _listPage.FirstOrDefault(f => f.Key == _lastPage);
            if (String.IsNullOrWhiteSpace(findedPage.Key))
                _listPage.Add(_lastPage, (Page)FrameMain.Content);
        }

        private void DeletePageInListPages()
        {
            if (String.IsNullOrWhiteSpace(_lastPage))
                return;

            var findedPage = _listPage.FirstOrDefault(f => f.Key == _lastPage);
            if (!String.IsNullOrWhiteSpace(findedPage.Key))
                _listPage.Remove(_lastPage);
        }

        #endregion

        #endregion
    }
}
