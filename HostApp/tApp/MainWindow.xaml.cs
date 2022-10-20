using McMaster.NETCore.Plugins;
using Plugin_Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace tApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Exce();
        }
        List<PluginLoader> loaders = new List<PluginLoader>();
        List<IPlugin> plugins = new List<IPlugin>();
        void Exce()
        {
            PluginCore.LoadPlugin(out loaders, out plugins);
        }
    }
}