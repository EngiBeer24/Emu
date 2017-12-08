using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace EmuConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SystemsConfig systemsConfig = new SystemsConfig();
        public MainWindow()
        {
            InitializeComponent();
            systemsConfig.LoadSystemsConfigFile();
            RomDirTextBox.Text = systemsConfig.GetRomRoot();
        }

        private void RomDirButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                RomDirTextBox.Text = dialog.SelectedPath;
            }
        }
    }
}
