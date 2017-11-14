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

namespace Milionerzy.WPF
{
    /// <summary>
    /// Interaction logic for NameChange.xaml
    /// </summary>
    public partial class NameChange : UserControl
    {
        private string name;

        public NameChange(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.mainPanel.Children.Clear();
            MainWindow.mainPanel.Children.Add(new Menu(name));
        }

        private void changeName(object sender, RoutedEventArgs e)
        {
            name = t.Text.ToString();
            MainWindow.mainPanel.Children.Clear();
            MainWindow.mainPanel.Children.Add(new Menu(name));
        }
    }
}
