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
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : UserControl
    {
        public NewGame()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {

        }

        private void Answer(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            ClearButtons();
            ((Button)sender).Style = (Style)this.TryFindResource("RoundedButtonStyle2");
            ((Button)sender).Foreground = (Brush)bc.ConvertFrom("#002F7F");

        }
        private void ClearButtons()
        {
            var bc = new BrushConverter();
            A.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            B.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            C.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            D.Style = (Style)this.TryFindResource("RoundedButtonStyle");
            A.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
            B.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
            C.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
            D.Foreground = (Brush)bc.ConvertFrom("#DBBC2E");
        }
    }
}
