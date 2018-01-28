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
        LoadedFormEvents loadedFormEvents = new LoadedFormEvents();

        #region Private fields

        private Dictionary<string, Page> _listPage = new Dictionary<string, Page>();
        private List<string> _listSheets = new List<string>();

        #endregion

        #region Window events

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WorkWindow_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void ButtonRequestObject_Click(object sender, RoutedEventArgs e)
        {
            OpenForm("ObjectRequest");
        }

        private void ButtonRequestList_Click(object sender, RoutedEventArgs e)
        {
            OpenForm("ListRequest");
        }

        #endregion

        #region Open forms

        #region Sheets

        private void AddSheetOpenForm(string name, string caption)
        {
            if (!String.IsNullOrWhiteSpace(_listSheets.Find(f => f == name)))
                return;

            Style style;
            try
            {
                style = (Style)FindResource("ButtonMenuOpened");
            }
            catch (ResourceReferenceKeyNotFoundException)
            {
                Dialog.ShowMessage("Не удалось найти стиль оформления страницы открытого окна.");
                return;
            }

            Button button = new Button()
            {
                Name = name,
                Content = caption,
                Style = style,
            };
            button.Click += PressedButtonOpenForm;

            StackPanelOpened.Children.Add(button);

            _listSheets.Add(name);
        }

        private void PressedButtonOpenForm(object sender, RoutedEventArgs e)
        {
            OpenForm(((Button)e.Source).Name);

        }

        #endregion

        #region Change frame

        private void OpenForm(string formName)
        {
            if (FindPageName(formName) == null)
                openFormEvents.OpenForm += OpenOtherForm;

            Page form = FindPageName(formName);

            if (form == null)
            {
                switch (formName)
                {
                    case "ActionsRequest":
                        form = new Forms.FormRequest.Actions(openFormEvents);
                        break;
                    case "ListRequest":
                        form = new Forms.FormRequest.List(openFormEvents);
                        break;
                    case "ObjectRequest":
                        form = new Forms.FormRequest.Object(openFormEvents);
                        break;
                    default:
                        return;
                }

                form.Loaded += OpenForm_Loaded;
                AddPageInListPages(formName, form);
            }
            //else
            //    form.Loaded -= OpenForm_Loaded;

            FrameMain.Content = form;
        }

        private void OpenForm_Loaded(object sender, RoutedEventArgs e)
        {
            Page page = (Page)e.Source;
            if (FindPageName(page.Name) != null)
                AddSheetOpenForm(page.Name, page.Title);
        }

        internal void OpenOtherForm()
        {
            if (String.IsNullOrWhiteSpace(openFormEvents.PageName))
                return;

            OpenForm(openFormEvents.PageName);
        }

        #endregion

        #region List pages

        private Page FindPageName(string pageName)
        {
            Page form = null;

            var findedPage = _listPage.FirstOrDefault(f => f.Key == pageName);
            if (!String.IsNullOrWhiteSpace(findedPage.Key)
                && findedPage.Value != null)
                form = findedPage.Value;

            return form;
        }

        private void AddPageInListPages(string formName, Page form)
        {
            if (FindPageName(formName) == null)
                _listPage.Add(formName, form);
        }

        private void DeletePageInListPages(string formName)
        {
            if (String.IsNullOrWhiteSpace(formName))
                return;

            if (FindPageName(formName) != null)
                _listPage.Remove(formName);
        }

        #endregion

        #endregion

        private void TextBlockTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
