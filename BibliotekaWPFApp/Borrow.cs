using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// publiczna klasa borrow dla tabeli borrow
    /// </summary>
    public class Borrow
    {
        /// <summary>
        /// gettery i settery dla danych pozniej
        /// </summary>
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public bool Returned { get; set; }
        public DateTime ReturnDate { get; set; }

        public Book Book { get; set; }
        public Client Client { get; set; }

        /// <summary>
        /// konstruktor dla klasy borow zapisujacy dane
        /// </summary>
        public Borrow(int bookId, int clientId)
        {
            BookId = bookId;
            ClientId = clientId;
            Date = DateTime.Now;
        }
        /// <summary>
        /// to string dla klasy borrow zwraca inforamcje o zworceniu ksiazki lub tez nie
        /// </summary>
        /// <returns>
        /// pokazuje date ksiazke i id klienta
        /// </returns>
        public override string ToString()
        {
            string status = Returned ? "Zwrócono" : "Wypożyczono";
            return $"{Date}: {Book}, {Client} {status}";
        }
    }
}
