using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// klasa categori dla tebeli kategori
    /// </summary>
    public class Category
    {
        /// <summary>
        /// getter setter dla danych
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }

        /// <summary>
        /// konstruktor dla Category
        /// </summary>
        public Category(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Tostring dla Category
        /// </summary>
        /// <returns>
        /// Zwraca name
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
