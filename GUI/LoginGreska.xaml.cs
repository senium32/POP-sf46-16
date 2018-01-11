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

namespace POP_sf46_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for LoginGreska.xaml
    /// </summary>
    public partial class LoginGreska : Window
    {
        public LoginGreska()
        {
            InitializeComponent();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            
            Close();

        }
    }
}
