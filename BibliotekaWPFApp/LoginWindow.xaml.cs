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

namespace BibliotekaWPFApp
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public MainWindow mw;

        public LoginWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = this.mw.db.Users.FirstOrDefault(f => f.Login == loginTxt.Text && f.Password == passwordTxt.Password);

            if (user != null)
            {
                this.mw.loggedIn = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Niepoprawne dane logowania");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow(this.mw);
            rw.ShowDialog();
        }
    }
}