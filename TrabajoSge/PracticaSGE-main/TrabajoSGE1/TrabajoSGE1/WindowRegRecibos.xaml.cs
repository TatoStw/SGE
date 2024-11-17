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
using static TrabajoSGE1.WindowRegSocios;

namespace TrabajoSGE1
{
    /// <summary>
    /// Lógica de interacción para WindowRegRecibos.xaml
    /// </summary>
    public partial class WindowRegRecibos : Window
    {
        private string usuarioLog;
        private string rangoUsuario;


        public WindowRegRecibos(string usuLog, string rangoUsu)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;
            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(usuarioLog, rangoUsuario);
            w1.Show();
            this.Close();
        }

        private void btn_addSocio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
