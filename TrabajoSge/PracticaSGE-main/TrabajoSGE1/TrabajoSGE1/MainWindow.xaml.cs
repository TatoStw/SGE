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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrabajoSGE1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, Usuario> listUser = new Dictionary<string, Usuario>(); //Dictionary para guardar todos los usuarios

        public MainWindow()
        {
            InitializeComponent();
            listUser.Add("jose.tato", new Usuario("jose.tato", "jose1" , "Administrador"));
            listUser.Add("alex.pascu", new Usuario("alex.pascu", "alex1", "Administrativo"));
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            string usuarioIngresado = txt_usu.Text;
            string passIngresado = txt_pass.Password;

            if (listUser.TryGetValue(usuarioIngresado, out Usuario usuario)) //if para buscar en Dictionary si existe el usuario
            {
                if (usuario.Pass.Equals(passIngresado)) //if para confirmar que la contraseña sea correcta
                {
                    Window1 window1 = new Window1(usuarioIngresado,usuario.RangoUser);
                    window1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.");
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
            }
        }

        public class Usuario
        {
            public string usuario;
            public string pass;
            public string rango;

            public Usuario(string usuarioName, string pass, string rangoUser)
            {
                UsuarioName = usuarioName;
                Pass = pass;
                RangoUser = rangoUser; // Asegúrate de que esta propiedad se configure correctamente
            }

            public string UsuarioName
            {
                get { return usuario; }
                set { usuario = value; }
            }

            public string Pass
            {
                get { return pass; }
                set { pass = value; }
            }
            public string RangoUser
            {
                get { return usuario; }
                set { usuario = value; }
            }
        }
    }
}
