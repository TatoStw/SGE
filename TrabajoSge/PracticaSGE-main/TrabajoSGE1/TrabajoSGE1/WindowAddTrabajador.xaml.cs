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

namespace TrabajoSGE1
{
    /// <summary>
    /// Lógica de interacción para WindowAddTrabajador.xaml
    /// </summary>
    public partial class WindowAddTrabajador : Window
    {
        private string usuarioLog;
        private string rangoUsuario;
        private List<WindowRegTrabajador.Trabajador> listaTrabajadores;

        public WindowAddTrabajador(string usuLog, string rangoUsu, List<WindowRegTrabajador.Trabajador> trabajador)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;
            listaTrabajadores = trabajador;  // Referencia a la lista original de trabajadores

            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cerramos la ventana sin hacer nada
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            int id = 1;
            string usuario = txt_usu.Text;
            string pass = txt_pass.Text;
            string email = txt_email.Text;

            // Validamos que los campos requeridos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Creamos un nuevo socio y lo añadimos a la lista existente
            WindowRegTrabajador.Trabajador newTrabajador = new WindowRegTrabajador.Trabajador(id,usuario,pass,email);

            listaTrabajadores.Add(newTrabajador); // Se modifica la lista original de socios
            MessageBox.Show("Trabajador añadido correctamente.");

            // Cerramos la ventana para que se actualice la lista en la ventana principal
            this.Close();
        }
    }
}
