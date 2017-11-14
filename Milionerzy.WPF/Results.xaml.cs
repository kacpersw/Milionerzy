using Milionerzy.Logic;
using Milionerzy.Models;
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
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : UserControl
    {
        private string name;
        public List<Result> results = new List<Result>();
        public Results(string name)
        {
            InitializeComponent();
            this.name = name;
            readResults();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.mainPanel.Children.Clear();
            MainWindow.mainPanel.Children.Add(new Menu(name));
        }

        private void readResults()
        {
            results = RWResults.readResults();
            for (int i = 0; i < results.Count; i++)
            {
                tb.Text += (i + 1) + ". " + results[i].Name + " " + results[i].Points + "\n";
            }
        }
    }
}
