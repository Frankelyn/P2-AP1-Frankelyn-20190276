using P2_AP1_Frankelyn_20190276.BLL;
using P2_AP1_Frankelyn_20190276.Entidades;
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

namespace P2_AP1_Frankelyn_20190276.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cTipoDeTarea.xaml
    /// </summary>
    public partial class cTipoDeTarea : Window
    {
        public cTipoDeTarea()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TipoDeTarea>();

            if (CriterioTextbox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            listado = TipoDeTareaBLL.GetList(e => e.Descripcion.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            break;
                        }
                    case 1:
                        {
                            listado = TipoDeTareaBLL.GetList(e => e.TiempoAcumulado == Utilidades.Toint(CriterioTextbox.Text));
                            break;
                        }
                }
            }
            else
            {
                listado = TipoDeTareaBLL.GetList(e => true);
            }


            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count();

            ConteoTextBox.Text = conteo.ToString();
        }
    }
}
