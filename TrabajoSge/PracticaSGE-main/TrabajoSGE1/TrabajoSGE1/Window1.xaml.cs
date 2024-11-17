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
    public partial class Window1 : Window
    {
        private String usuarioLog;
        private String rangoUsuario;
        public Window1(string usuLog,string rangoUser)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUser;
            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;
            Console.WriteLine(rangoUser);
            if (rangoUser != "Administrador")
            {
                btn_addTrabajador.IsEnabled = false;
                lbl_aviso.Visibility = Visibility.Visible;
            }
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btn_regSocio_Click(object sender, RoutedEventArgs e)
        {
            WindowRegSocios wrg = new WindowRegSocios(usuarioLog,rangoUsuario);
            wrg.Show();
            this.Close();
        }

        private void btn_retrasos_Click(object sender, RoutedEventArgs e)
        {
            WindowImpagos wi = new WindowImpagos(usuarioLog, rangoUsuario);
            wi.Show();
            this.Close();
        }

        private void btn_regLib_Click(object sender, RoutedEventArgs e)
        {
            WindowRegLibros wrg = new WindowRegLibros(usuarioLog, rangoUsuario);
            wrg.Show();
            this.Close();
        }

        private void btn_regRecib_Click(object sender, RoutedEventArgs e)
        {
            WindowRegRecibos wrr = new WindowRegRecibos(usuarioLog, rangoUsuario);
            wrr.Show();
            this.Close();
        }

        private void btn_addTrabajador_Click(object sender, RoutedEventArgs e)
        {
            WindowRegTrabajador wgt = new WindowRegTrabajador(usuarioLog, rangoUsuario);
            wgt.Show();
            this.Close();
        }
    }
}
