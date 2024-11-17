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
    /// Lógica de interacción para WindowRegLibros.xaml
    /// </summary>
    public partial class WindowRegLibros : Window
    {
        private string usuarioLog;
        private string rangoUsuario;
        private List<Libro> lista;
        private List<Recibo> listaRec;

        public WindowRegLibros(string usuLog, string rangoUsu)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;

            // Inicializamos la lista de socios, con algunos valores de ejemplo o vacía
            lista = new List<Libro>
            {
                new Libro() { ISBN = "1234", nombre = "Libro 1", editorial = "asaber.es", year = "12/12/2022", genero = "no binario", precio = 2, codBiblio = 1, autor = "pascu" },
                new Libro() { ISBN = "2345", nombre = "libro 2", editorial = "asaber.com", year = "11/11/2011", genero = "binario", precio = 2, codBiblio = 2, autor = "joshua" }
            };

            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;

            // Establecemos la lista en el ListBox
            lst_libros.ItemsSource = lista;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(usuarioLog, rangoUsuario);
            w1.Show();
            this.Close();
        }

        // Método para actualizar la lista en el ListBox después de cambios
        public void ActualizarListaLibros()
        {
            lst_libros.ItemsSource = null;
            lst_libros.ItemsSource = lista;  // Se vuelve a asignar la lista actualizada
        }

        public class Libro
        {
            public string ISBN { get; set; }
            public string nombre { get; set; }
            public string editorial { get; set; }
            public string year { get; set; }
            public string genero { get; set; }
            public int precio { get; set; }
            public int codBiblio { get; set; }
            public string autor { get; set; }
        }

        public class Recibo
        {
            public int Id { get; set; }
            public int numSoc { get; set; }
            public int fechaRec { get; set; }
            public int recibosCol { get; set; }
            public int isbnLib { get; set; }
        }

        private void btn_addSocio_Click(object sender, RoutedEventArgs e)
        {
            WindowAddLibro was = new WindowAddLibro(usuarioLog, rangoUsuario, lista);
            was.Closed += (s, args) => ActualizarListaLibros(); // Actualizamos al cerrar la ventana
            was.Show();
        }

        private void btn_alqLibro_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
