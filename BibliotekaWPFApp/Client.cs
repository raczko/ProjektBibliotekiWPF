using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// klasa client 
    /// </summary>
    public class Client
    {
        /// <summary>
        /// getter setter dla danych pozniej
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Borrow> Borrows { get; set; }
        /// <summary>
        /// konstruktor dla client zapisujacy dane 
        /// </summary>
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        /// <summary>
        /// Tostring dla klasy client
        /// </summary>
        /// <returns>
        /// zwraca name oraz surname
        /// </returns>
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
