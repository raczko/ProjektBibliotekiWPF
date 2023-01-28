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
    public partial class AddBook : Window
    {
        /// <summary>
        ///  publiczny getter setter dla zmiennej Mw typ danych MainWindow
        /// </summary>
        public MainWindow Mw { get; set; }
        
        /// <summary>
        /// Konstruktor ktory wypisuej dane
        /// </summary>
       
        public AddBook(MainWindow mw)
        {
            InitializeComponent();

            Mw = mw;

            categoryCmb.ItemsSource = Mw.db.Categories.ToList();
            categoryCmb.SelectedIndex = 0;
        }
        /// <summary>
        /// metoda do eventu zapisujocego dane
        /// </summary>
        private void zapiszBtn_Click(object sender, RoutedEventArgs e)
        {
            //sprawdzanie danych
            if(string.IsNullOrEmpty(titleTxt1.Text) || string.IsNullOrEmpty(authorTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                //wpisywanie danych
                Category c = (Category)categoryCmb.SelectedItem;

                Book b = new Book(titleTxt1.Text, authorTxt.Text,c.Id);

                Mw.db.Books.Add(b);
                Mw.db.SaveChanges();

                Mw.Load();
                Mw.IsEnabled = true;

                this.Close();
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
