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
    /// Lógica de interacción para WindowImpagos.xaml
    /// </summary>
    public partial class WindowImpagos : Window
    {
        private string usuarioLog;
        private string rangoUsuario;
        public WindowImpagos(string usuLog, string rangoUsu)
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
    }
}
