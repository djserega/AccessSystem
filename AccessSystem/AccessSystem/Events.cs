using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AccessSystem
{
    internal delegate void OpenFormName();

    internal class OpenFormEvents : EventArgs
    {
        internal event OpenFormName OpenForm;

        internal string PageName { get; set; }
        internal int Id { get; set; }

        internal void ToOpenForm()
        {
            if (OpenForm == null)
                return;

            OpenForm();
        }
    }

    internal delegate void LoadingForms();

    internal class LoadedFormEvents : EventArgs
    {
        internal event LoadingForms LoadingForms;

        internal string FormName { get; set; }
        internal string FormCaption { get; set; }

        internal void FormIsLoaded()
        {
            if (LoadingForms == null)
                return;

            LoadingForms();
        }
    }

}
