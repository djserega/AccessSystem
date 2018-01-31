using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AccessSystem.Forms
{
    internal class GeneralMethods : Page
    {
        internal void SetBaseStyleDataGrid(ref DataGrid dataGrid)
        {
            Style styleColumns = (Style)FindResource("DataGridColumnHeaderBase");

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].HeaderStyle = styleColumns;
                dataGrid.Columns[i].Header = $"  {dataGrid.Columns[i].Header}  ";
            }
        }
    }
}
