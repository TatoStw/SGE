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
    /// Lógica de interacción para WindowAddLibro.xaml
    /// </summary>
    public partial class WindowAddLibro : Window
    {
        private string usuarioLog;
        private string rangoUsuario;
        private List<WindowRegLibros.Libro> listaLibros;

        public WindowAddLibro(string usuLog, string rangoUsu, List<WindowRegLibros.Libro> libros)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;
            listaLibros = libros;  // Referencia a la lista original de libros

            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cerramos la ventana sin hacer nada
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string isbn = txt_isbn.Text;
            string nombre = txt_nom.Text;
            string editorial = txt_editorial.Text;
            string year = txt_year.Text;
            string genero = txt_genero.Text;
            int precio = int.Parse(txt_precio.Text);
            int codBib = int.Parse(txt_codBib.Text);
            string autor = txt_autor.Text;

            // Creamos un nuevo socio y lo añadimos a la lista existente
            WindowRegLibros.Libro nuevoLibro = new WindowRegLibros.Libro()
            {
                ISBN = isbn,
                nombre = nombre,
                editorial = editorial,
                year = year,
                genero = genero,
                precio = precio,
                codBiblio = codBib,
                autor = autor
            };

            listaLibros.Add(nuevoLibro); // Se modifica la lista original de socios
            MessageBox.Show("Libro añadido correctamente.");

            // Cerramos la ventana para que se actualice la lista en la ventana principal
            this.Close();
        }
    }
}
