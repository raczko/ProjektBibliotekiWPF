using BibliotekaWPFApp;

namespace TestProjectBiblioteka
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        //wypozyczenie 
        public void BookToStringTest()
        {
            Book b = new Book("title1","author1",1);

            Assert.IsTrue(b.ToString().Contains("title1") && b.ToString().Contains("author1"));
        }

        [TestMethod]
        //wypozyczenie 
        public void BorrowToStringTest()
        {
            Borrow b = new Borrow(1,1);

            Assert.IsTrue(b.ToString().Contains("Wypo¿yczono"));
        }
        //sprawdzenie klienta
        [TestMethod]
        public void ClientToStringTest()
        {
            Client c = new Client("Jan", "Kowalski");

            Assert.IsTrue(c.ToString().Contains("Jan") && c.ToString().Contains("Kowalski"));
        }

        //sprawdzenie kategori
        [TestMethod]
        public void CategoryToStringTest()
        {
            Category c = new Category("Krymina³");

            Assert.IsTrue(c.ToString().Contains("Krymina³"));
        }


    }
}