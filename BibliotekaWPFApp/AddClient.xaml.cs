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
    /// klasa Addbook ktora dziedziczy Window z System.Windows sluzy do dodawania ksiazek
    /// </summary>
    public partial class AddClient : Window
    {
        /// <summary>
        /// setter getter dla zmiennej Mw typ danych MainWindow
        /// </summary>
        public MainWindow Mw { get; set; }
        /// <summary>
        /// konstruktor dla klasy addclient
        /// </summary>
        public AddClient(MainWindow mw)
        {
            InitializeComponent();

            this.Mw = mw;
        }
        /// <summary>
        /// metoda dla eventu zapisz dane wprowadzone przez usera
        /// </summary>
        private void zapiszBtn_Click(object sender, RoutedEventArgs e)
        {
            //spradzanie danych
            if (string.IsNullOrEmpty(nameTxt.Text) || string.IsNullOrEmpty(surnameTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            //dodawanie danych 
            else
            {
                Client c = new Client(nameTxt.Text, surnameTxt.Text);

                Mw.db.Clients.Add(c);
                Mw.db.SaveChanges();

                Mw.Load();
                Mw.IsEnabled = true;

                this.Close();
            }
        }
        /// <summary>
        /// zamkniecie okna
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            Mw.IsEnabled = true;
        }
    }
}
