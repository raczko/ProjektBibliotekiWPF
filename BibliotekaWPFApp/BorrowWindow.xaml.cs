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
    /// Logika interakcji dla klasy BorrowWindow.xaml
    /// </summary>
    public partial class BorrowWindow : Window
    {
        /// <summary>
        /// getter setter dla danych ponizej
        /// </summary>
        public MainWindow Mw { get; set; }
        public Book Book { get; set; }
        /// <summary>
        /// konstruktor dla borrowWindow zapisujcy dane
        /// </summary>
        public BorrowWindow(Book book, MainWindow mw)
        {
            InitializeComponent();
            Book = book;
            Mw = mw;

            clientsCmb.ItemsSource = Mw.db.Clients.ToList();
            clientsCmb.SelectedIndex = 0;
        }
        /// <summary>
        /// metoda dla buttona
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client c = clientsCmb.SelectedItem as Client;

            if (c == null)
            {
                MessageBox.Show("Wybierz kilenta.");
            }
            else
            {
                Borrow b = new Borrow(Book.Id,c.Id);
                Mw.db.Borrows.Add(b);
                Mw.db.SaveChanges();
                Mw.Load();

                this.Close();
                Mw.IsEnabled = true;
            }
        }
        /// <summary>
        /// zamykanie okna
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            Mw.IsEnabled = true;
        }
    }
}
