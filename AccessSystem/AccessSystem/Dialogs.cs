using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccessSystem
{
    internal static class Dialog
    {
        internal static bool DialogQuestion(string textQuestion)
        {
            return MessageBox.Show(textQuestion, "Вопрос", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;
        }

        internal static void ShowMessage(string textMessage, int timer = 10)
        {
            if (timer == 0)
            {
                MessageBox.Show(textMessage);
            }
            else
            {
                Application.Current.Dispatcher.InvokeAsync(async () =>
                {
                    Forms.Message form = new Forms.Message(textMessage, timer);
                    form.Show();
                    await Task.Delay(timer * 1000);
                    form.Close();
                });
            }
        }
    }
}
