using Microsoft.EntityFrameworkCore;
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

namespace BibliotekaWPFApp
{
    /// <summary>
    /// klasa MainWindow ktora dziedziczy window
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool loggedIn = false;
        /// <summary>
        /// getter setter dla danych
        /// </summary>
        public BibliotekaDb db { get; set; }
        /// <summary>
        /// konstruktor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            db = new BibliotekaDb();

            LoginWindow lw = new LoginWindow(this);
            lw.ShowDialog();

            if(!loggedIn)
            {
                this.Close();
            }

            Load();
        }
        /// <summary>
        /// funkcja ladujaca 
        /// </summary>
        public void Load()
        {
            booksGrid.ItemsSource = null;
            booksGrid.ItemsSource = db.Books.Include(i=>i.Category).ToList();
            clientsGrid.ItemsSource = null;
            clientsGrid.ItemsSource = db.Clients.ToList();      
            borrowsGrid.ItemsSource = null;
            borrowsGrid.ItemsSource = db.Borrows.ToList();
        }

        private void addBookBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBook ab = new AddBook(this);
            ab.Show();
            this.IsEnabled = false;
        }

        private void removeBookBtn_Click(object sender, RoutedEventArgs e)
        {
            if(booksGrid.SelectedItem != null && booksGrid.SelectedItem is Book)
            {
                Book book = booksGrid.SelectedItem as Book;
                db.Books.Remove(book);
                db.SaveChanges();
                Load();
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do usunięcia!");
            }
        }

        private void addClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClient ac = new AddClient(this);
            ac.Show();
            this.IsEnabled = false;
        }

        private void removeClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (clientsGrid.SelectedItem != null && clientsGrid.SelectedItem is Client)
            {
                Client client = clientsGrid.SelectedItem as Client;
                db.Clients.Remove(client);
                db.SaveChanges();
                Load();
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do usunięcia!");
            }
        }

        private void borrowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (booksGrid.SelectedItem != null && booksGrid.SelectedItem is Book)
            {
                Book book = booksGrid.SelectedItem as Book;

                BorrowWindow bw = new BorrowWindow(book, this);
                bw.Show();
                this.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do wypożyczenia!");
            }
        }

        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (borrowsGrid.SelectedItem != null && borrowsGrid.SelectedItem is Borrow)
            {
                Borrow borrow = borrowsGrid.SelectedItem as Borrow;
                borrow.Returned = true;
                borrow.ReturnDate = DateTime.Now;

                db.SaveChanges();

                Load();
            }
            else
            {
                MessageBox.Show("Wybierz pozycje do zwrotu!");
            }
        }

        private void booksGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string name = e.Column.Header.ToString();

            if (name == "Id" || name == "Borrows" || name == "CategoryId")
            {
                e.Cancel = true;
            }
        }

        private void clientsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string name = e.Column.Header.ToString();

            if (name == "Id" || name == "Borrows")
            {
                e.Cancel = true;
            }
        }

        private void borrowsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            /*public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public bool Returned { get; set; }
        public DateTime ReturnDate { get; set; }

        public Book Book { get; set; }
        public Client Client { get; set; }*/

            string name = e.Column.Header.ToString();

            if (name == "Id" || name == "BookId" || name == "ClientId")
            {
                e.Cancel = true;
            }
        }
    }
}
