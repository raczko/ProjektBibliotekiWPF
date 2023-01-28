using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// publiczna klasa book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Konstruktor ktory zapisuje dane wprowadzane przez usera
        /// </summary>
        public Book(string title, string author, int categoryId)
        {
            Title = title;
            Author = author;
            CategoryId = categoryId;

        }
        /// <summary>
        /// setter getter dla danych pozniej 
        /// </summary>
        /// cos
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Borrow> Borrows { get; set; }

        /// <summary>
        /// metoda to string dla tej klasy
        /// </summary>
        /// <returns>
        /// zwraca autora tytul oraz categorie
        /// </returns>
        public override string ToString()
        {
            return $"{Author} {Title} - {Category}"; 
        }
    }
}
