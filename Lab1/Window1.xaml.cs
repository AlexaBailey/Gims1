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
using System.Windows.Shapes;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._mask[0, 0] = Convert.ToInt32(tb1.Text);
            MainWindow._mask[0, 1] = Convert.ToInt32(tb2.Text);
            MainWindow._mask[0, 2] = Convert.ToInt32(tb3.Text);
            MainWindow._mask[1, 0] = Convert.ToInt32(tb4.Text);
            MainWindow._mask[1, 1] = Convert.ToInt32(tb5.Text);
            MainWindow._mask[1, 2] = Convert.ToInt32(tb6.Text);
            MainWindow._mask[2, 0] = Convert.ToInt32(tb7.Text);
            MainWindow._mask[2, 1] = Convert.ToInt32(tb8.Text);
            MainWindow._mask[2, 2] = Convert.ToInt32(tb9.Text);
            Close();
        }
    }
}
