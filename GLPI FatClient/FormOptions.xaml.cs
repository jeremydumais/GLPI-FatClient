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

namespace GLPI_FatClient
{
    /// <summary>
    /// Interaction logic for FormOptions.xaml
    /// </summary>
    public partial class FormOptions : Window
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the actual preferences
            textBoxGLPIURL.Text = Properties.Settings.Default.GLPIUrlAddress;
            textBoxAppToken.Text = Properties.Settings.Default.AppToken;
            textBoxUserToken.Text = Properties.Settings.Default.UserToken;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //Load the actual preferences
            Properties.Settings.Default.GLPIUrlAddress = textBoxGLPIURL.Text.Trim();
            Properties.Settings.Default.AppToken = textBoxAppToken.Text.Trim();
            Properties.Settings.Default.UserToken = textBoxUserToken.Text.Trim();
            Properties.Settings.Default.Save();
            DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
