using System;
using System.Collections;
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
using static TrabajoSGE1.MainWindow;
using static TrabajoSGE1.WindowRegSocios;

namespace TrabajoSGE1
{
    /// <summary>
    /// Lógica de interacción para WindowRegTrabajador.xaml
    /// </summary>
    public partial class WindowRegTrabajador : Window
    {
        private string usuarioLog;
        private string rangoUsuario;
        private List<Trabajador> lista;
        public WindowRegTrabajador(string usuLog, string rangoUsu)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;

            // Inicializamos la lista de trabajadores si no está inicializada
            lista = new List<Trabajador>();

            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;

            // Establecemos la lista en el ListBox
            lst_trabajadores.ItemsSource = lista;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(usuarioLog, rangoUsuario);
            w1.Show();
            this.Close();
        }

        // Método para actualizar la lista en el ListBox después de cambios
        public void ActualizarListaTrabajadores()
        {
            lst_trabajadores.ItemsSource = null;
            lst_trabajadores.ItemsSource = lista;  // Se vuelve a asignar la lista actualizada
        }

        private void btn_addTrabajador_Click(object sender, RoutedEventArgs e)
        {
            // Pasamos la lista actual a la nueva ventana
            WindowAddTrabajador was = new WindowAddTrabajador(usuarioLog, rangoUsuario, lista);
            was.Closed += (s, args) => ActualizarListaTrabajadores(); // Actualizamos al cerrar la ventana
            was.Show();
        }

        public class Trabajador
        {

            public Trabajador(int id, string usuario, string pass, string email)
            {
                this.Id = id;
                this.Usuario = usuario;
                this.Pass = pass;
                this.email = email;
            }
            public int Id { get; set; }
            public string Usuario { get; set; }
            public string Pass { get; set; }
            public string email { get; set; }
        }
    }
}
