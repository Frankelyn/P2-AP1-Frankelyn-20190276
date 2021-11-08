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

namespace P2_AP1_Frankelyn_20190276.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private Proyectos Proyecto = new Proyectos();
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = Proyecto;

            TipoDeTareaComboBox.ItemsSource = TipoDeTareaBLL.GetTiposDeTarea();
            TipoDeTareaComboBox.SelectedValuePath = "TipoDeTareaId";
            TipoDeTareaComboBox.DisplayMemberPath = "Descripcion";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Proyecto;
        }

        private void Limpiar()
        {
            this.Proyecto = new Proyectos();
            this.DataContext = Proyecto;
        }

        private bool Validar()
        {
            bool esValido = true;
            if(DescriopcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el campo Descripcion", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(DetalleDataGrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar los tipos de tarea", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var proyecto = ProyectosBLL.Buscar(Proyecto.ProyectoId);

            if(proyecto != null)
            {
                this.Proyecto = proyecto;
                this.DataContext = Proyecto;
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Cargar();
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new ProyectosDetalle
            {
                ProyectoId = this.Proyecto.ProyectoId,
                TipoDeTarea = (TipoDeTarea)TipoDeTareaComboBox.SelectedItem,
                Requerimiento = RequerimientoTextBox.Text,
                Tiempo = Utilidades.Toint(MinutosTextBox.Text)
            };

            Proyecto.TiempoTotal += Utilidades.Toint(MinutosTextBox.Text);

            Proyecto.Detalle.Add(detalle);
            Cargar();
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                var detalle = (ProyectosDetalle)DetalleDataGrid.SelectedItem;

                Proyecto.TiempoTotal -= detalle.Tiempo;

                Proyecto.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);

                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ProyectosBLL.Guardar(Proyecto);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Trasaccion exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Trasaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(Proyecto.ProyectoId))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
