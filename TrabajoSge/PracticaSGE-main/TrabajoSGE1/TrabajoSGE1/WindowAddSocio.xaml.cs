using System;
using System.Collections.Generic;
using System.Windows;

namespace TrabajoSGE1
{
    public partial class WindowAddSocio : Window
    {
        private string usuarioLog;
        private string rangoUsuario;
        private List<WindowRegSocios.Socio> listaSocios;

        public WindowAddSocio(string usuLog, string rangoUsu, List<WindowRegSocios.Socio> socios)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;
            listaSocios = socios;  // Referencia a la lista original de socios

            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cerramos la ventana sin hacer nada
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            int id = listaSocios.Count;
            string dni = txt_dni.Text;
            string nombre = txt_nom.Text;
            int cadLenght = txt_cuentaB.Text.Length;
            string cuentaBancaria = "****" + txt_cuentaB.Text.Substring(cadLenght - 4);
            string direccion = txt_dir.Text;
            string cuota = "Pagada";
            DateTime fecha = DateTime.Now;
            string fechaAlta = fecha.ToString("dd/MM/yyyy");
            string fechaCaducidad = fecha.AddMonths(1).ToString("dd/MM/yyyy");

            // Validamos que los campos requeridos no estén vacíos
            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Creamos un nuevo socio y lo añadimos a la lista existente
            WindowRegSocios.Socio nuevoSocio = new WindowRegSocios.Socio()
            {
                Dni = dni,
                Nombre = nombre,
                CuentBanc = cuentaBancaria,
                Dir = direccion,
                Cuota = cuota,
                FechAlt = fechaAlta,
                FechCad = fechaCaducidad
            };

            listaSocios.Add(nuevoSocio); // Se modifica la lista original de socios
            MessageBox.Show("Socio añadido correctamente.");

            // Cerramos la ventana para que se actualice la lista en la ventana principal
            this.Close();
        }
    }
}


