﻿using System;
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
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List : Page
    {
        private OpenFormEvents _event;
        public ICollection<Models.Object.Request> ListObject { get; }

        internal List(OpenFormEvents openFormEvents)
        {
            InitializeComponent();

            _event = openFormEvents;
            DataGridList.DataContext = ListObject;
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            _event.PageName = "ObjectRequest";
            _event.ToOpenForm();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridList.SelectedItem != null)
            {
                Models.Object.Request refObject = (Models.Object.Request)DataGridList.SelectedItem;

                _event.PageName = "ObjectRequest";
                _event.Id = refObject.Code;
                _event.ToOpenForm();
            }
        }
    }
}
