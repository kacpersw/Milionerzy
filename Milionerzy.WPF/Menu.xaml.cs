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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        private string name;
        public Menu(string name)
        {
            this.name = name;
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            MainWindow.mainPanel.Children.Clear();
            MainWindow.mainPanel.Children.Add(new NewGame(name));
        }

        private void changeName(object sender, RoutedEventArgs e)
        {
            MainWindow.mainPanel.Children.Clear();
            MainWindow.mainPanel.Children.Add(new NameChange(name));
        }

        private void checkResults(object sender, RoutedEventArgs e)
        {
            MainWindow.mainPanel.Children.Clear();
            MainWindow.mainPanel.Children.Add(new Results(name));
        }
    }
}
