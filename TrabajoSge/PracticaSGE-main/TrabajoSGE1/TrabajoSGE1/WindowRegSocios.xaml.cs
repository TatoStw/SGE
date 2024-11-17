using System;
using System.Collections.Generic;
using System.Windows;

namespace TrabajoSGE1
{
    public partial class WindowRegSocios : Window
    {
        private string usuarioLog;
        private string rangoUsuario;
        private List<Socio> lista;

        public WindowRegSocios(string usuLog, string rangoUsu)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;

            // Inicializamos la lista de socios, con algunos valores de ejemplo o vacía
            lista = new List<Socio>
            {
                new Socio() { Id = 1, Dni = "12345678A", Nombre = "Juan", CuentBanc = "****1234", Dir = "Calle Falsa 123", Cuota = "Pagada", FechAlt = "01/01/2024", FechCad = "01/02/2024" },
                new Socio() { Id = 2, Dni = "23456789B", Nombre = "Ana", CuentBanc = "****5678", Dir = "Calle Real 456", Cuota = "Pendiente", FechAlt = "02/01/2024", FechCad = "02/02/2024" }
            };

            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;

            // Establecemos la lista en el ListBox
            lst_socios.ItemsSource = lista;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(usuarioLog, rangoUsuario);
            w1.Show();
            this.Close();
        }

        // Método para actualizar la lista en el ListBox después de cambios
        public void ActualizarListaSocios()
        {
            lst_socios.ItemsSource = null;
            lst_socios.ItemsSource = lista;  // Se vuelve a asignar la lista actualizada
        }

        private void btn_addSocio_Click(object sender, RoutedEventArgs e)
        {
            // Pasamos la lista actual a la nueva ventana
            WindowAddSocio was = new WindowAddSocio(usuarioLog, rangoUsuario, lista);
            was.Closed += (s, args) => ActualizarListaSocios(); // Actualizamos al cerrar la ventana
            was.Show();
        }

        public class Socio
        {
            public int Id { get; set; }
            public string Dni { get; set; }
            public string Nombre { get; set; }
            public string CuentBanc { get; set; }
            public string Dir { get; set; }
            public string Cuota { get; set; }
            public string FechAlt { get; set; }
            public string FechCad { get; set; }
        }
    }
}

