using P2_AP1_Frankelyn_20190276.UI.Consultas;
using P2_AP1_Frankelyn_20190276.UI.Registros;
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

namespace P2_AP1_Frankelyn_20190276
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConsultaTipoDeTareaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cTipoDeTarea cTipoDeTarea = new cTipoDeTarea();
            cTipoDeTarea.Show();
        }

        private void ProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProyectos rProyectos = new rProyectos();
            rProyectos.Show();
        }

        private void ConsultaProyectoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProyectos cProyectos = new cProyectos();
            cProyectos.Show();
        }
    }
}
