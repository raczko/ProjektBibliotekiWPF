using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public MainWindow mw;

        public RegistrationWindow(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private bool EmailIsValid(string emailaddress)
        {
            return MailAddress.TryCreate(emailaddress, out _);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.Matches(passwordTxt.Text, "[A-Z]").Count < 1 || Regex.Matches(passwordTxt.Text, "[0-9]").Count < 1 || Regex.Matches(passwordTxt.Text, @"[0-9a-zA-Z\.-]").Count < 1 || string.IsNullOrEmpty(loginTxt.Text) || loginTxt.Text.Length < 5 || string.IsNullOrEmpty(passwordTxt.Text) || passwordTxt.Text.Length < 5)
            {
                MessageBox.Show("Login and password have to 5 character or Possword have to contain 1 big letter, 1 number, 1 symbol");
            }
            else if (!EmailIsValid(emailTxt.Text))
            {
                MessageBox.Show("Adress email is incorrect");
            }
            else if (this.mw.db.Users.Any(a => a.Login == loginTxt.Text))
            {
                MessageBox.Show("The given login is taken");
            }
            else
            {
                User user = new User(loginTxt.Text, passwordTxt.Text, emailTxt.Text);
                this.mw.db.Users.Add(user);
                this.mw.db.SaveChanges();
                this.Close();
            }
        }
    }
}