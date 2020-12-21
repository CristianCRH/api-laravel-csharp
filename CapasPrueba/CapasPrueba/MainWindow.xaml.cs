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
using Datos;
using Entidad;
namespace CapasPrueba
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToken_Click(object sender, RoutedEventArgs e)
        {

           try
           {
                bool auth = new Datos.Token().GetToken();
                if (auth)
                {

                    MessageBox.Show("Session iniciada", "" + MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al intentar iniciar sesion", "" + MessageBoxImage.Error);

                }
          }
           catch (Exception ex)
           {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTokenLocal_Click(object sender, RoutedEventArgs e)
        {
          string token = new Session().Access_token;
          txtToken.Text = token;
        }

        private void btnResource_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var data = new Datos.Products();
                txtToken.Text = "" + data.getProducts().id+"\n"+
                    data.getProducts().name;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnProductById_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = new Datos.Products();
                var dat = data.getProductById(50);

                txtToken.Text = dat.name + " \n" + dat.id;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
