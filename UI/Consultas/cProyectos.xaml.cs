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
    /// Interaction logic for cProyectos.xaml
    /// </summary>
    public partial class cProyectos : Window
    {
        public cProyectos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Proyectos> listado = new List<Proyectos>();

            if(CriterioTextbox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                                listado = ProyectosBLL.GetList(
                                    x => x.Fecha.Date >= DesdeDatePicker.SelectedDate && x.Fecha.Date <= HastaDatePicker.SelectedDate &&
                                    x.ProyectoId == Utilidades.Toint(CriterioTextbox.Text));
                            else
                                listado = ProyectosBLL.GetList(x => x.ProyectoId == Utilidades.Toint(CriterioTextbox.Text));
                            break;
                        }

                    case 1:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                                listado = ProyectosBLL.GetList(
                                    x => x.Fecha.Date >= DesdeDatePicker.SelectedDate && x.Fecha.Date <= HastaDatePicker.SelectedDate &&
                                    x.Descripcion.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            else
                                listado = ProyectosBLL.GetList(x => x.Descripcion.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            break;
                        }

                    case 2:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                                listado = ProyectosBLL.GetList(
                                    x => x.Fecha.Date >= DesdeDatePicker.SelectedDate && x.Fecha.Date <= HastaDatePicker.SelectedDate &&
                                    x.TiempoTotal == Utilidades.Toint(CriterioTextbox.Text));
                            else
                                listado = ProyectosBLL.GetList(x => x.TiempoTotal == Utilidades.Toint(CriterioTextbox.Text));
                            break;
                        }
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(x => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count();
            ConteoTextBox.Text = conteo.ToString();
        }
    }
}
